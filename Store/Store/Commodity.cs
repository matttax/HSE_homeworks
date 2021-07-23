using System;
using System.Windows.Forms;

namespace Store
{
    public partial class Commodity : Form
    {
        public bool OkClicked { private set; get; }

        public string CommodityName { private set; get; }
        public string Articulus { private set; get; }
        public uint Quantity { get => quantity; }
        public uint Price { get => price; }
        uint quantity, price;

        bool NameIsOK = false;
        bool QuantityIsOK = false;
        bool PriceIsOK = false;
        bool ArticulusIsOK = false;
        public Commodity()
        {
            InitializeComponent();
            Ok.Enabled = false;
        }
        public Commodity(string Name, string Articulus, uint Quantity, uint Price)
        {
            InitializeComponent();
            NameBox.Text = Name;
            ArticulusBox.Text = Articulus;
            QuantityBox.Text = Quantity.ToString();
            PriceBox.Text = Price.ToString();
            Ok.Enabled = false;
        }
        private void ArticulusInfo_Click(object sender, EventArgs e) =>
            MessageBox.Show("Format:\nXX-XXXX-XXXX\nX - numbers");

        private void NameInfo_Click(object sender, EventArgs e) =>
            MessageBox.Show(@"Numbers, spaces and Latin\Cyrillic symbols");

        /// <summary>
        /// Save and close.
        /// </summary>
        private void Ok_Click(object sender, EventArgs e)
        {
            OkClicked = true;
            Articulus = ArticulusBox.Text;
            CommodityName = NameBox.Text;
            Close();
        }

        private void NameBox_TextChanged(object sender, EventArgs e) =>
            UpdateTicks(ref NameLabel, NameIsOK = NameIsValid(NameBox.Text));

        private void ArticulusBox_TextChanged(object sender, EventArgs e) =>
            UpdateTicks(ref ArticulusLabel, ArticulusIsOK = ArticulusIsValid(ArticulusBox.Text));

        private void QuantityBox_TextChanged(object sender, EventArgs e) =>
            UpdateTicks(ref QuantityLabel, QuantityIsOK = uint.TryParse(QuantityBox.Text, out quantity));

        private void PriceBox_TextChanged(object sender, EventArgs e) =>
            UpdateTicks(ref PriceLabel, PriceIsOK = uint.TryParse(PriceBox.Text, out price));

        /// <summary>
        /// Update info and change avaliability of OK button.
        /// </summary>
        void UpdateTicks(ref Label label, bool isOK)
        {
            label.Text = isOK ? "✓" : "X";
            if (NameIsOK && ArticulusIsOK && QuantityIsOK && PriceIsOK)
                Ok.Enabled = true;
            else Ok.Enabled = false;
        }

        /// <summary>
        /// Check if name contains numbers, spaces and Latin\Cyrillic symbols.
        /// </summary>
        public static bool NameIsValid(string name)
        {
            bool normalName = name.Trim() == "" ? false : true;
            foreach (char sym in name.ToLower())
                if (!"1234567890qwertyuiopasdfghjklzxcvbnmйцукенгшщзхъфывапролджэячсмитьбюё ".Contains(sym))
                    normalName = false;
            return normalName;
        }

        /// <summary>
        /// Check if articulus is correct.
        /// </summary>
        public static bool ArticulusIsValid(string articulus)
        {
            string[] subArticulus = articulus.Split('-');
            bool ArticulusIsOK = false;
            if (subArticulus.Length == 3)
                if (uint.TryParse(subArticulus[0], out uint a0) && a0 < 100 &&
                    uint.TryParse(subArticulus[1], out uint a1) && a1 < 10000 &&
                    uint.TryParse(subArticulus[2], out uint a2) && a2 < 10000)
                    ArticulusIsOK = true;
            return ArticulusIsOK;
        }
    }
}
