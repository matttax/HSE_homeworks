
namespace texte
{
    partial class TextPad
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
            this.components = new System.ComponentModel.Container();
            this.Toolbar = new System.Windows.Forms.TabControl();
            this.FileTab = new System.Windows.Forms.TabPage();
            this.Info = new System.Windows.Forms.Button();
            this.SaveAs = new System.Windows.Forms.Button();
            this.SaveAll = new System.Windows.Forms.Button();
            this.CloseTab = new System.Windows.Forms.Button();
            this.NewTab = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.TabPage();
            this.Redo = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.Paste = new System.Windows.Forms.Button();
            this.Cut = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.SelectAll = new System.Windows.Forms.Button();
            this.Format = new System.Windows.Forms.TabPage();
            this.ColorSettings = new System.Windows.Forms.Button();
            this.ChangeFont = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.TabPage();
            this.Clear = new System.Windows.Forms.Button();
            this.Hide = new System.Windows.Forms.Button();
            this.Unhide = new System.Windows.Forms.Button();
            this.OpenSecretDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LoggingOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AutosaveOptions = new System.Windows.Forms.ComboBox();
            this.Texts = new System.Windows.Forms.TabControl();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Toolbar.SuspendLayout();
            this.FileTab.SuspendLayout();
            this.Edit.SuspendLayout();
            this.Format.SuspendLayout();
            this.Settings.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toolbar
            // 
            this.Toolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Toolbar.Controls.Add(this.FileTab);
            this.Toolbar.Controls.Add(this.Edit);
            this.Toolbar.Controls.Add(this.Format);
            this.Toolbar.Controls.Add(this.Settings);
            this.Toolbar.Location = new System.Drawing.Point(13, 13);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.SelectedIndex = 0;
            this.Toolbar.Size = new System.Drawing.Size(1228, 100);
            this.Toolbar.TabIndex = 0;
            this.Toolbar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Toolbar_KeyDown);
            // 
            // FileTab
            // 
            this.FileTab.Controls.Add(this.Info);
            this.FileTab.Controls.Add(this.SaveAs);
            this.FileTab.Controls.Add(this.SaveAll);
            this.FileTab.Controls.Add(this.CloseTab);
            this.FileTab.Controls.Add(this.NewTab);
            this.FileTab.Controls.Add(this.Save);
            this.FileTab.Controls.Add(this.Open);
            this.FileTab.Location = new System.Drawing.Point(4, 25);
            this.FileTab.Name = "FileTab";
            this.FileTab.Padding = new System.Windows.Forms.Padding(3);
            this.FileTab.Size = new System.Drawing.Size(1220, 71);
            this.FileTab.TabIndex = 0;
            this.FileTab.Text = "File";
            this.FileTab.UseVisualStyleBackColor = true;
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(845, 6);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(120, 59);
            this.Info.TabIndex = 5;
            this.Info.Text = "Info";
            this.Info.UseVisualStyleBackColor = true;
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Location = new System.Drawing.Point(258, 6);
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(121, 59);
            this.SaveAs.TabIndex = 5;
            this.SaveAs.Text = "Save File As";
            this.SaveAs.UseVisualStyleBackColor = true;
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // SaveAll
            // 
            this.SaveAll.Location = new System.Drawing.Point(385, 6);
            this.SaveAll.Name = "SaveAll";
            this.SaveAll.Size = new System.Drawing.Size(120, 59);
            this.SaveAll.TabIndex = 4;
            this.SaveAll.Text = "Save All Files";
            this.SaveAll.UseVisualStyleBackColor = true;
            this.SaveAll.Click += new System.EventHandler(this.SaveAll_Click);
            // 
            // CloseTab
            // 
            this.CloseTab.Location = new System.Drawing.Point(719, 6);
            this.CloseTab.Name = "CloseTab";
            this.CloseTab.Size = new System.Drawing.Size(120, 59);
            this.CloseTab.TabIndex = 3;
            this.CloseTab.Text = "Close Tab";
            this.CloseTab.UseVisualStyleBackColor = true;
            this.CloseTab.Click += new System.EventHandler(this.CloseTab_Click);
            // 
            // NewTab
            // 
            this.NewTab.Location = new System.Drawing.Point(593, 6);
            this.NewTab.Name = "NewTab";
            this.NewTab.Size = new System.Drawing.Size(120, 59);
            this.NewTab.TabIndex = 2;
            this.NewTab.Text = "New Tab";
            this.NewTab.UseVisualStyleBackColor = true;
            this.NewTab.Click += new System.EventHandler(this.NewTab_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(132, 6);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(120, 59);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save File";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(6, 6);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(120, 59);
            this.Open.TabIndex = 0;
            this.Open.Text = "Open File";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Edit
            // 
            this.Edit.Controls.Add(this.Redo);
            this.Edit.Controls.Add(this.Undo);
            this.Edit.Controls.Add(this.Paste);
            this.Edit.Controls.Add(this.Cut);
            this.Edit.Controls.Add(this.Copy);
            this.Edit.Controls.Add(this.SelectAll);
            this.Edit.Location = new System.Drawing.Point(4, 25);
            this.Edit.Name = "Edit";
            this.Edit.Padding = new System.Windows.Forms.Padding(3);
            this.Edit.Size = new System.Drawing.Size(1220, 71);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            // 
            // Redo
            // 
            this.Redo.Location = new System.Drawing.Point(717, 6);
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(120, 59);
            this.Redo.TabIndex = 6;
            this.Redo.Text = "Redo";
            this.Redo.UseVisualStyleBackColor = true;
            this.Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // Undo
            // 
            this.Undo.Location = new System.Drawing.Point(591, 6);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(120, 59);
            this.Undo.TabIndex = 5;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Paste
            // 
            this.Paste.Location = new System.Drawing.Point(384, 6);
            this.Paste.Name = "Paste";
            this.Paste.Size = new System.Drawing.Size(120, 59);
            this.Paste.TabIndex = 4;
            this.Paste.Text = "Paste";
            this.Paste.UseVisualStyleBackColor = true;
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // Cut
            // 
            this.Cut.Location = new System.Drawing.Point(258, 6);
            this.Cut.Name = "Cut";
            this.Cut.Size = new System.Drawing.Size(120, 59);
            this.Cut.TabIndex = 3;
            this.Cut.Text = "Cut";
            this.Cut.UseVisualStyleBackColor = true;
            this.Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(132, 6);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(120, 59);
            this.Copy.TabIndex = 2;
            this.Copy.Text = "Copy";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.Location = new System.Drawing.Point(6, 6);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(120, 59);
            this.SelectAll.TabIndex = 1;
            this.SelectAll.Text = "Select All";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // Format
            // 
            this.Format.Controls.Add(this.ColorSettings);
            this.Format.Controls.Add(this.ChangeFont);
            this.Format.Location = new System.Drawing.Point(4, 25);
            this.Format.Name = "Format";
            this.Format.Size = new System.Drawing.Size(1220, 71);
            this.Format.TabIndex = 2;
            this.Format.Text = "Format";
            this.Format.UseVisualStyleBackColor = true;
            // 
            // ColorSettings
            // 
            this.ColorSettings.Location = new System.Drawing.Point(129, 9);
            this.ColorSettings.Name = "ColorSettings";
            this.ColorSettings.Size = new System.Drawing.Size(120, 59);
            this.ColorSettings.TabIndex = 6;
            this.ColorSettings.Text = "Color Settings";
            this.ColorSettings.UseVisualStyleBackColor = true;
            this.ColorSettings.Click += new System.EventHandler(this.ColorSettings_Click);
            // 
            // ChangeFont
            // 
            this.ChangeFont.Location = new System.Drawing.Point(3, 9);
            this.ChangeFont.Name = "ChangeFont";
            this.ChangeFont.Size = new System.Drawing.Size(120, 59);
            this.ChangeFont.TabIndex = 4;
            this.ChangeFont.Text = "Font Settings";
            this.ChangeFont.UseVisualStyleBackColor = true;
            this.ChangeFont.Click += new System.EventHandler(this.ChangeFont_Click);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.Clear);
            this.Settings.Controls.Add(this.Hide);
            this.Settings.Controls.Add(this.Unhide);
            this.Settings.Controls.Add(this.OpenSecretDir);
            this.Settings.Controls.Add(this.label2);
            this.Settings.Controls.Add(this.LoggingOptions);
            this.Settings.Controls.Add(this.label1);
            this.Settings.Controls.Add(this.AutosaveOptions);
            this.Settings.Location = new System.Drawing.Point(4, 25);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(1220, 71);
            this.Settings.TabIndex = 3;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(824, 9);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(120, 59);
            this.Clear.TabIndex = 11;
            this.Clear.Text = "Clear history of changes";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Hide
            // 
            this.Hide.Location = new System.Drawing.Point(698, 9);
            this.Hide.Name = "Hide";
            this.Hide.Size = new System.Drawing.Size(120, 59);
            this.Hide.TabIndex = 10;
            this.Hide.Text = "Hide history of changes";
            this.Hide.UseVisualStyleBackColor = true;
            this.Hide.Click += new System.EventHandler(this.Hide_Click);
            // 
            // Unhide
            // 
            this.Unhide.Location = new System.Drawing.Point(572, 9);
            this.Unhide.Name = "Unhide";
            this.Unhide.Size = new System.Drawing.Size(120, 59);
            this.Unhide.TabIndex = 9;
            this.Unhide.Text = "Unhide history of changes";
            this.Unhide.UseVisualStyleBackColor = true;
            this.Unhide.Click += new System.EventHandler(this.Unhide_Click);
            // 
            // OpenSecretDir
            // 
            this.OpenSecretDir.Location = new System.Drawing.Point(446, 9);
            this.OpenSecretDir.Name = "OpenSecretDir";
            this.OpenSecretDir.Size = new System.Drawing.Size(120, 59);
            this.OpenSecretDir.TabIndex = 8;
            this.OpenSecretDir.Text = "Show history and \r\nRestore";
            this.OpenSecretDir.UseVisualStyleBackColor = true;
            this.OpenSecretDir.Click += new System.EventHandler(this.OpenSecretDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Logging frequency";
            // 
            // LoggingOptions
            // 
            this.LoggingOptions.FormattingEnabled = true;
            this.LoggingOptions.Items.AddRange(new object[] {
            "Off",
            "10 sec.",
            "30 sec.",
            "1 min.",
            "2 min.",
            "5 min.",
            "10 min."});
            this.LoggingOptions.Location = new System.Drawing.Point(213, 35);
            this.LoggingOptions.Name = "LoggingOptions";
            this.LoggingOptions.Size = new System.Drawing.Size(174, 24);
            this.LoggingOptions.TabIndex = 6;
            this.LoggingOptions.SelectedIndexChanged += new System.EventHandler(this.LoggingOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Autosave frequency";
            // 
            // AutosaveOptions
            // 
            this.AutosaveOptions.FormattingEnabled = true;
            this.AutosaveOptions.Items.AddRange(new object[] {
            "Off",
            "10 sec.",
            "30 sec.",
            "1 min.",
            "2 min.",
            "5 min.",
            "10 min."});
            this.AutosaveOptions.Location = new System.Drawing.Point(3, 35);
            this.AutosaveOptions.Name = "AutosaveOptions";
            this.AutosaveOptions.Size = new System.Drawing.Size(174, 24);
            this.AutosaveOptions.TabIndex = 0;
            this.AutosaveOptions.SelectedIndexChanged += new System.EventHandler(this.AutosaveOptions_SelectedIndexChanged);
            // 
            // Texts
            // 
            this.Texts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Texts.Location = new System.Drawing.Point(17, 119);
            this.Texts.Name = "Texts";
            this.Texts.SelectedIndex = 0;
            this.Texts.Size = new System.Drawing.Size(1220, 387);
            this.Texts.TabIndex = 1;
            this.Texts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Texts_KeyDown);
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.fontSettingsToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(165, 124);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // fontSettingsToolStripMenuItem
            // 
            this.fontSettingsToolStripMenuItem.Name = "fontSettingsToolStripMenuItem";
            this.fontSettingsToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.fontSettingsToolStripMenuItem.Text = "Font Settings";
            this.fontSettingsToolStripMenuItem.Click += new System.EventHandler(this.fontSettingsToolStripMenuItem_Click);
            // 
            // TextPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 518);
            this.Controls.Add(this.Texts);
            this.Controls.Add(this.Toolbar);
            this.Name = "TextPad";
            this.Text = "Text editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Toolbar.ResumeLayout(false);
            this.FileTab.ResumeLayout(false);
            this.Edit.ResumeLayout(false);
            this.Format.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Toolbar;
        private System.Windows.Forms.TabPage FileTab;
        private System.Windows.Forms.TabPage Edit;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button CloseTab;
        private System.Windows.Forms.Button NewTab;
        private System.Windows.Forms.Button SaveAs;
        private System.Windows.Forms.Button SaveAll;
        private System.Windows.Forms.TabControl Texts;
        private System.Windows.Forms.TabPage Format;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Paste;
        private System.Windows.Forms.Button Cut;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Button SelectAll;
        private System.Windows.Forms.Button Redo;
        private System.Windows.Forms.Button ChangeFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AutosaveOptions;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontSettingsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LoggingOptions;
        private System.Windows.Forms.Button OpenSecretDir;
        private System.Windows.Forms.Button Unhide;
        private System.Windows.Forms.Button Hide;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Info;
        private System.Windows.Forms.Button ColorSettings;
    }
}

