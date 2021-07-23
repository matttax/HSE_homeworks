
namespace Store
{
    partial class Store
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
            this.Add = new System.Windows.Forms.Button();
            this.AddCommodity = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.DeleteCommodity = new System.Windows.Forms.Button();
            this.EditCommodity = new System.Windows.Forms.Button();
            this.CSV = new System.Windows.Forms.Button();
            this.SuperTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(23, 16);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(139, 29);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add section";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // AddCommodity
            // 
            this.AddCommodity.Location = new System.Drawing.Point(345, 16);
            this.AddCommodity.Name = "AddCommodity";
            this.AddCommodity.Size = new System.Drawing.Size(126, 29);
            this.AddCommodity.TabIndex = 2;
            this.AddCommodity.Text = "Add commodity";
            this.AddCommodity.UseVisualStyleBackColor = true;
            this.AddCommodity.Click += new System.EventHandler(this.AddCommodity_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(182, 16);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(142, 29);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Delete section";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(345, 55);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(578, 379);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(101, 55);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(61, 29);
            this.Save.TabIndex = 5;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(23, 55);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(72, 29);
            this.Load.TabIndex = 6;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // DeleteCommodity
            // 
            this.DeleteCommodity.Location = new System.Drawing.Point(477, 16);
            this.DeleteCommodity.Name = "DeleteCommodity";
            this.DeleteCommodity.Size = new System.Drawing.Size(141, 29);
            this.DeleteCommodity.TabIndex = 7;
            this.DeleteCommodity.Text = "Delete commodity";
            this.DeleteCommodity.UseVisualStyleBackColor = true;
            this.DeleteCommodity.Click += new System.EventHandler(this.DeleteCommodity_Click);
            // 
            // EditCommodity
            // 
            this.EditCommodity.Location = new System.Drawing.Point(624, 16);
            this.EditCommodity.Name = "EditCommodity";
            this.EditCommodity.Size = new System.Drawing.Size(123, 29);
            this.EditCommodity.TabIndex = 8;
            this.EditCommodity.Text = "Edit commodity";
            this.EditCommodity.UseVisualStyleBackColor = true;
            this.EditCommodity.Click += new System.EventHandler(this.EditCommodity_Click);
            // 
            // CSV
            // 
            this.CSV.Location = new System.Drawing.Point(182, 55);
            this.CSV.Name = "CSV";
            this.CSV.Size = new System.Drawing.Size(142, 29);
            this.CSV.TabIndex = 9;
            this.CSV.Text = "Export to CSV";
            this.CSV.UseVisualStyleBackColor = true;
            this.CSV.Click += new System.EventHandler(this.CSV_Click);
            // 
            // SuperTable
            // 
            this.SuperTable.Location = new System.Drawing.Point(783, 16);
            this.SuperTable.Name = "SuperTable";
            this.SuperTable.Size = new System.Drawing.Size(140, 29);
            this.SuperTable.TabIndex = 10;
            this.SuperTable.Text = "Build super table";
            this.SuperTable.UseVisualStyleBackColor = true;
            this.SuperTable.Click += new System.EventHandler(this.SuperTable_Click);
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 450);
            this.Controls.Add(this.SuperTable);
            this.Controls.Add(this.CSV);
            this.Controls.Add(this.EditCommodity);
            this.Controls.Add(this.DeleteCommodity);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.AddCommodity);
            this.Controls.Add(this.Add);
            this.Name = "Store";
            this.Text = "Store";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button AddCommodity;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button DeleteCommodity;
        private System.Windows.Forms.Button EditCommodity;
        private System.Windows.Forms.Button CSV;
        private System.Windows.Forms.Button SuperTable;
    }
}

