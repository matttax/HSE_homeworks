using System;
using System.Windows.Forms;

namespace csv_viewer
{
    public partial class ChartBuilder : Form
    {
        public ChartBuilder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Save chart (png or jpeg).
        /// </summary>
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JPEG|*.jpeg|PNG|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                    chart.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
            }
            catch { MessageBox.Show("Failed to save");}
        }
    }
}
