using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace csv_viewer
{
    public partial class ChooseColumns : Form
    {

        /// <summary>
        /// Choose axes or numeric columns.
        /// </summary>
        public ChooseColumns(List<string> names, bool chooseAxes)
        {
            this.chooseAxes = chooseAxes;
            InitializeComponent();
            if (!chooseAxes)
                Controls.Remove(Line);
            foreach (var name in names)
                Names.Items.Add(name);
        }

        bool chooseAxes;
        public bool IsLine { private set; get; }
        public string X { private set; get; }
        public string Y { private set; get; }
        public List<int> Numerics { private set; get; }

        /// <summary>
        /// Set columns and close.
        /// </summary>
        private void Ok_Click(object sender, EventArgs e)
        {
            if (chooseAxes)
            {
                if (Names.CheckedItems.Count != 2)
                    MessageBox.Show("Choose 2 axes");
                else
                {
                    X = Names.CheckedItems[0].ToString();
                    Y = Names.CheckedItems[1].ToString();
                    IsLine = Line.Checked;
                    if (MessageBox.Show($"X = {Names.CheckedItems[0]}, Y = {Names.CheckedItems[1]}", "Axes", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                        Close();
                }
            }
            else
            {
                Numerics = Names.CheckedIndices.Cast<int>().ToList();
                Close();
            }
        }
    }
}
