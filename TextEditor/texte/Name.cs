using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace texte
{
    public partial class Name : Form
    {
        public string FileName { private set; get; }
        public Name()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Check if name can be set.
        /// </summary>
        private void SetName_Click(object sender, EventArgs e)
        {
            if (Namer.Text.Trim() == "")
                MessageBox.Show("Incorrect name");
            else
            {
                FileName = Namer.Text;
                Close();
            }
        }
    }
}
