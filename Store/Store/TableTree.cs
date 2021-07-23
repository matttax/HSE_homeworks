using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Store
{
    [Serializable]
    class TableTree : TreeView
    {
        // All sections' tables.
        public Dictionary<string, DataTable> Sections;
        public TableTree(Size size, Point location, AnchorStyles anchorStyles)
        {
            Size = size;
            Location = location;
            Anchor = anchorStyles;
            Sections = new Dictionary<string, DataTable>();
        }
    }
}
