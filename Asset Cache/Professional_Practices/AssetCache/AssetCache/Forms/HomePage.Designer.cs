using System;
using System.Drawing;

namespace AssetCache
{
    partial class HomePage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.PageTitle = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.InboxButton = new System.Windows.Forms.PictureBox();
            this.SubmitAssetBtn = new System.Windows.Forms.PictureBox();
            this.AccountBtn = new System.Windows.Forms.PictureBox();
            this.searchBTN = new System.Windows.Forms.PictureBox();
            this.basketBtn = new System.Windows.Forms.PictureBox();
            this.vfxBtn = new System.Windows.Forms.PictureBox();
            this.audioBtn = new System.Windows.Forms.PictureBox();
            this.homeBtn = new System.Windows.Forms.PictureBox();
            this.threeDBtn = new System.Windows.Forms.PictureBox();
            this.twoDBtn = new System.Windows.Forms.PictureBox();
            this.LoadingImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.assetLoadingcontrol7 = new AssetCache.AssetLoadingcontrol();
            this.assetLoadingcontrol6 = new AssetCache.AssetLoadingcontrol();
            this.assetLoadingcontrol5 = new AssetCache.AssetLoadingcontrol();
            this.assetLoadingcontrol4 = new AssetCache.AssetLoadingcontrol();
            this.assetLoadingcontrol3 = new AssetCache.AssetLoadingcontrol();
            this.assetLoadingcontrol2 = new AssetCache.AssetLoadingcontrol();
            this.assetLoadingcontrol1 = new AssetCache.AssetLoadingcontrol();
            this.assetLoadingcontrol0 = new AssetCache.AssetLoadingcontrol();
            this.BackPageButton = new System.Windows.Forms.Button();
            this.ForwardPageButton = new System.Windows.Forms.Button();
            this.PageNumber = new System.Windows.Forms.Label();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InboxButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubmitAssetBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basketBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vfxBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeDBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoDBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageTitle
            // 
            this.PageTitle.AutoSize = true;
            this.PageTitle.BackColor = System.Drawing.Color.Transparent;
            this.PageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PageTitle.Location = new System.Drawing.Point(149, 40);
            this.PageTitle.Name = "PageTitle";
            this.PageTitle.Size = new System.Drawing.Size(177, 64);
            this.PageTitle.TabIndex = 1;
            this.PageTitle.Text = "Home";
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchBox.Location = new System.Drawing.Point(104, 652);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(524, 29);
            this.searchBox.TabIndex = 26;
            this.searchBox.Text = "Search...";
            this.searchBox.Click += new System.EventHandler(this.searchBox_Click);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputBox_KeyPress);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MenuPanel.Controls.Add(this.InboxButton);
            this.MenuPanel.Controls.Add(this.SubmitAssetBtn);
            this.MenuPanel.Controls.Add(this.AccountBtn);
            this.MenuPanel.Controls.Add(this.searchBTN);
            this.MenuPanel.Controls.Add(this.basketBtn);
            this.MenuPanel.Controls.Add(this.vfxBtn);
            this.MenuPanel.Controls.Add(this.audioBtn);
            this.MenuPanel.Controls.Add(this.homeBtn);
            this.MenuPanel.Controls.Add(this.threeDBtn);
            this.MenuPanel.Controls.Add(this.twoDBtn);
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(88, 770);
            this.MenuPanel.TabIndex = 22;
            // 
            // InboxButton
            // 
            this.InboxButton.BackgroundImage = global::AssetCache.Properties.Resources.envelopeIcon;
            this.InboxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InboxButton.Location = new System.Drawing.Point(24, 494);
            this.InboxButton.Name = "InboxButton";
            this.InboxButton.Size = new System.Drawing.Size(40, 50);
            this.InboxButton.TabIndex = 29;
            this.InboxButton.TabStop = false;
            this.InboxButton.Click += new System.EventHandler(this.InboxButton_Click);
            // 
            // SubmitAssetBtn
            // 
            this.SubmitAssetBtn.BackColor = System.Drawing.Color.Transparent;
            this.SubmitAssetBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SubmitAssetBtn.BackgroundImage")));
            this.SubmitAssetBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubmitAssetBtn.Location = new System.Drawing.Point(24, 550);
            this.SubmitAssetBtn.Name = "SubmitAssetBtn";
            this.SubmitAssetBtn.Size = new System.Drawing.Size(40, 50);
            this.SubmitAssetBtn.TabIndex = 28;
            this.SubmitAssetBtn.TabStop = false;
            this.SubmitAssetBtn.Click += new System.EventHandler(this.SubmitAssetBtn_Click);
            // 
            // AccountBtn
            // 
            this.AccountBtn.BackColor = System.Drawing.Color.Transparent;
            this.AccountBtn.BackgroundImage = global::AssetCache.Properties.Resources.LoginIcon;
            this.AccountBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AccountBtn.Location = new System.Drawing.Point(24, 698);
            this.AccountBtn.Name = "AccountBtn";
            this.AccountBtn.Size = new System.Drawing.Size(40, 40);
            this.AccountBtn.TabIndex = 0;
            this.AccountBtn.TabStop = false;
            this.AccountBtn.Click += new System.EventHandler(this.AccountBtn_Click);
            // 
            // searchBTN
            // 
            this.searchBTN.BackColor = System.Drawing.Color.Transparent;
            this.searchBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBTN.BackgroundImage")));
            this.searchBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchBTN.Location = new System.Drawing.Point(24, 652);
            this.searchBTN.Name = "searchBTN";
            this.searchBTN.Size = new System.Drawing.Size(40, 40);
            this.searchBTN.TabIndex = 12;
            this.searchBTN.TabStop = false;
            this.searchBTN.Click += new System.EventHandler(this.searchBTN_Click);
            // 
            // basketBtn
            // 
            this.basketBtn.BackColor = System.Drawing.Color.Transparent;
            this.basketBtn.BackgroundImage = global::AssetCache.Properties.Resources.basketIcon;
            this.basketBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.basketBtn.Location = new System.Drawing.Point(24, 606);
            this.basketBtn.Name = "basketBtn";
            this.basketBtn.Size = new System.Drawing.Size(40, 40);
            this.basketBtn.TabIndex = 13;
            this.basketBtn.TabStop = false;
            this.basketBtn.Click += new System.EventHandler(this.basketBtn_Click);
            // 
            // vfxBtn
            // 
            this.vfxBtn.BackColor = System.Drawing.Color.Transparent;
            this.vfxBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vfxBtn.BackgroundImage")));
            this.vfxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vfxBtn.Location = new System.Drawing.Point(24, 407);
            this.vfxBtn.Name = "vfxBtn";
            this.vfxBtn.Size = new System.Drawing.Size(40, 61);
            this.vfxBtn.TabIndex = 11;
            this.vfxBtn.TabStop = false;
            this.vfxBtn.Click += new System.EventHandler(this.vfxBtn_Click);
            // 
            // audioBtn
            // 
            this.audioBtn.BackColor = System.Drawing.Color.Transparent;
            this.audioBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("audioBtn.BackgroundImage")));
            this.audioBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.audioBtn.Location = new System.Drawing.Point(24, 305);
            this.audioBtn.Name = "audioBtn";
            this.audioBtn.Size = new System.Drawing.Size(40, 61);
            this.audioBtn.TabIndex = 10;
            this.audioBtn.TabStop = false;
            this.audioBtn.Click += new System.EventHandler(this.audioBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.Transparent;
            this.homeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homeBtn.BackgroundImage")));
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeBtn.Location = new System.Drawing.Point(24, 40);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(40, 61);
            this.homeBtn.TabIndex = 7;
            this.homeBtn.TabStop = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // threeDBtn
            // 
            this.threeDBtn.BackColor = System.Drawing.Color.Transparent;
            this.threeDBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("threeDBtn.BackgroundImage")));
            this.threeDBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.threeDBtn.Location = new System.Drawing.Point(24, 128);
            this.threeDBtn.Name = "threeDBtn";
            this.threeDBtn.Size = new System.Drawing.Size(40, 61);
            this.threeDBtn.TabIndex = 8;
            this.threeDBtn.TabStop = false;
            this.threeDBtn.Click += new System.EventHandler(this.threeDBtn_Click);
            // 
            // twoDBtn
            // 
            this.twoDBtn.BackColor = System.Drawing.Color.Transparent;
            this.twoDBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("twoDBtn.BackgroundImage")));
            this.twoDBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.twoDBtn.Location = new System.Drawing.Point(24, 219);
            this.twoDBtn.Name = "twoDBtn";
            this.twoDBtn.Size = new System.Drawing.Size(40, 61);
            this.twoDBtn.TabIndex = 9;
            this.twoDBtn.TabStop = false;
            this.twoDBtn.Click += new System.EventHandler(this.twoDBtn_Click);
            // 
            // LoadingImage
            // 
            this.LoadingImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingImage.Image = global::AssetCache.Properties.Resources.LoadingSymbol;
            this.LoadingImage.Location = new System.Drawing.Point(1304, 12);
            this.LoadingImage.Name = "LoadingImage";
            this.LoadingImage.Size = new System.Drawing.Size(50, 50);
            this.LoadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoadingImage.TabIndex = 21;
            this.LoadingImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.assetLoadingcontrol7);
            this.panel1.Controls.Add(this.assetLoadingcontrol6);
            this.panel1.Controls.Add(this.assetLoadingcontrol5);
            this.panel1.Controls.Add(this.assetLoadingcontrol4);
            this.panel1.Controls.Add(this.assetLoadingcontrol3);
            this.panel1.Controls.Add(this.assetLoadingcontrol2);
            this.panel1.Controls.Add(this.assetLoadingcontrol1);
            this.panel1.Controls.Add(this.assetLoadingcontrol0);
            this.panel1.Location = new System.Drawing.Point(147, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 539);
            this.panel1.TabIndex = 30;
            // 
            // assetLoadingcontrol7
            // 
            this.assetLoadingcontrol7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetLoadingcontrol7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetLoadingcontrol7.ID = 0;
            this.assetLoadingcontrol7.Location = new System.Drawing.Point(907, 281);
            this.assetLoadingcontrol7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.assetLoadingcontrol7.Name = "assetLoadingcontrol7";
            this.assetLoadingcontrol7.Size = new System.Drawing.Size(255, 255);
            this.assetLoadingcontrol7.TabIndex = 35;
            // 
            // assetLoadingcontrol6
            // 
            this.assetLoadingcontrol6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetLoadingcontrol6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetLoadingcontrol6.ID = 0;
            this.assetLoadingcontrol6.Location = new System.Drawing.Point(608, 281);
            this.assetLoadingcontrol6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.assetLoadingcontrol6.Name = "assetLoadingcontrol6";
            this.assetLoadingcontrol6.Size = new System.Drawing.Size(255, 255);
            this.assetLoadingcontrol6.TabIndex = 34;
            // 
            // assetLoadingcontrol5
            // 
            this.assetLoadingcontrol5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetLoadingcontrol5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetLoadingcontrol5.ID = 0;
            this.assetLoadingcontrol5.Location = new System.Drawing.Point(301, 284);
            this.assetLoadingcontrol5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.assetLoadingcontrol5.Name = "assetLoadingcontrol5";
            this.assetLoadingcontrol5.Size = new System.Drawing.Size(255, 255);
            this.assetLoadingcontrol5.TabIndex = 33;
            // 
            // assetLoadingcontrol4
            // 
            this.assetLoadingcontrol4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetLoadingcontrol4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetLoadingcontrol4.ID = 0;
            this.assetLoadingcontrol4.Location = new System.Drawing.Point(3, 281);
            this.assetLoadingcontrol4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.assetLoadingcontrol4.Name = "assetLoadingcontrol4";
            this.assetLoadingcontrol4.Size = new System.Drawing.Size(255, 255);
            this.assetLoadingcontrol4.TabIndex = 32;
            // 
            // assetLoadingcontrol3
            // 
            this.assetLoadingcontrol3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetLoadingcontrol3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetLoadingcontrol3.ID = 0;
            this.assetLoadingcontrol3.Location = new System.Drawing.Point(907, 0);
            this.assetLoadingcontrol3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.assetLoadingcontrol3.Name = "assetLoadingcontrol3";
            this.assetLoadingcontrol3.Size = new System.Drawing.Size(255, 255);
            this.assetLoadingcontrol3.TabIndex = 31;
            // 
            // assetLoadingcontrol2
            // 
            this.assetLoadingcontrol2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetLoadingcontrol2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetLoadingcontrol2.ID = 0;
            this.assetLoadingcontrol2.Location = new System.Drawing.Point(608, -3);
            this.assetLoadingcontrol2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.assetLoadingcontrol2.Name = "assetLoadingcontrol2";
            this.assetLoadingcontrol2.Size = new System.Drawing.Size(255, 255);
            this.assetLoadingcontrol2.TabIndex = 30;
            // 
            // assetLoadingcontrol1
            // 
            this.assetLoadingcontrol1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetLoadingcontrol1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetLoadingcontrol1.ID = 0;
            this.assetLoadingcontrol1.Location = new System.Drawing.Point(301, 0);
            this.assetLoadingcontrol1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.assetLoadingcontrol1.Name = "assetLoadingcontrol1";
            this.assetLoadingcontrol1.Size = new System.Drawing.Size(255, 255);
            this.assetLoadingcontrol1.TabIndex = 29;
            // 
            // assetLoadingcontrol0
            // 
            this.assetLoadingcontrol0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetLoadingcontrol0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetLoadingcontrol0.ID = 0;
            this.assetLoadingcontrol0.Location = new System.Drawing.Point(0, 0);
            this.assetLoadingcontrol0.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.assetLoadingcontrol0.Name = "assetLoadingcontrol0";
            this.assetLoadingcontrol0.Size = new System.Drawing.Size(255, 255);
            this.assetLoadingcontrol0.TabIndex = 28;
            // 
            // BackPageButton
            // 
            this.BackPageButton.BackColor = System.Drawing.Color.Black;
            this.BackPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackPageButton.ForeColor = System.Drawing.Color.White;
            this.BackPageButton.Location = new System.Drawing.Point(585, 703);
            this.BackPageButton.Name = "BackPageButton";
            this.BackPageButton.Size = new System.Drawing.Size(75, 39);
            this.BackPageButton.TabIndex = 31;
            this.BackPageButton.Text = "<";
            this.BackPageButton.UseVisualStyleBackColor = false;
            this.BackPageButton.Click += new System.EventHandler(this.BackPageButton_Click);
            // 
            // ForwardPageButton
            // 
            this.ForwardPageButton.BackColor = System.Drawing.Color.Black;
            this.ForwardPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForwardPageButton.ForeColor = System.Drawing.Color.White;
            this.ForwardPageButton.Location = new System.Drawing.Point(787, 703);
            this.ForwardPageButton.Name = "ForwardPageButton";
            this.ForwardPageButton.Size = new System.Drawing.Size(76, 39);
            this.ForwardPageButton.TabIndex = 32;
            this.ForwardPageButton.Text = ">";
            this.ForwardPageButton.UseVisualStyleBackColor = false;
            this.ForwardPageButton.Click += new System.EventHandler(this.ForwaredPageButton_Click);
            // 
            // PageNumber
            // 
            this.PageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PageNumber.BackColor = System.Drawing.Color.Transparent;
            this.PageNumber.ForeColor = System.Drawing.Color.White;
            this.PageNumber.Location = new System.Drawing.Point(657, 703);
            this.PageNumber.Name = "PageNumber";
            this.PageNumber.Size = new System.Drawing.Size(136, 39);
            this.PageNumber.TabIndex = 33;
            this.PageNumber.Text = "1 / 5";
            this.PageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomePage
            // 
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.BackPageButton);
            this.Controls.Add(this.ForwardPageButton);
            this.Controls.Add(this.PageNumber);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.LoadingImage);
            this.Controls.Add(this.PageTitle);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.MenuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InboxButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubmitAssetBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basketBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vfxBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeDBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoDBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AccountBtn;
        private System.Windows.Forms.Label PageTitle;
        private System.Windows.Forms.PictureBox homeBtn;
        private System.Windows.Forms.PictureBox threeDBtn;
        private System.Windows.Forms.PictureBox twoDBtn;
        private System.Windows.Forms.PictureBox audioBtn;
        private System.Windows.Forms.PictureBox vfxBtn;
        private System.Windows.Forms.PictureBox searchBTN;
        private System.Windows.Forms.PictureBox basketBtn;

        private System.Windows.Forms.PictureBox LoadingImage;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.PictureBox SubmitAssetBtn;
        private System.Windows.Forms.Panel MenuPanel;
        private AssetLoadingcontrol assetLoadingcontrol0;
        private AssetLoadingcontrol assetLoadingcontrol1;
        private System.Windows.Forms.Panel panel1;
        private AssetLoadingcontrol assetLoadingcontrol3;
        private AssetLoadingcontrol assetLoadingcontrol2;
        private AssetLoadingcontrol assetLoadingcontrol7;
        private AssetLoadingcontrol assetLoadingcontrol6;
        private AssetLoadingcontrol assetLoadingcontrol5;
        private AssetLoadingcontrol assetLoadingcontrol4;
        private System.Windows.Forms.Button BackPageButton;
        private System.Windows.Forms.Button ForwardPageButton;
        private System.Windows.Forms.Label PageNumber;
        private System.Windows.Forms.PictureBox InboxButton;
    }
}

