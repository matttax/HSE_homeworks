
namespace texte
{
    partial class ColorSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundColor = new System.Windows.Forms.Panel();
            this.PickBackgroundColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.toolbarColor = new System.Windows.Forms.Panel();
            this.PickToolbarColor = new System.Windows.Forms.Button();
            this.PickRTBColor = new System.Windows.Forms.Button();
            this.rtbColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Background Color";
            // 
            // backgroundColor
            // 
            this.backgroundColor.Location = new System.Drawing.Point(16, 42);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(34, 32);
            this.backgroundColor.TabIndex = 1;
            // 
            // PickBackgroundColor
            // 
            this.PickBackgroundColor.Location = new System.Drawing.Point(16, 92);
            this.PickBackgroundColor.Name = "PickBackgroundColor";
            this.PickBackgroundColor.Size = new System.Drawing.Size(75, 23);
            this.PickBackgroundColor.TabIndex = 2;
            this.PickBackgroundColor.Text = "Set Color";
            this.PickBackgroundColor.UseVisualStyleBackColor = true;
            this.PickBackgroundColor.Click += new System.EventHandler(this.PickBackgroundColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Toolbar Color";
            // 
            // toolbarColor
            // 
            this.toolbarColor.Location = new System.Drawing.Point(189, 42);
            this.toolbarColor.Name = "toolbarColor";
            this.toolbarColor.Size = new System.Drawing.Size(34, 32);
            this.toolbarColor.TabIndex = 2;
            // 
            // PickToolbarColor
            // 
            this.PickToolbarColor.Location = new System.Drawing.Point(189, 92);
            this.PickToolbarColor.Name = "PickToolbarColor";
            this.PickToolbarColor.Size = new System.Drawing.Size(75, 23);
            this.PickToolbarColor.TabIndex = 4;
            this.PickToolbarColor.Text = "Set Color";
            this.PickToolbarColor.UseVisualStyleBackColor = true;
            this.PickToolbarColor.Click += new System.EventHandler(this.PickToolbarColor_Click);
            // 
            // PickRTBColor
            // 
            this.PickRTBColor.Location = new System.Drawing.Point(354, 92);
            this.PickRTBColor.Name = "PickRTBColor";
            this.PickRTBColor.Size = new System.Drawing.Size(75, 23);
            this.PickRTBColor.TabIndex = 7;
            this.PickRTBColor.Text = "Set Color";
            this.PickRTBColor.UseVisualStyleBackColor = true;
            this.PickRTBColor.Click += new System.EventHandler(this.PickRTBColor_Click);
            // 
            // rtbColor
            // 
            this.rtbColor.Location = new System.Drawing.Point(354, 42);
            this.rtbColor.Name = "rtbColor";
            this.rtbColor.Size = new System.Drawing.Size(34, 32);
            this.rtbColor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Textbox Color";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(523, 13);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(110, 102);
            this.OK.TabIndex = 8;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // ColorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 127);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.PickRTBColor);
            this.Controls.Add(this.rtbColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PickToolbarColor);
            this.Controls.Add(this.toolbarColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PickBackgroundColor);
            this.Controls.Add(this.backgroundColor);
            this.Controls.Add(this.label1);
            this.Name = "ColorSettings";
            this.Text = "ColorSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel backgroundColor;
        private System.Windows.Forms.Button PickBackgroundColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel toolbarColor;
        private System.Windows.Forms.Button PickToolbarColor;
        private System.Windows.Forms.Button PickRTBColor;
        private System.Windows.Forms.Panel rtbColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OK;
    }
}