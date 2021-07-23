
namespace Store
{
    partial class Commodity
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.QuantityBox = new System.Windows.Forms.TextBox();
            this.ArticulusBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.Button();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ArticulusInfo = new System.Windows.Forms.Button();
            this.NameInfo = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ArticulusLabel = new System.Windows.Forms.Label();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Articulus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity";
            // 
            // QuantityBox
            // 
            this.QuantityBox.Location = new System.Drawing.Point(125, 134);
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(283, 27);
            this.QuantityBox.TabIndex = 3;
            this.QuantityBox.TextChanged += new System.EventHandler(this.QuantityBox_TextChanged);
            // 
            // ArticulusBox
            // 
            this.ArticulusBox.Location = new System.Drawing.Point(125, 77);
            this.ArticulusBox.Name = "ArticulusBox";
            this.ArticulusBox.Size = new System.Drawing.Size(283, 27);
            this.ArticulusBox.TabIndex = 4;
            this.ArticulusBox.TextChanged += new System.EventHandler(this.ArticulusBox_TextChanged);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(125, 21);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(283, 27);
            this.NameBox.TabIndex = 5;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(345, 251);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(94, 29);
            this.Ok.TabIndex = 6;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // PriceBox
            // 
            this.PriceBox.Location = new System.Drawing.Point(125, 188);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(283, 27);
            this.PriceBox.TabIndex = 8;
            this.PriceBox.TextChanged += new System.EventHandler(this.PriceBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Price";
            // 
            // ArticulusInfo
            // 
            this.ArticulusInfo.Font = new System.Drawing.Font("STXingkai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArticulusInfo.Location = new System.Drawing.Point(103, 81);
            this.ArticulusInfo.Name = "ArticulusInfo";
            this.ArticulusInfo.Size = new System.Drawing.Size(16, 23);
            this.ArticulusInfo.TabIndex = 9;
            this.ArticulusInfo.Text = "i";
            this.ArticulusInfo.UseVisualStyleBackColor = true;
            this.ArticulusInfo.Click += new System.EventHandler(this.ArticulusInfo_Click);
            // 
            // NameInfo
            // 
            this.NameInfo.Font = new System.Drawing.Font("STXingkai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameInfo.Location = new System.Drawing.Point(103, 25);
            this.NameInfo.Name = "NameInfo";
            this.NameInfo.Size = new System.Drawing.Size(16, 23);
            this.NameInfo.TabIndex = 10;
            this.NameInfo.Text = "i";
            this.NameInfo.UseVisualStyleBackColor = true;
            this.NameInfo.Click += new System.EventHandler(this.NameInfo_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(413, 17);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(26, 28);
            this.NameLabel.TabIndex = 11;
            this.NameLabel.Text = "X";
            // 
            // ArticulusLabel
            // 
            this.ArticulusLabel.AutoSize = true;
            this.ArticulusLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ArticulusLabel.Location = new System.Drawing.Point(413, 73);
            this.ArticulusLabel.Name = "ArticulusLabel";
            this.ArticulusLabel.Size = new System.Drawing.Size(26, 28);
            this.ArticulusLabel.TabIndex = 12;
            this.ArticulusLabel.Text = "X";
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuantityLabel.Location = new System.Drawing.Point(413, 130);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(26, 28);
            this.QuantityLabel.TabIndex = 13;
            this.QuantityLabel.Text = "X";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PriceLabel.Location = new System.Drawing.Point(413, 184);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(26, 28);
            this.PriceLabel.TabIndex = 14;
            this.PriceLabel.Text = "X";
            // 
            // Commodity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 292);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.ArticulusLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameInfo);
            this.Controls.Add(this.ArticulusInfo);
            this.Controls.Add(this.PriceBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.ArticulusBox);
            this.Controls.Add(this.QuantityBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.CommodityName = "Commodity";
            this.Text = "Commodity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox QuantityBox;
        private System.Windows.Forms.TextBox ArticulusBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.TextBox PriceBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ArticulusInfo;
        private System.Windows.Forms.Button NameInfo;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ArticulusLabel;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Label PriceLabel;
    }
}