
namespace Store
{
    partial class QuantityLimit
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
            this.Ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.NoLimit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(227, 75);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(94, 29);
            this.Ok.TabIndex = 14;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Set quantity limit";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 42);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(309, 27);
            this.textBox.TabIndex = 12;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // NoLimit
            // 
            this.NoLimit.AutoSize = true;
            this.NoLimit.Location = new System.Drawing.Point(236, 12);
            this.NoLimit.Name = "NoLimit";
            this.NoLimit.Size = new System.Drawing.Size(85, 24);
            this.NoLimit.TabIndex = 15;
            this.NoLimit.Text = "No limit";
            this.NoLimit.UseVisualStyleBackColor = true;
            this.NoLimit.CheckedChanged += new System.EventHandler(this.NoLimit_CheckedChanged);
            // 
            // QuantityLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 113);
            this.Controls.Add(this.NoLimit);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox);
            this.Name = "QuantityLimit";
            this.Text = "QuantityLimit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox NoLimit;
    }
}