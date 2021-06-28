namespace AssetCache
{
    partial class BasketItems
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
            this.OverallBasketItemPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AssetImage = new System.Windows.Forms.PictureBox();
            this.BasketInfo = new System.Windows.Forms.TableLayoutPanel();
            this.AssetTitle = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.transparentPanel1 = new AssetCache.Classes.TransparentPanel();
            this.BinIcon = new System.Windows.Forms.PictureBox();
            this.OverallBasketItemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssetImage)).BeginInit();
            this.BasketInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BinIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // OverallBasketItemPanel
            // 
            this.OverallBasketItemPanel.ColumnCount = 2;
            this.OverallBasketItemPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.OverallBasketItemPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 620F));
            this.OverallBasketItemPanel.Controls.Add(this.AssetImage, 0, 0);
            this.OverallBasketItemPanel.Controls.Add(this.BasketInfo, 1, 0);
            this.OverallBasketItemPanel.Location = new System.Drawing.Point(0, 0);
            this.OverallBasketItemPanel.Name = "OverallBasketItemPanel";
            this.OverallBasketItemPanel.RowCount = 1;
            this.OverallBasketItemPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.OverallBasketItemPanel.Size = new System.Drawing.Size(770, 150);
            this.OverallBasketItemPanel.TabIndex = 0;
            // 
            // AssetImage
            // 
            this.AssetImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AssetImage.Location = new System.Drawing.Point(3, 3);
            this.AssetImage.Name = "AssetImage";
            this.AssetImage.Size = new System.Drawing.Size(144, 144);
            this.AssetImage.TabIndex = 0;
            this.AssetImage.TabStop = false;
            // 
            // BasketInfo
            // 
            this.BasketInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BasketInfo.ColumnCount = 3;
            this.BasketInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.BasketInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.BasketInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasketInfo.Controls.Add(this.AssetTitle, 0, 0);
            this.BasketInfo.Controls.Add(this.PriceLabel, 1, 0);
            this.BasketInfo.Controls.Add(this.BinIcon, 2, 0);
            this.BasketInfo.Location = new System.Drawing.Point(153, 40);
            this.BasketInfo.Name = "BasketInfo";
            this.BasketInfo.RowCount = 1;
            this.BasketInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.BasketInfo.Size = new System.Drawing.Size(614, 69);
            this.BasketInfo.TabIndex = 1;
            // 
            // AssetTitle
            // 
            this.AssetTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AssetTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssetTitle.ForeColor = System.Drawing.Color.White;
            this.AssetTitle.Location = new System.Drawing.Point(3, 0);
            this.AssetTitle.Name = "AssetTitle";
            this.AssetTitle.Size = new System.Drawing.Size(362, 75);
            this.AssetTitle.TabIndex = 0;
            this.AssetTitle.Text = "3D Asset";
            this.AssetTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PriceLabel
            // 
            this.PriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLabel.ForeColor = System.Drawing.Color.White;
            this.PriceLabel.Location = new System.Drawing.Point(371, 0);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(157, 75);
            this.PriceLabel.TabIndex = 1;
            this.PriceLabel.Text = "£23.45";
            this.PriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Size = new System.Drawing.Size(704, 150);
            this.transparentPanel1.TabIndex = 2;
            this.transparentPanel1.Click += new System.EventHandler(this.transparentPanel1_Click);
            this.transparentPanel1.MouseLeave += new System.EventHandler(this.transparentPanel1_MouseLeave);
            this.transparentPanel1.MouseHover += new System.EventHandler(this.transparentPanel1_MouseHover);
            // 
            // BinIcon
            // 
            this.BinIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BinIcon.BackgroundImage = global::AssetCache.Properties.Resources.BinIcon;
            this.BinIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BinIcon.Location = new System.Drawing.Point(555, 3);
            this.BinIcon.Name = "BinIcon";
            this.BinIcon.Size = new System.Drawing.Size(56, 69);
            this.BinIcon.TabIndex = 2;
            this.BinIcon.TabStop = false;
            this.BinIcon.Click += new System.EventHandler(this.BinIcon_Click);
            // 
            // BasketItems
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.transparentPanel1);
            this.Controls.Add(this.OverallBasketItemPanel);
            this.Name = "BasketItems";
            this.Size = new System.Drawing.Size(770, 150);
            this.OverallBasketItemPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AssetImage)).EndInit();
            this.BasketInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BinIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel OverallBasketItemPanel;
        private System.Windows.Forms.PictureBox AssetImage;
        private System.Windows.Forms.TableLayoutPanel BasketInfo;
        private System.Windows.Forms.Label AssetTitle;
        private System.Windows.Forms.Label PriceLabel;
        private Classes.TransparentPanel transparentPanel1;
        private System.Windows.Forms.PictureBox BinIcon;
    }
}
