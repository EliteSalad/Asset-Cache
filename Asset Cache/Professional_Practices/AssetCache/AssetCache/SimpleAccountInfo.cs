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
    public partial class SimpleAccountInfo : UserControl
    {
        public SimpleAccountInfo()
        {
            InitializeComponent();
        }

        public Label AccountName
        {
            get => UserName;
            set => UserName = value;
        }

        public PictureBox AvatarImage
        {
            get => Avatar;
            set => Avatar = value;
        }

        public PictureBox status
        {
            get => Status;
            set => Status = value;
        }

        private void transparentPanel1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
        }

        private void transparentPanel1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        }

        private void transparentPanel1_Click(object sender, EventArgs e)
        {
            Messenger messenger = (Messenger)this.ParentForm;
            string inList = this.Name.Substring(this.Name.Length - 5);
            messenger.OpenConversation(Convert.ToInt32(inList));     
        }
    }
}
