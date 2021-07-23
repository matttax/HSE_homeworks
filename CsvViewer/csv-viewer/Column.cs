using System.Drawing;


namespace csv_viewer
{
    class Column
    {
        public bool LastSortAscending;
        public Color Color;
        public Column(bool lastSortAscending, Color color)
        {
            LastSortAscending = lastSortAscending;
            Color = color;
        }
    }
}
