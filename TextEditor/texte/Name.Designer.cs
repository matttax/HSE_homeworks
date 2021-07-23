
namespace texte
{
    partial class Name
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
            this.SetName = new System.Windows.Forms.Button();
            this.Namer = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SetName
            // 
            this.SetName.Location = new System.Drawing.Point(284, 90);
            this.SetName.Name = "SetName";
            this.SetName.Size = new System.Drawing.Size(125, 28);
            this.SetName.TabIndex = 5;
            this.SetName.Text = "OK";
            this.SetName.UseVisualStyleBackColor = true;
            this.SetName.Click += new System.EventHandler(this.SetName_Click);
            // 
            // Namer
            // 
            this.Namer.Location = new System.Drawing.Point(12, 36);
            this.Namer.Name = "Namer";
            this.Namer.Size = new System.Drawing.Size(404, 22);
            this.Namer.TabIndex = 4;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.NameLabel.Location = new System.Drawing.Point(12, 11);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(150, 22);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Input file name:";
            // 
            // Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 130);
            this.Controls.Add(this.SetName);
            this.Controls.Add(this.Namer);
            this.Controls.Add(this.NameLabel);
            this.Name = "Name";
            this.Text = "Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SetName;
        public System.Windows.Forms.TextBox Namer;
        private System.Windows.Forms.Label NameLabel;
    }
}