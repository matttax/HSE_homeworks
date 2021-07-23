using System;
using System.Windows.Forms;

namespace Store
{
    public partial class QuantityLimit : Form
    {
        public QuantityLimit()
        {
            InitializeComponent();
            Ok.Enabled = false;
        }
        uint limit;
        public uint Limit { get => limit; }
        public bool OkClicked { private set; get; }

        /// <summary>
        /// Save and close.
        /// </summary>
        private void Ok_Click(object sender, EventArgs e)
        {
            if (Limit != 0 || NoLimit.Checked)
            {
                OkClicked = true;
                Close();
            }
            else MessageBox.Show("Limit must be positive");
        }

        /// <summary>
        /// Update controls availability and set limit.
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(textBox.Text, out limit))
            {
                Ok.Enabled = true;
                return;
            }
            if (NoLimit.Checked)
            {
                limit = uint.MaxValue;
                Ok.Enabled = true;
                return;
            }
            Ok.Enabled = false;
        }

        /// <summary>
        /// Update controls availability and set limit as max value.
        /// </summary>
        private void NoLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (NoLimit.Checked)
            {
                limit = uint.MaxValue;
                Ok.Enabled = true;
                return;
            }
            if (uint.TryParse(textBox.Text, out limit))
            {
                Ok.Enabled = true;
                return;
            }
            Ok.Enabled = false;
        }
    }
}
