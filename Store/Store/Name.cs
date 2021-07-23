using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    // Вспомогательная форма для установки имени секции.
    public partial class Name : Form
    {
        public string SectionName { private set; get; }
        public Name()
        {
            InitializeComponent();
            Ok.Enabled = false;
        }

        /// <summary>
        /// Save and close.
        /// </summary>
        private void Ok_Click(object sender, EventArgs e)
        {
            SectionName = textBox.Text;
            Close();
        }

        private void textBox_TextChanged(object sender, EventArgs e) =>
            Ok.Enabled = Commodity.NameIsValid(textBox.Text);

        private void NameInfo_Click(object sender, EventArgs e) => 
            MessageBox.Show(@"Numbers, spaces and Latin\Cyrillic symbols");
    }
}
