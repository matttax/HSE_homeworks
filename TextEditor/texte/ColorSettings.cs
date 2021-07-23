using System;
using System.Drawing;
using System.Windows.Forms;

namespace texte
{
    public partial class ColorSettings : Form
    {
        ColorDialog colorDialog;
        public Color RTB {get; private set;}
        public Color Toolbar {get; private set;}
        public Color Background { get; private set; }
        public ColorSettings(Color currentBackground, Color currentToolbar, Color currentRTB)
        {
            InitializeComponent();
            Background = backgroundColor.BackColor = currentBackground;
            Toolbar = toolbarColor.BackColor = currentToolbar;
            RTB = rtbColor.BackColor = currentRTB;
        }

        /// <summary>
        /// Change background color.
        /// </summary>
        private void PickBackgroundColor_Click(object sender, EventArgs e) =>
            Background = backgroundColor.BackColor = ChangeColor(Background);

        /// <summary>
        /// Change toolbar color.
        /// </summary>
        private void PickToolbarColor_Click(object sender, EventArgs e) =>
            Toolbar = toolbarColor.BackColor = ChangeColor(Toolbar);

        /// <summary>
        /// Change textbox background color.
        /// </summary>
        private void PickRTBColor_Click(object sender, EventArgs e) =>
            RTB = rtbColor.BackColor = ChangeColor(RTB);

        /// <summary>
        /// Change color using ColorDialog..
        /// </summary>
        /// <returns> New color. </returns>
        private Color ChangeColor(Color color) =>
            (colorDialog = new ColorDialog()).ShowDialog() == DialogResult.OK ? colorDialog.Color : color;

        /// <summary>
        /// Close form.
        /// </summary>
        private void OK_Click(object sender, EventArgs e) => Close();
    }
}
