using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class Store : Form
    {
        TableTree treeView = new TableTree(new Size(300, 332), new Point(23, 101), 
            AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
        public Store()
        {
            InitializeComponent();
            treeView.AfterSelect += treeView_AfterSelect;
            Controls.Add(treeView);
            ChangeAccess(false, AddCommodity, DeleteCommodity, SuperTable, EditCommodity, Delete, CSV);
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ReadOnly = true;
        }

        /// <summary>
        /// Change commodity table and make commodity controls avaliable.
        /// </summary>
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dataGridView.DataSource = treeView.Sections[e.Node.Text];
            ChangeAccess(true, AddCommodity, Delete, SuperTable);
        }

        /// <summary>
        /// Change avaliability of commodity controls.
        /// </summary>
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ChangeAccess(false, EditCommodity, DeleteCommodity);
            if (dataGridView.SelectedRows.Count == 1)
                EditCommodity.Enabled = true;
            if (dataGridView.SelectedRows.Count >= 1)
                DeleteCommodity.Enabled = true;
        }

        #region Buttons
        /// <summary>
        /// Add section to the tree or to the other section.
        /// </summary>
        private void Add_Click(object sender, EventArgs e)
        {
            // Set name.
            Name setName = new Name();
            SetDialogAndShow(setName);
            if (setName.SectionName == null)
                return;

            // Check if name is unique.
            List<TreeNode> AllSections = GetAllSections();
            foreach (var node in AllSections)
                if (setName.SectionName == node.Text)
                {
                    MessageBox.Show("Name is alredy taken");
                    return;
                }

            // Add section to the tree.
            if (treeView.SelectedNode == null)
                treeView.Nodes.Add(setName.SectionName);
            else
            {
                treeView.SelectedNode.Nodes.Add(setName.SectionName);
                dataGridView.DataSource = treeView.Sections[treeView.SelectedNode.Text];
            }

            // Link section with it's commodity table.
            DataTable dt = new DataTable();
            SetColumns(ref dt);
            treeView.Sections.Add(setName.SectionName, dt);

            // Change control access.
            treeView.SelectedNode = null;
            ChangeAccess(false, AddCommodity, SuperTable);
            CSV.Enabled = true;
        }

        /// <summary>
        /// Load store from text file.
        /// </summary>
        private void Load_Click(object sender, EventArgs e)
        {
            try
            {
                // Open text file.
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "TXT|*.TXT";
                string file = "";
                FileInfo fileInfo;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    file = ofd.FileName;
                    fileInfo = new FileInfo(file);
                    fileInfo.Attributes = FileAttributes.Normal;
                }
                if (!File.Exists(file))
                    return;

                // Restore the tree.
                List<string> allData = File.ReadAllLines(file).ToList();
                List<string> nodes = new List<string>();
                List<string> tables = new List<string>();
                foreach (string line in allData)
                    if (line != "@")
                        nodes.Add(line);
                    else break;
                for (int i = nodes.Count; i < allData.Count; i++)
                    if (allData[i] != "@")
                        tables.Add(allData[i]);
                foreach (string node in nodes)
                {
                    List<string> steps = node.Split(@"\").ToList();
                    RestorePath(steps, treeView.Nodes);
                }
                RestoreTables(tables);

                fileInfo = new FileInfo(file);
                fileInfo.Attributes |= FileAttributes.ReadOnly;
                CSV.Enabled = true;
            }
            catch
            {
                treeView.Nodes.Clear();
                treeView.Sections.Clear();
                MessageBox.Show("Corrupted file or store is already filled.");
            }
        }

        /// <summary>
        /// Save store into readonly text file.
        /// </summary>
        private void Save_Click(object sender, EventArgs e)
        {
            string allData = "";
            allData += AllNodes(treeView.Nodes);
            allData += "@\n";
            allData += AllTables();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TXT|*.txt";
            string name = "";
            if (sfd.ShowDialog() == DialogResult.OK)
                name = sfd.FileName;
            FileInfo file;
            if (File.Exists(name))
            {
                file = new FileInfo(name);
                file.Attributes = FileAttributes.Normal;
            }
            if (name == "")
                return;
            File.WriteAllText(name, allData);
            file = new FileInfo(name);
            file.Attributes |= FileAttributes.ReadOnly;
        }

        /// <summary>
        /// Remove selected section.
        /// </summary>
        private void Delete_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Nodes.Count > 0 || treeView.Sections[treeView.SelectedNode.Text].Rows.Count != 0)
                {
                    MessageBox.Show($"Section is not empty.\nIt cannot be deleted.");
                    return;
                }
                treeView.Sections.Remove(treeView.SelectedNode.Text);
                treeView.SelectedNode.Remove();

                treeView.SelectedNode = null;
                if (treeView.Sections.Count == 0)
                    CSV.Enabled = false;
                AddCommodity.Enabled = false;
            }
        }

        /// <summary>
        /// Export data into .csv file.
        /// </summary>
        private void CSV_Click(object sender, EventArgs e)
        {
            List<string> pathes = AllPathes(treeView.Nodes);
            DataTable superTable = new DataTable();
            superTable.Columns.Add("Path", typeof(string));
            SetColumns(ref superTable);

            QuantityLimit quantityLimit = new QuantityLimit();
            SetDialogAndShow(quantityLimit);
            if (!quantityLimit.OkClicked)
                return;
            foreach (string path in pathes)
            {
                string[] sections = path.Split(@"\");
                foreach (DataRow row in treeView.Sections[sections[^1]].Rows)
                    if ((uint)row[2] < quantityLimit.Limit)
                        superTable.Rows.Add(path, row[0], row[1], row[2], row[3]);
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV|*.csv";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            ToCSV(superTable, sfd.FileName);
        }

        private void AddCommodity_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                Commodity commodity = new Commodity();
                SetDialogAndShow(commodity);
                if (!commodity.OkClicked)
                    return;
                foreach (DataRow row in treeView.Sections[treeView.SelectedNode.Text].Rows)
                    if (row[1].ToString() == commodity.Articulus)
                    {
                        MessageBox.Show("Articulus is already taken");
                        return;
                    }
                treeView.Sections[treeView.SelectedNode.Text].Rows.Add(commodity.CommodityName, commodity.Articulus, commodity.Quantity, commodity.Price);
                dataGridView.DataSource = treeView.Sections[treeView.SelectedNode.Text];
            }
        }
        private void DeleteCommodity_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
                dataGridView.Rows.Remove(row);
        }
        private void EditCommodity_Click(object sender, EventArgs e)
        {
            Commodity commodity = new Commodity(dataGridView.SelectedRows[0].Cells[0].Value.ToString(),
                dataGridView.SelectedRows[0].Cells[1].Value.ToString(),
                uint.Parse(dataGridView.SelectedRows[0].Cells[2].Value.ToString()),
                uint.Parse(dataGridView.SelectedRows[0].Cells[3].Value.ToString())
                );
            SetDialogAndShow(commodity);
            if (!commodity.OkClicked)
                return;

            foreach (DataRow row in treeView.Sections[treeView.SelectedNode.Text].Rows)
                if (row[1] != dataGridView.SelectedRows[0].Cells[1].Value)
                    if (row[1].ToString() == commodity.Articulus)
                    {
                        MessageBox.Show("Articulus is already taken");
                        return;
                    }
            dataGridView.SelectedRows[0].Cells[0].Value = commodity.CommodityName;
            dataGridView.SelectedRows[0].Cells[1].Value = commodity.Articulus;
            dataGridView.SelectedRows[0].Cells[2].Value = commodity.Quantity;
            dataGridView.SelectedRows[0].Cells[3].Value = commodity.Price;
        }

        /// <summary>
        /// Build a table from all subsections of the section.
        /// </summary>
        private void SuperTable_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                DataTable superTable = new DataTable();
                SetColumns(ref superTable);
                superTable.Columns.Add("Section", typeof(string));

                foreach (DataRow row in treeView.Sections[treeView.SelectedNode.Text].Rows)
                    superTable.Rows.Add(row[0], row[1], row[2], row[3], treeView.SelectedNode.Text);
                int thisRows = superTable.Rows.Count;
                List<TreeNode> children = GetChildren(treeView.SelectedNode);
                foreach (var node in children)
                    foreach (DataRow row in treeView.Sections[node.Text].Rows)
                        superTable.Rows.Add(row[0], row[1], row[2], row[3], node.Text);
                dataGridView.DataSource = superTable;

                for (int i = thisRows; i < superTable.Rows.Count; i++)
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }
        #endregion


        /// <summary>
        /// Restore tree from text.
        /// </summary>
        private void RestorePath(List<string> steps, TreeNodeCollection nodes)
        {
            if (nodes.ContainsKey(steps[0]))
            {
                string step0 = steps[0];
                steps.RemoveAt(0);
                RestorePath(steps, nodes[step0].Nodes);
            }
            else
            {
                nodes.Add(steps[0], steps[0]);

                if (steps.Count > 1)
                {
                    string step0 = steps[0];
                    steps.RemoveAt(0);
                    RestorePath(steps, nodes[step0].Nodes);
                }
            }
        }

        /// <summary>
        /// Restore commodity tables from text.
        /// </summary>
        private void RestoreTables(List<string> tables)
        {
            string last = "";
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].StartsWith("table: "))
                {
                    DataTable dt = new DataTable();
                    SetColumns(ref dt);
                    last = tables[i].Replace("table: ", "");
                    treeView.Sections.Add(tables[i].Replace("table: ", ""), dt);
                }
                else
                {
                    string[] data = tables[i].Split(@"\");
                    if (Commodity.NameIsValid(data[0]) && Commodity.ArticulusIsValid(data[1]) &&
                        uint.TryParse(data[2], out uint price) && uint.TryParse(data[3], out uint quantity))
                        treeView.Sections[last].Rows.Add(data[0], data[1], data[2], data[3]);
                    else throw new DataException();
                }
            }

            // Проверка на соответствие секций ранее построенного дерева с данными о таблицах.
            if (treeView.GetNodeCount(true) != treeView.Sections.Keys.Count)
                throw new DataException();
            List<TreeNode> nodes = GetAllSections();
            foreach (TreeNode node in nodes)
                if (!treeView.Sections.Keys.Contains(node.Text))
                    throw new DataException();
            for (int i = 0; i < nodes.Count; i++)
                for (int j = 0; j < nodes.Count; j++)
                    if (i != j)
                        if (nodes[i] == nodes[j])
                            throw new DataException();

        }

        /// <summary>
        /// Make some buttons avaliable.
        /// </summary>
        void ChangeAccess(bool enable, params Button[] buttons) => Array.ForEach(buttons, b => b.Enabled = enable);

        /// <summary>
        /// Set dialog parameters and show it.
        /// </summary>
        private void SetDialogAndShow<T>(T form) where T : Form
        {
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowDialog();
        }

        private static void SetColumns(ref DataTable dt)
        {
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Article number", typeof(string));
            dt.Columns.Add("Quantity", typeof(uint));
            dt.Columns.Add("Price", typeof(uint));
        }

        /// <summary>
        /// Write given DataTable into .csv file
        /// </summary>
        public static void ToCSV(DataTable dt, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false); 
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                    sw.Write(",");
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = string.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else sw.Write(dr[i].ToString());
                    }
                    if (i < dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }


        private List<TreeNode> GetAllSections()
        {
            List<TreeNode> AllSections = new List<TreeNode>();
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                AllSections.AddRange(GetChildren(treeView.Nodes[i]));
                AllSections.Add(treeView.Nodes[i]);
            }
            return AllSections;
        }

        /// <summary>
        /// Get data from all commodity tables in text format.
        /// </summary>
        private string AllTables()
        {
            string tables = "";
            foreach (string table in treeView.Sections.Keys)
            {
                tables += "table: " + table + "\n";
                foreach (DataRow dataRow in treeView.Sections[table].Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                        tables += item.ToString() + @"\";
                    tables += "\n";
                }
            }
            return tables;
        }

        /// <summary>
        /// Get all nodes in text format.
        /// </summary>
        private string AllNodes(TreeNodeCollection nodes)
        {
            string allNodes = "";
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                    allNodes += node.FullPath + "\n";
                else
                    allNodes += AllNodes(node.Nodes);
            }
            return allNodes;
        }

        /// <summary>
        /// Get all section pathes.
        /// </summary>
        private List<string> AllPathes(TreeNodeCollection nodes)
        {
            List<string> pathes = new List<string>();
            foreach (TreeNode node in nodes)
            {
                pathes.Add(node.FullPath);
                if (node.Nodes.Count > 0)
                    pathes.AddRange(AllPathes(node.Nodes));
            }
            return pathes;
        }

        /// <summary>
        /// Get all node's children.
        /// </summary>
        public List<TreeNode> GetChildren(TreeNode Parent) =>
            Parent.Nodes.Cast<TreeNode>().Concat(Parent.Nodes.Cast<TreeNode>().SelectMany(GetChildren)).ToList();
    }
}
