
namespace csv_viewer
{
    partial class TablePad
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.OpenFile = new System.Windows.Forms.Button();
            this.Graph = new System.Windows.Forms.Button();
            this.Frequency = new System.Windows.Forms.Button();
            this.Average = new System.Windows.Forms.Button();
            this.Median = new System.Windows.Forms.Button();
            this.StandardDeviation = new System.Windows.Forms.Button();
            this.Dispersion = new System.Windows.Forms.Button();
            this.Color = new System.Windows.Forms.Button();
            this.SortingParams = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToOrderColumns = true;
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(13, 85);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowHeadersWidth = 51;
            this.DataGrid.RowTemplate.Height = 24;
            this.DataGrid.Size = new System.Drawing.Size(1025, 478);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGrid_ColumnHeaderMouseClick);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(13, 13);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(102, 66);
            this.OpenFile.TabIndex = 1;
            this.OpenFile.Text = "Open file";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(121, 13);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(102, 66);
            this.Graph.TabIndex = 2;
            this.Graph.Text = "Build graph";
            this.Graph.UseVisualStyleBackColor = true;
            this.Graph.Click += new System.EventHandler(this.Graph_Click);
            // 
            // Frequency
            // 
            this.Frequency.Location = new System.Drawing.Point(229, 13);
            this.Frequency.Name = "Frequency";
            this.Frequency.Size = new System.Drawing.Size(102, 66);
            this.Frequency.TabIndex = 3;
            this.Frequency.Text = "Analyze frequency";
            this.Frequency.UseVisualStyleBackColor = true;
            this.Frequency.Click += new System.EventHandler(this.Frequency_Click);
            // 
            // Average
            // 
            this.Average.Location = new System.Drawing.Point(612, 13);
            this.Average.Name = "Average";
            this.Average.Size = new System.Drawing.Size(102, 66);
            this.Average.TabIndex = 4;
            this.Average.Text = "Average";
            this.Average.UseVisualStyleBackColor = true;
            this.Average.Click += new System.EventHandler(this.Average_Click);
            // 
            // Median
            // 
            this.Median.Location = new System.Drawing.Point(720, 13);
            this.Median.Name = "Median";
            this.Median.Size = new System.Drawing.Size(102, 66);
            this.Median.TabIndex = 5;
            this.Median.Text = "Median";
            this.Median.UseVisualStyleBackColor = true;
            this.Median.Click += new System.EventHandler(this.Median_Click);
            // 
            // StandardDeviation
            // 
            this.StandardDeviation.Location = new System.Drawing.Point(828, 13);
            this.StandardDeviation.Name = "StandardDeviation";
            this.StandardDeviation.Size = new System.Drawing.Size(102, 66);
            this.StandardDeviation.TabIndex = 6;
            this.StandardDeviation.Text = "Standard deviation";
            this.StandardDeviation.UseVisualStyleBackColor = true;
            this.StandardDeviation.Click += new System.EventHandler(this.StandardDeviation_Click);
            // 
            // Dispersion
            // 
            this.Dispersion.Location = new System.Drawing.Point(936, 13);
            this.Dispersion.Name = "Dispersion";
            this.Dispersion.Size = new System.Drawing.Size(102, 66);
            this.Dispersion.TabIndex = 7;
            this.Dispersion.Text = "Dispersion";
            this.Dispersion.UseVisualStyleBackColor = true;
            this.Dispersion.Click += new System.EventHandler(this.Dispersion_Click);
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(337, 13);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(102, 66);
            this.Color.TabIndex = 8;
            this.Color.Text = "Change color";
            this.Color.UseVisualStyleBackColor = true;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // SortingParams
            // 
            this.SortingParams.Location = new System.Drawing.Point(445, 13);
            this.SortingParams.Name = "SortingParams";
            this.SortingParams.Size = new System.Drawing.Size(102, 66);
            this.SortingParams.TabIndex = 9;
            this.SortingParams.Text = "Sorting parameters";
            this.SortingParams.UseVisualStyleBackColor = true;
            this.SortingParams.Click += new System.EventHandler(this.SortingParams_Click);
            // 
            // TablePad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 575);
            this.Controls.Add(this.SortingParams);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.Dispersion);
            this.Controls.Add(this.StandardDeviation);
            this.Controls.Add(this.Median);
            this.Controls.Add(this.Average);
            this.Controls.Add(this.Frequency);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.DataGrid);
            this.Name = "TablePad";
            this.Text = "CSV viewer";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button Graph;
        private System.Windows.Forms.Button Frequency;
        private System.Windows.Forms.Button Average;
        private System.Windows.Forms.Button Median;
        private System.Windows.Forms.Button StandardDeviation;
        private System.Windows.Forms.Button Dispersion;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Button SortingParams;
    }
}

