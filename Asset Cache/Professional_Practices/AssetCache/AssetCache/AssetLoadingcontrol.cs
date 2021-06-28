using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetCache
{
    public partial class AssetLoadingcontrol : UserControl
    {
        public AssetLoadingcontrol()
        {
            InitializeComponent();
            PictureAsset.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public Label CompanyName
        {
            get => CompanyLabel;
            set => CompanyLabel = value;
        }

        public Label AssetName
        {
            get => AssetNameLabel;
            set => AssetNameLabel = value;
        }

        public Label Price
        {
            get => PriceLabel;
            set => PriceLabel = value;
        }

        public PictureBox AssetPicture
        {
            get => PictureAsset;
            set => PictureAsset = value;
        }

        public int ID { get; set; }

        private void transparentPanel1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
        }

        private void transparentPanel1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
        }

        private void transparentPanel1_Click(object sender, EventArgs e)
        {
            HomePage.instance.LoadAsset(ID);
        }
    }
}
