using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace texte
{
    public partial class TextPad : Form
    {
        public TextPad()
        {
            InitializeComponent();
            Texts.Selected += NewTabSelected;
        }
        // Link page and text in it.
        Dictionary<TabPage, RicherTextBox> textsInTabs = new Dictionary<TabPage, RicherTextBox>();

        // Frequency of autosave or logging.
        string[] Frequency = { "Off", "10 sec.", "30 sec.", "1 min.", "2 min.", "5 min.", "10 min." };

        // For undo/redo options.
        bool LastClickUndo = false;
        bool LastClickRedo = false;
        bool UndoChange = false;

        // Colors.
        public Color backgroundColor, toolbarColor, rtbColor;

        /// <summary>
        /// Restore last settings or start from scratch.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Names == null || Properties.Settings.Default.Names.Count == 0)
                StartFirstTime();
            else
                for (int i = 0; i < Properties.Settings.Default.Names.Count; i++)
                    StartAndLoad(Properties.Settings.Default.Names[i], Properties.Settings.Default.Texts[i]);
        }

        /// <summary>
        /// Save current settings.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AutosaveOptions.Text != "" && AutosaveOptions.Text != null)
                Properties.Settings.Default.AutosaveTime = AutosaveOptions.Text;
            else Properties.Settings.Default.AutosaveTime = "Off";

            if (LoggingOptions.Text != "" && LoggingOptions.Text != null)
                Properties.Settings.Default.LoggingTime = LoggingOptions.Text;
            else Properties.Settings.Default.LoggingTime = "Off";

            Properties.Settings.Default.rtbColor = rtbColor;
            Properties.Settings.Default.backColor = backgroundColor;
            Properties.Settings.Default.toolbarColor = toolbarColor;

            Properties.Settings.Default.Names = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.Texts = new System.Collections.Specialized.StringCollection();
            foreach (TabPage tab in textsInTabs.Keys)
            {
                if (textsInTabs[tab].Path == null)
                {
                    Properties.Settings.Default.Names.Add(tab.Text);
                    Properties.Settings.Default.Texts.Add(textsInTabs[tab].Text);
                }
                else
                    File.WriteAllText(textsInTabs[tab].Path, textsInTabs[tab].Text);
            }
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Change autosave  and logging option for the new tab.
        /// </summary>
        private void NewTabSelected(object sender, EventArgs e)
        {
            try
            {
                TabControl tabControl = sender as TabControl;
                AutosaveOptions.Text = textsInTabs[tabControl.SelectedTab].Path == null ?
                    "" : textsInTabs[tabControl.SelectedTab].Autosave;
                LoggingOptions.Text = textsInTabs[tabControl.SelectedTab].Path == null ?
                    "" : textsInTabs[tabControl.SelectedTab].Logging;
            }
            catch { AutosaveOptions.Text = ""; }
        }

        /// <summary>
        /// Change undo and redo.
        /// </summary>
        private void TextChange(object sender, EventArgs e)
        {
            UndoChange = LastClickUndo ? true : false;
            LastClickUndo = false;
            if (!UndoChange && !LastClickRedo)
                textsInTabs[Texts.SelectedTab].RedoChanges.Clear();
            textsInTabs[Texts.SelectedTab].UndoChanges.Push(textsInTabs[Texts.SelectedTab].Text);
        }


        #region File
        /// <summary>
        /// Open file via OpenFileDialog.
        /// </summary>
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.txt";
            ofd.Filter = "txt files|*.txt|rtf files|*.rtf";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                TabPage newTabPage = new TabPage();
                RicherTextBox newrbox = new RicherTextBox();
                SetTextBoxParams(newTabPage.Size, ref newrbox);
                newTabPage.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                newrbox.Text = File.ReadAllText(ofd.FileName);
                newrbox.Path = ofd.FileName;
                newrbox.DefaultText = newrbox.Text;
                if (Directory.Exists(Path.GetDirectoryName(newrbox.Path) + Path.DirectorySeparatorChar + Path.GetFileName(newrbox.Path) + "_Versions"))
                    newrbox.SecretFolder = Path.GetDirectoryName(newrbox.Path) + Path.DirectorySeparatorChar + Path.GetFileName(newrbox.Path) + "_Versions";
                Add(newTabPage, newrbox);
                Texts.SelectedTab = newTabPage;
                AutosaveOptions.Text = Properties.Settings.Default.AutosaveTime;
                LoggingOptions.Text = Properties.Settings.Default.LoggingTime;
            }
        }

        /// <summary>
        /// Close tab via CloseTabDialog.
        /// </summary>
        private void CloseTab_Click(object sender, EventArgs e)
        {
            if (textsInTabs.Count != 0)
            {
                DialogResult closeTab = MessageBox.Show("Close tab without saving?", "Close tab", MessageBoxButtons.YesNoCancel);
                switch (closeTab)
                {
                    case DialogResult.Yes:
                        textsInTabs.Remove(Texts.SelectedTab);
                        Texts.TabPages.Remove(Texts.SelectedTab);
                        break;
                    case DialogResult.No:
                        if (textsInTabs[Texts.SelectedTab].Path == null)
                            if (!SaveFileAs())
                                return;
                            else
                                File.WriteAllText(textsInTabs[Texts.SelectedTab].Path, textsInTabs[Texts.SelectedTab].Text);
                        break;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e) => SaveFile();
        private void SaveAs_Click(object sender, EventArgs e) => SaveFileAs();
        private void SaveAll_Click(object sender, EventArgs e) => SaveAllFiles();
        private void NewTab_Click(object sender, EventArgs e) => CreateNewTab();
        private void Info_Click(object sender, EventArgs e) =>
            MessageBox.Show("Ctrl+N = New Tab\nCtrl+S = Save File\nCtrl + O = Close Form\nCtrl+A = Save All Files\n" +
                            "Ctrl+Z = Undo\nCtrl+Shift+Z = Redo");
        #endregion

        #region Edit
        private void SelectAll_Click(object sender, EventArgs e)
        {
            if (Texts.TabCount != 0)
            {
                textsInTabs[Texts.SelectedTab].SelectAll();
                textsInTabs[Texts.SelectedTab].Focus();
            }
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            if (Texts.TabCount != 0)
                textsInTabs[Texts.SelectedTab].Copy();
        }
        private void Cut_Click(object sender, EventArgs e)
        {
            if (Texts.TabCount != 0)
                textsInTabs[Texts.SelectedTab].Cut();
        }
        private void Paste_Click(object sender, EventArgs e)
        {
            if (Texts.TabCount != 0)
                textsInTabs[Texts.SelectedTab].Paste();
        }

        /// <summary>
        /// Pop the last version of text from undo changes stack.
        /// </summary>
        private void Undo_Click(object sender, EventArgs e)
        {
            try
            {
                textsInTabs[Texts.SelectedTab].RedoChanges.Push(textsInTabs[Texts.SelectedTab].Text);
                while (textsInTabs[Texts.SelectedTab].Text == textsInTabs[Texts.SelectedTab].UndoChanges.Peek())
                {
                    textsInTabs[Texts.SelectedTab].UndoChanges.Pop();
                }
                LastClickRedo = false;
                LastClickUndo = true;
                textsInTabs[Texts.SelectedTab].Text = textsInTabs[Texts.SelectedTab].UndoChanges.Peek();
            }
            catch
            {
                if (Texts.TabCount != 0)
                    textsInTabs[Texts.SelectedTab].Text = textsInTabs[Texts.SelectedTab].DefaultText;
            }
        }

        /// <summary>
        /// Pop the last version of text from redo changes stack.
        /// </summary>
        private void Redo_Click(object sender, EventArgs e)
        {
            try
            {
                while (textsInTabs[Texts.SelectedTab].Text == textsInTabs[Texts.SelectedTab].RedoChanges.Peek())
                    textsInTabs[Texts.SelectedTab].RedoChanges.Pop();
                LastClickRedo = true;
                LastClickUndo = false;
                textsInTabs[Texts.SelectedTab].Text = textsInTabs[Texts.SelectedTab].RedoChanges.Peek();
            }
            catch { }
        }
        #endregion

        #region Format

        /// <summary>
        /// Font settings.
        /// </summary>
        private void ChangeFont_Click(object sender, EventArgs e)
        {
            try
            {
                FontDialog fd = new FontDialog();
                if (fd.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(textsInTabs[Texts.SelectedTab].Text))
                    textsInTabs[Texts.SelectedTab].SelectionFont = fd.Font;
            }
            catch { MessageBox.Show("Something's gone wrong"); }
        }

        /// <summary>
        /// Color settings for textbox, toolbar and form background.
        /// </summary>
        private void ColorSettings_Click(object sender, EventArgs e)
        {
            ColorSettings setColors = new ColorSettings(backgroundColor, toolbarColor, rtbColor);
            SetDialogParams(ref setColors);
            toolbarColor = setColors.Toolbar;
            rtbColor = setColors.RTB;
            backgroundColor = BackColor = setColors.Background;
            foreach (TabPage tabPage in Toolbar.TabPages)
            {
                Toolbar.SelectedTab = tabPage;
                Toolbar.SelectedTab.BackColor = setColors.Toolbar;
            }
            foreach (TabPage tabPage in Texts.TabPages)
                textsInTabs[tabPage].BackColor = setColors.RTB;
        }
        #endregion

        #region Settings
        /// <summary>
        /// Set autosave options.
        /// </summary>
        private void AutosaveOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AutosaveOptions.Text == "")
                    return;
                if (File.Exists(textsInTabs[Texts.SelectedTab].Path))
                {
                    textsInTabs[Texts.SelectedTab].AutosaveTimer = new Timer();
                    if (AutosaveOptions.Text == "Off")
                    {
                        textsInTabs[Texts.SelectedTab].AutosaveTimer = null;
                        return;
                    }
                    int interval = TimerOption(AutosaveOptions.Text);
                    textsInTabs[Texts.SelectedTab].AutosaveTimer.Interval = interval;
                    textsInTabs[Texts.SelectedTab].Autosave =
                        interval > 30000 ? $"{interval / 60000} min." : $"{interval / 1000} sec.";
                    textsInTabs[Texts.SelectedTab].AutosaveTimer.Tick += AutosaveTick;
                    textsInTabs[Texts.SelectedTab].AutosaveTimer.Start();
                }
                else if (textsInTabs[Texts.SelectedTab].Path == null)
                    throw new ArgumentNullException();
            }
            catch
            {
                MessageBox.Show("Save File at first");
                AutosaveOptions.Items.Clear();
                foreach (string option in Frequency)
                    AutosaveOptions.Items.Add(option);
            }
        }
        private void AutosaveTick(object sender, EventArgs e)
        {
            foreach (RicherTextBox rtb in textsInTabs.Values)
                if (rtb.AutosaveTimer == sender as Timer)
                {
                    File.WriteAllText(rtb.Path, rtb.Text);
                    break;
                }
        }

        /// <summary>
        /// Set logging options.
        /// </summary>
        private void LoggingOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Журналирование.

            try
            {
                if (LoggingOptions.Text == "")
                    return;
                if (File.Exists(textsInTabs[Texts.SelectedTab].Path))
                {
                    textsInTabs[Texts.SelectedTab].LoggingTimer = new Timer();
                    if (LoggingOptions.Text == "Off")
                    {
                        textsInTabs[Texts.SelectedTab].LoggingTimer = null;
                        return;
                    }
                    textsInTabs[Texts.SelectedTab].SecretFolder = Path.GetDirectoryName(textsInTabs[Texts.SelectedTab].Path) + Path.DirectorySeparatorChar + Path.GetFileName(textsInTabs[Texts.SelectedTab].Path) + "_Versions";

                    // Скрытая папка для хранения версий.
                    DirectoryInfo di = Directory.CreateDirectory(textsInTabs[Texts.SelectedTab].SecretFolder);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                    int interval = TimerOption(LoggingOptions.Text);
                    textsInTabs[Texts.SelectedTab].LoggingTimer.Interval = interval;
                    textsInTabs[Texts.SelectedTab].Logging =
                        interval > 30000 ? $"{interval / 60000} min." : $"{interval / 1000} sec.";
                    textsInTabs[Texts.SelectedTab].LoggingTimer.Tick += LoggingTick;
                    textsInTabs[Texts.SelectedTab].LoggingTimer.Start();
                }
                else if (textsInTabs[Texts.SelectedTab].Path == null)
                    throw new ArgumentNullException();
            }
            catch
            {
                MessageBox.Show("Save File at first");
                LoggingOptions.Items.Clear();
                foreach (string option in Frequency)
                    LoggingOptions.Items.Add(option);
            }
        }
        private void LoggingTick(object sender, EventArgs e)
        {
            foreach (RicherTextBox rtb in textsInTabs.Values)
                if (rtb.LoggingTimer == sender as Timer)
                {
                    File.WriteAllText(rtb.SecretFolder + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(rtb.Path) +
                        "_" + DateTime.Now.ToString().Replace(" ", "_").Replace(":", "").Replace(".", "") +
                        Path.GetExtension(rtb.Path), rtb.Text);
                    break;
                }
        }

        /// <summary>
        /// Open secret directory with log files.
        /// </summary>
        private void OpenSecretDir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(textsInTabs[Texts.SelectedTab].SecretFolder))
                {
                    MessageBox.Show("This file was never logged");
                    return;
                }
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = textsInTabs[Texts.SelectedTab].SecretFolder;

                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
                    textsInTabs[Texts.SelectedTab].Text = File.ReadAllText(ofd.FileName);
            }
            catch { }
        }

        /// <summary>
        /// Unhide directory with log files.
        /// </summary>
        private void Unhide_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(textsInTabs[Texts.SelectedTab].SecretFolder);
                di.Attributes = FileAttributes.Normal;
                MessageBox.Show(textsInTabs[Texts.SelectedTab].SecretFolder);
            }
            catch { }
        }

        /// <summary>
        /// Hide directory with log files.
        /// </summary>
        private void Hide_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(textsInTabs[Texts.SelectedTab].SecretFolder);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            catch { }
        }

        /// <summary>
        /// Clear directory with log files.
        /// </summary>
        private void Clear_Click(object sender, EventArgs e)
        {
            try { Array.ForEach(Directory.GetFiles(textsInTabs[Texts.SelectedTab].SecretFolder), File.Delete); }
            catch { }
        }
        #endregion

        #region Context menu
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) => SelectAll_Click(sender, e);
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => Copy_Click(sender, e);
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => Paste_Click(sender, e);
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => Cut_Click(sender, e);
        private void fontSettingsToolStripMenuItem_Click(object sender, EventArgs e) => ChangeFont_Click(sender, e);
        #endregion

        #region Hotkeys
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
                CreateNewTab();
            if (e.Control && e.KeyCode == Keys.S)
                SaveFile();
            if (e.Control && e.KeyCode == Keys.O)
                Close();
            if (e.Control && e.KeyCode == Keys.A)
                SaveAllFiles();
            if (e.KeyCode == Keys.Z && e.Modifiers == (Keys.Control | Keys.Shift))
                Redo_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Z)
                Undo_Click(sender, e);

        }
        private void Toolbar_KeyDown(object sender, KeyEventArgs e) => Form1_KeyDown(sender, e);
        private void Texts_KeyDown(object sender, KeyEventArgs e) => Form1_KeyDown(sender, e);
        #endregion

        /// <summary>
        /// Load default settings.
        /// </summary>
        private void StartFirstTime()
        {
            TabPage newTabPage = new TabPage();
            RicherTextBox newrbox = new RicherTextBox();
            newTabPage.Text = "NewFile1";
            SetTextBoxParams(newTabPage.Size, ref newrbox);
            SetColors();
            foreach (TabPage tabPage in Toolbar.TabPages)
            {
                Toolbar.SelectedTab = tabPage;
                Toolbar.SelectedTab.BackColor = Properties.Settings.Default.toolbarColor;
            }
            Toolbar.SelectedTab = FileTab;
            Add(newTabPage, newrbox);
        }

        /// <summary>
        /// Load old settings.
        /// </summary>
        private void StartAndLoad(string name, string text)
        {
            TabPage newTabPage = new TabPage();
            RicherTextBox rbox = new RicherTextBox();
            newTabPage.Text = name;
            rbox.Text = text;
            SetTextBoxParams(newTabPage.Size, ref rbox);
            SetColors();
            foreach (TabPage tabPage in Toolbar.TabPages)
            {
                Toolbar.SelectedTab = tabPage;
                Toolbar.SelectedTab.BackColor = Properties.Settings.Default.toolbarColor;
            }
            Toolbar.SelectedTab = FileTab;
            Add(newTabPage, rbox);
        }

        /// <summary>
        /// Set default parameters for RicherTextBox.
        /// </summary>
        private void SetTextBoxParams(Size size, ref RicherTextBox newrbox)
        {
            newrbox.Size = size;
            newrbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            newrbox.TextChanged += TextChange;
            newrbox.AcceptsTab = true;
            newrbox.ContextMenuStrip = cms;
            newrbox.BackColor = Properties.Settings.Default.rtbColor;
        }
        private void SetColors()
        {
            toolbarColor = Properties.Settings.Default.toolbarColor;
            rtbColor = Properties.Settings.Default.rtbColor;
            BackColor = backgroundColor = Properties.Settings.Default.backColor;
        }

        /// <summary>
        /// Try to save file in it's directory.
        /// </summary>
        private void SaveFile()
        {
            try
            {
                if (textsInTabs[Texts.SelectedTab].Path == null)
                    SaveFileAs();
                else File.WriteAllText(textsInTabs[Texts.SelectedTab].Path, textsInTabs[Texts.SelectedTab].Text);
            }
            catch { MessageBox.Show("File does not exist"); }
        }

        /// <summary>
        /// Try to save file in a new directory.
        /// </summary>
        /// <returns> 1 if file is saved, 0 if not. </returns>
        private bool SaveFileAs()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "txt";
                sfd.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf*)|*.rtf";
                if (Texts.TabCount != 0)
                    sfd.FileName = Texts.SelectedTab.Text;
                else return false;
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
                {
                    File.WriteAllText(sfd.FileName, textsInTabs[Texts.SelectedTab].Text);
                    textsInTabs[Texts.SelectedTab].Path = sfd.FileName;
                    Texts.SelectedTab.Text = Path.GetFileNameWithoutExtension(sfd.FileName);
                    return true;
                }
                else throw new ArgumentNullException();
            }
            catch
            {
                MessageBox.Show("File is not saved");
                return false;
            }
        }
        private void CreateNewTab()
        {
            Name getName = new Name();
            SetDialogParams(ref getName);
            if (getName.FileName == null)
                return;
            TabPage newTabPage = new TabPage();
            RicherTextBox newrbox = new RicherTextBox();
            newTabPage.Text = getName.FileName;
            SetTextBoxParams(newTabPage.Size, ref newrbox);
            Add(newTabPage, newrbox);
        }

        /// <summary>
        /// Add TabPage and RicherTextBox to all collections.
        /// </summary>
        private void Add(TabPage newTabPage, RicherTextBox newrbox)
        {
            textsInTabs.Add(newTabPage, newrbox);
            newTabPage.Controls.Add(newrbox);
            Texts.TabPages.Add(newTabPage);
        }

        /// <summary>
        /// Set dialog parameters and show it.
        /// </summary>
        private void SetDialogParams<T>(ref T form) where T : Form
        {
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowDialog();
        }

        /// <summary>
        /// Determine timer interval.
        /// </summary>
        /// <returns> Timer interval. </returns>
        private int TimerOption(string option)
        {
            switch (option)
            {
                case "10 sec.": return 10000;
                case "30 sec.": return 30000;
                case "1 min.": return 60000;
                case "2 min.": return 120000;
                case "5 min.": return 300000;
                default: return 600000;
            }
        }

        /// <summary>
        /// Save all saveable files.
        /// </summary>
        private void SaveAllFiles()
        {
            foreach (RicherTextBox rbox in textsInTabs.Values)
                if (rbox.Path != null)
                    File.WriteAllText(rbox.Path, rbox.Text);
        }
    }
}