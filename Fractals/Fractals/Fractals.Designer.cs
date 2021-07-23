
namespace Fractals
{
    partial class Fractals
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FractalBox = new System.Windows.Forms.PictureBox();
            this.chooseFractal = new System.Windows.Forms.ComboBox();
            this.recursionDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buildFractal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FractalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // FractalBox
            // 
            this.FractalBox.Location = new System.Drawing.Point(29, 100);
            this.FractalBox.Margin = new System.Windows.Forms.Padding(4);
            this.FractalBox.Name = "FractalBox";
            this.FractalBox.Size = new System.Drawing.Size(733, 733);
            this.FractalBox.TabIndex = 0;
            this.FractalBox.TabStop = false;
            // 
            // chooseFractal
            // 
            this.chooseFractal.FormattingEnabled = true;
            this.chooseFractal.Items.AddRange(new object[] {
            "Tree",
            "Serpinsky carpet",
            "Serpinsky triangle",
            "Koch curve",
            "Kantor set"});
            this.chooseFractal.Location = new System.Drawing.Point(29, 39);
            this.chooseFractal.Name = "chooseFractal";
            this.chooseFractal.Size = new System.Drawing.Size(285, 28);
            this.chooseFractal.TabIndex = 1;
            this.chooseFractal.SelectedIndexChanged += new System.EventHandler(this.chooseFractal_SelectedIndexChanged);
            // 
            // recursionDepth
            // 
            this.recursionDepth.Location = new System.Drawing.Point(336, 40);
            this.recursionDepth.Name = "recursionDepth";
            this.recursionDepth.Size = new System.Drawing.Size(114, 27);
            this.recursionDepth.TabIndex = 2;
            this.recursionDepth.ValueChanged += new System.EventHandler(this.recursionDepth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fractal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Depth";
            // 
            // buildFractal
            // 
            this.buildFractal.Location = new System.Drawing.Point(668, 14);
            this.buildFractal.Name = "buildFractal";
            this.buildFractal.Size = new System.Drawing.Size(94, 53);
            this.buildFractal.TabIndex = 5;
            this.buildFractal.Text = "Draw";
            this.buildFractal.UseVisualStyleBackColor = true;
            this.buildFractal.Click += new System.EventHandler(this.buildFractal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 857);
            this.Controls.Add(this.buildFractal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recursionDepth);
            this.Controls.Add(this.chooseFractal);
            this.Controls.Add(this.FractalBox);
            this.Name = "Form1";
            this.Text = "Fractals";
            ((System.ComponentModel.ISupportInitialize)(this.FractalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FractalBox;
        private System.Windows.Forms.ComboBox chooseFractal;
        private System.Windows.Forms.NumericUpDown recursionDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buildFractal;
    }
}

