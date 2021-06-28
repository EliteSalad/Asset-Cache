namespace AssetCache
{
    partial class InboxAccount
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AccountTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.ContactAvatar = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StatusPicture = new System.Windows.Forms.PictureBox();
            this.UserName = new System.Windows.Forms.Label();
            this.RecentMessage = new System.Windows.Forms.Label();
            this.transparentPanel1 = new AssetCache.Classes.TransparentPanel();
            this.AccountTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContactAvatar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountTablePanel
            // 
            this.AccountTablePanel.ColumnCount = 2;
            this.AccountTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.AccountTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1130F));
            this.AccountTablePanel.Controls.Add(this.ContactAvatar, 0, 0);
            this.AccountTablePanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.AccountTablePanel.Location = new System.Drawing.Point(0, 0);
            this.AccountTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.AccountTablePanel.Name = "AccountTablePanel";
            this.AccountTablePanel.RowCount = 1;
            this.AccountTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.AccountTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AccountTablePanel.Size = new System.Drawing.Size(1260, 130);
            this.AccountTablePanel.TabIndex = 0;
            // 
            // ContactAvatar
            // 
            this.ContactAvatar.BackgroundImage = global::AssetCache.Properties.Resources.Logo_100x100_png___Asset_Cache_v1_0;
            this.ContactAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContactAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContactAvatar.Location = new System.Drawing.Point(3, 3);
            this.ContactAvatar.Name = "ContactAvatar";
            this.ContactAvatar.Size = new System.Drawing.Size(124, 124);
            this.ContactAvatar.TabIndex = 37;
            this.ContactAvatar.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1104F));
            this.tableLayoutPanel1.Controls.Add(this.StatusPicture, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UserName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RecentMessage, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(133, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1124, 124);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // StatusPicture
            // 
            this.StatusPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusPicture.BackgroundImage = global::AssetCache.Properties.Resources.Online;
            this.StatusPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StatusPicture.InitialImage = global::AssetCache.Properties.Resources.Offline;
            this.StatusPicture.Location = new System.Drawing.Point(5, 27);
            this.StatusPicture.Margin = new System.Windows.Forms.Padding(0);
            this.StatusPicture.Name = "StatusPicture";
            this.StatusPicture.Size = new System.Drawing.Size(10, 10);
            this.StatusPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StatusPicture.TabIndex = 40;
            this.StatusPicture.TabStop = false;
            // 
            // UserName
            // 
            this.UserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.Color.White;
            this.UserName.Location = new System.Drawing.Point(20, 5);
            this.UserName.Margin = new System.Windows.Forms.Padding(0);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(248, 54);
            this.UserName.TabIndex = 41;
            this.UserName.Text = "UserName";
            this.UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RecentMessage
            // 
            this.RecentMessage.AutoSize = true;
            this.RecentMessage.ForeColor = System.Drawing.Color.White;
            this.RecentMessage.Location = new System.Drawing.Point(20, 65);
            this.RecentMessage.Margin = new System.Windows.Forms.Padding(0);
            this.RecentMessage.Name = "RecentMessage";
            this.RecentMessage.Size = new System.Drawing.Size(76, 25);
            this.RecentMessage.TabIndex = 42;
            this.RecentMessage.Text = "hi there";
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Size = new System.Drawing.Size(1260, 130);
            this.transparentPanel1.TabIndex = 1;
            this.transparentPanel1.Click += new System.EventHandler(this.transparentPanel1_Click);
            this.transparentPanel1.MouseLeave += new System.EventHandler(this.transparentPanel1_MouseLeave);
            this.transparentPanel1.MouseHover += new System.EventHandler(this.transparentPanel1_MouseHover);
            // 
            // InboxAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.transparentPanel1);
            this.Controls.Add(this.AccountTablePanel);
            this.Name = "InboxAccount";
            this.Size = new System.Drawing.Size(1260, 130);
            this.AccountTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContactAvatar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel AccountTablePanel;
        private System.Windows.Forms.PictureBox ContactAvatar;
        private Classes.TransparentPanel transparentPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox StatusPicture;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label RecentMessage;
    }
}
