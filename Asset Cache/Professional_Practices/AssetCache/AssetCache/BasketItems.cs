using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssetCache.Forms;

namespace AssetCache
{
    public partial class BasketItems : UserControl
    {
        public BasketItems()
        {
            InitializeComponent();
            AssetImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public int ID { get; set; }

        public Label AssetName
        {
            get => AssetTitle;
            set => AssetTitle = value;
        }

        public Label Price
        {
            get => PriceLabel;
            set => PriceLabel = value;
        }

        public PictureBox AssetPicture
        {
            get => AssetImage;
            set => AssetImage = value;
        }

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

        private void BinIcon_Click(object sender, EventArgs e)
        {
            PacketSendType packetNumber = PacketSendType.BasketRequest;
            if (!PacketControl.packets.ContainsKey((int)packetNumber))
            {
                SendData.BasketRequest(BasketFunctions.Remove, ID);
                DateTime expireTime = DateTime.Now.AddSeconds(15);

                while (PacketControl.packets.ContainsKey((int)packetNumber))
                {
                    if (DateTime.Now >= expireTime)
                    {
                        Console.WriteLine("Waited too long");
                        break;
                    }
                }
            }
            Console.WriteLine("Loaded");
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "Basket")
                {
                    Basket temp = (Basket)Application.OpenForms[i];
                    temp.LoadBasket();
                }
            }
        }
    }
}
