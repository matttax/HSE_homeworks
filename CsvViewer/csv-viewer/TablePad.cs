using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CsvHelper;

namespace csv_viewer
{
    public partial class TablePad : Form
    {
        Column[] columns;
        public int currentColumn = -1;
        public string path;
        public TablePad()
        {
            InitializeComponent();
        }

        #region Main options
        /// <summary>
        /// Try to open selected csv file.
        /// </summary>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        OpenCsvFile(ofd.FileName);
                }
            }
            catch { MessageBox.Show("Invalid file"); }
        }

        /// <summary>
        /// Build bar or line chart. 
        /// </summary>
        private void Graph_Click(object sender, EventArgs e)
        {
            if (DataGrid.DataSource == null)
                return;
            List<string> names = new List<string>();
            for (int i = 0; i < DataGrid.Columns.Count; i++)
                names.Add(DataGrid.Columns[i].Name);
            ChooseColumns chooseAxes = new ChooseColumns(names, true);
            SetDialogParams(ref chooseAxes);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            try
            {
                double[] xAxis = ParseColumn(chooseAxes.X).ToArray();
                double[] yAxis = ParseColumn(chooseAxes.Y).ToArray();

                ChartBuilder chartBuilder = new ChartBuilder();
                chartBuilder.Show();
                chartBuilder.chart.Series.Clear();
                chartBuilder.chart.Series.Add(chooseAxes.Y);
                if (chooseAxes.IsLine)
                {
                    chartBuilder.chart.Series[chooseAxes.Y].ChartType = SeriesChartType.Line;
                    Array.Sort(xAxis, yAxis);
                }
                for (int i = 0; i < DataGrid.Rows.Count - 1; i++)
                    chartBuilder.chart.Series[chooseAxes.Y].Points.AddXY(xAxis[i], yAxis[i]);
                EnableZooming(ref chartBuilder);
            }
            catch { MessageBox.Show("Unable to build the graph."); }
}

        /// <summary>
        /// Build frequency chart for the column.
        /// </summary>
        private void Frequency_Click(object sender, EventArgs e)
        {
            if (DataGrid.DataSource == null)
                return;
            try
            {
                Dictionary<string, int> frequency = new Dictionary<string, int>();
                for (int i = 0; i < DataGrid.Rows.Count - 1; i++)
                    if (DataGrid.Rows[i] != null)
                        if (DataGrid.Rows[i].Cells[currentColumn] != null)
                        {
                            if (frequency.ContainsKey(DataGrid.Rows[i].Cells[currentColumn].Value.ToString()))
                                frequency[DataGrid.Rows[i].Cells[currentColumn].Value.ToString()]++;
                            else frequency.Add(DataGrid.Rows[i].Cells[currentColumn].Value.ToString(), 1);
                        }
                ChartBuilder chartBuilder = new ChartBuilder();
                chartBuilder.Show();
                chartBuilder.chart.Series.Clear();
                chartBuilder.chart.Series.Add(DataGrid.Columns[currentColumn].Name);
                chartBuilder.chart.Series[DataGrid.Columns[currentColumn].Name].Points.Clear();
                for (int i = 1; i <= frequency.Count; i++)
                {
                    chartBuilder.chart.Series[DataGrid.Columns[currentColumn].Name].Points.AddXY(i, frequency.Values.Skip(i - 1).First());
                    chartBuilder.chart.Series[DataGrid.Columns[currentColumn].Name].Points.Last().Label = frequency.Keys.Skip(i - 1).First();
                }
                EnableZooming(ref chartBuilder);
            }
            catch { MessageBox.Show("Column is not selected\nClick the header to select one"); }

        }

        /// <summary>
        /// Change color of column.
        /// </summary>
        private void Color_Click(object sender, EventArgs e)
        {
            if (DataGrid.DataSource == null)
                return;
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                    DataGrid.Columns[currentColumn].DefaultCellStyle.BackColor = columns[currentColumn].Color =
                        colorDialog.Color;
            }
            catch { MessageBox.Show("Column is not selected\nClick the header to select one"); }
        }

        /// <summary>
        /// Set numeric columns.
        /// </summary>
        private void SortingParams_Click(object sender, EventArgs e)
        {
            if (DataGrid.DataSource == null)
                return;
            List<string> names = new List<string>();
            for (int i = 0; i < DataGrid.Columns.Count; i++)
                names.Add(DataGrid.Columns[i].Name);
            ChooseColumns chooseAxes = new ChooseColumns(names, false);
            SetDialogParams(ref chooseAxes);
            if (chooseAxes.Numerics == null)
                return;
            try { OpenCsvFile(path, chooseAxes.Numerics.ToArray()); }
            catch
            {
                OpenCsvFile(path);
                MessageBox.Show("Not numeric columns");
            }
        }
        #endregion
        #region Math
        private void Average_Click(object sender, EventArgs e)
        {
            try { MessageBox.Show(ParseColumn(currentColumn).Average().ToString("F2")); }
            catch { MessageBox.Show("Not a number column\nClick the header to select column"); }
        }
        private void Median_Click(object sender, EventArgs e)
        {
            try
            {
                List<double> values = ParseColumn(currentColumn).Distinct().ToList();
                MessageBox.Show((values.Sum() / values.Count).ToString("F2"));
            }
            catch { MessageBox.Show("Not a number column\nClick the header to select column"); }
        }
        private void StandardDeviation_Click(object sender, EventArgs e)
        {
            try { MessageBox.Show(Math.Sqrt(FindDispersion(ParseColumn(currentColumn))).ToString("F2")); }
            catch { MessageBox.Show("Not a number column\nClick the header to select column"); }
        }
        private void Dispersion_Click(object sender, EventArgs e)
        {
            try { MessageBox.Show(FindDispersion(ParseColumn(currentColumn)).ToString("F2")); }
            catch { MessageBox.Show("Not a number column\nClick the header to select column"); }
        }
        double FindDispersion(List<double> values)
        {
            double average = values.Average();
            double sumOfSquaresOfDifferences = values.Select(val => (val - average) * (val - average)).Sum();
            return sumOfSquaresOfDifferences / values.Count;
        }
        #endregion

        /// <summary>
        /// Highlight the column.
        /// </summary>
        private void DataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            currentColumn = e.ColumnIndex;
            for (int i = 0; i < DataGrid.Columns.Count; i++)
                DataGrid.Columns[i].DefaultCellStyle.BackColor = columns[i].Color;
            DataGrid.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
        }

        /// <summary>
        /// Allow to zoom the chart.
        /// </summary>
        private static void EnableZooming(ref ChartBuilder chartBuilder)
        {
            ChartArea CA = chartBuilder.chart.ChartAreas[0];
            CA.AxisX.ScaleView.Zoomable = true;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;
        }

        /// <summary>
        /// Turns column values into List of doubles.
        /// </summary>
        /// <returns> List of doubles. </returns>
        private List<double> ParseColumn(string columnIndex)
        {
            List<double> values = new List<double>();
            for (int i = 0; i < DataGrid.Rows.Count - 1; i++)
                if (DataGrid.Rows[i] != null)
                    if (DataGrid.Rows[i].Cells[columnIndex] != null)
                        values.Add(double.Parse(DataGrid.Rows[i].Cells[columnIndex].Value.ToString(), NumberStyles.Float));
            return values;
        }
        private List<double> ParseColumn(int columnIndex)
        {
            List<double> values = new List<double>();
            for (int i = 0; i < DataGrid.Rows.Count - 1; i++)
                if (DataGrid.Rows[i] != null)
                    if (DataGrid.Rows[i].Cells[columnIndex] != null)
                        values.Add(double.Parse(DataGrid.Rows[i].Cells[columnIndex].Value.ToString(), NumberStyles.Float));
            return values;
        }

        /// <summary>
        /// Open csv file and set numeric columns for sorting.
        /// </summary>
        private void OpenCsvFile(string path, params int[] numericColumns)
        {
            this.path = path;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, new CultureInfo("en-US")))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dr);
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                        dataTable.Columns[i].DefaultValue = "0";
                    DataGrid.DataSource = dataTable;
                }
            }
            columns = new Column[DataGrid.Columns.Count];
            for (int b = 0; b < columns.Length; b++)
                columns[b] = new Column(false, System.Drawing.Color.White);
            DataGrid.AllowUserToAddRows = false;

            DataTable decimalDataTable = (DataGrid.DataSource as DataTable).Clone();
            foreach (var col in numericColumns)
                decimalDataTable.Columns[col].DataType = typeof(decimal);
            foreach (DataRow row in (DataGrid.DataSource as DataTable).Rows)
                decimalDataTable.ImportRow(row);
            DataGrid.DataSource = decimalDataTable;
        }

        /// <summary>
        /// Set dialog parameters and show it.
        /// </summary>
        private void SetDialogParams<T>(ref T form) where T : Form
        {
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowDialog();
        }
    }
}
