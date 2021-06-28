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
    public partial class InboxAccount : UserControl
    {
        public InboxAccount()
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
            get => ContactAvatar;
            set => ContactAvatar = value;
        }

        public Label RecentMessageBox
        {
            get => RecentMessage;
            set => RecentMessage = value;
        }

        public PictureBox status
        {
            get => StatusPicture;
            set => StatusPicture = value;
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
            Messenger messenger = (Messenger)ParentForm;
            messenger.Conversation(this, e);
        }
    }
}
