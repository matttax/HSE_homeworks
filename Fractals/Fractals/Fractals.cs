using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractals
{
    public partial class Fractals : Form
    {
        int treeAngle = 45;
        double setGap = 0.35;
        public Fractals()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        /// <summary>
        /// Draw fractal in the PictureBox.
        /// </summary>
        private void buildFractal_Click(object sender, EventArgs e)
        {
            if (chooseFractal.SelectedItem == null)
                return;
            Fractal fractal = getFractal(chooseFractal.SelectedItem.ToString());
            FractalBox.BackgroundImage = fractal.DrawFractal();
        }

        /// <summary>
        /// Upload the user's toolbar.
        /// </summary>
        private void chooseFractal_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
                if (control.Location.X == 474)
                    Controls.Remove(control);
            foreach (Control control in Controls)
                if (control.Location.X == 474)
                    Controls.Remove(control);
            recursionDepth.Value = Math.Min(recursionMax(chooseFractal.SelectedItem.ToString()), recursionDepth.Value);
            recursionDepth.Maximum = recursionMax(chooseFractal.SelectedItem.ToString());
            ComboBox additionalParam = new ComboBox();
            Label label = new Label();
            additionalParam.Location = new Point(474, 39);
            label.Location = new Point(474, 16);
            additionalParam.Size = new Size(159, 28);
            if (chooseFractal.Text == "Tree")
            {
                for (int i = 15; i <= 75; i += 15)
                    additionalParam.Items.Add(i);
                additionalParam.SelectedIndexChanged += (object sender, EventArgs e) =>
                    treeAngle = (int)(sender as ComboBox).SelectedItem;
                label.Text = "Angle";
                Controls.Add(additionalParam);
                Controls.Add(label);
            }
            if (chooseFractal.Text == "Kantor set")
            {
                for (double i = 0.25; i < 0.5; i+=0.05)
                    additionalParam.Items.Add(Math.Round(i,2));
                additionalParam.SelectedIndexChanged += (object sender, EventArgs e) =>
                    setGap = (double)(sender as ComboBox).SelectedItem;
                label.Text = "Gap";
                Controls.Add(additionalParam);
                Controls.Add(label);
            }
        }

        /// <summary>
        /// Alert user that depth matters only when fractal is chosen.
        /// </summary>
        private void recursionDepth_ValueChanged(object sender, EventArgs e)
        {
            if (chooseFractal.SelectedItem == null)
                MessageBox.Show("Choose fractal!");
        }

        /// <summary>
        /// Create instance of fractal.
        /// </summary>
        /// <returns> Instance of selected fractal. </returns>
        private Fractal getFractal(string fractal)
        {
            switch (fractal)
            {
                default: return new Tree((int)recursionDepth.Value, FractalBox.Width, FractalBox.Height, treeAngle);
                case "Serpinsky carpet": return new Carpet((int)recursionDepth.Value, FractalBox.Width, FractalBox.Height);
                case "Serpinsky triangle": return new Triangle((int)recursionDepth.Value, FractalBox.Width, FractalBox.Height);
                case "Koch curve": return new Curve((int)recursionDepth.Value, FractalBox.Width, FractalBox.Height);
                case "Kantor set": return new Set((int)recursionDepth.Value, FractalBox.Width, FractalBox.Height, setGap);
            }
        }

        /// <summary>
        /// Max depth of recursion for certain fractal.
        /// </summary>
        /// <returns> Max depth. </returns>
        private int recursionMax(string fractal)
        {
            switch (fractal)
            {
                case "Tree": return 20;
                case "Serpinsky carpet": return 6;
                default: return 10;
            }
        }

    }
}
