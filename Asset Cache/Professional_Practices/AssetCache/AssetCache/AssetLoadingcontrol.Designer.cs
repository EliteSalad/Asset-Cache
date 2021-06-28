namespace AssetCache
{
    partial class AssetLoadingcontrol
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
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.PictureAsset = new System.Windows.Forms.PictureBox();
            this.AssetNameLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.transparentPanel1 = new AssetCache.Classes.TransparentPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CompanyLabel.Location = new System.Drawing.Point(7, 312);
            this.CompanyLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(192, 28);
            this.CompanyLabel.TabIndex = 3;
            this.CompanyLabel.Text = "PROSOURCE LABS";
            // 
            // PictureAsset
            // 
            this.PictureAsset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureAsset.Location = new System.Drawing.Point(-6, 0);
            this.PictureAsset.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PictureAsset.Name = "PictureAsset";
            this.PictureAsset.Size = new System.Drawing.Size(468, 295);
            this.PictureAsset.TabIndex = 2;
            this.PictureAsset.TabStop = false;
            // 
            // AssetNameLabel
            // 
            this.AssetNameLabel.AutoSize = true;
            this.AssetNameLabel.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssetNameLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AssetNameLabel.Location = new System.Drawing.Point(4, 360);
            this.AssetNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AssetNameLabel.Name = "AssetNameLabel";
            this.AssetNameLabel.Size = new System.Drawing.Size(225, 35);
            this.AssetNameLabel.TabIndex = 4;
            this.AssetNameLabel.Text = "Graph And Chart";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PriceLabel.Location = new System.Drawing.Point(7, 415);
            this.PriceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(68, 28);
            this.PriceLabel.TabIndex = 5;
            this.PriceLabel.Text = "60.52";
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Size = new System.Drawing.Size(462, 460);
            this.transparentPanel1.TabIndex = 7;
            this.transparentPanel1.Click += new System.EventHandler(this.transparentPanel1_Click);
            this.transparentPanel1.MouseLeave += new System.EventHandler(this.transparentPanel1_MouseLeave);
            this.transparentPanel1.MouseHover += new System.EventHandler(this.transparentPanel1_MouseHover);
            // 
            // AssetLoadingcontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.transparentPanel1);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.AssetNameLabel);
            this.Controls.Add(this.CompanyLabel);
            this.Controls.Add(this.PictureAsset);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AssetLoadingcontrol";
            this.Size = new System.Drawing.Size(468, 471);
            ((System.ComponentModel.ISupportInitialize)(this.PictureAsset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CompanyLabel;
        private System.Windows.Forms.PictureBox PictureAsset;
        private System.Windows.Forms.Label AssetNameLabel;
        private System.Windows.Forms.Label PriceLabel;
        private Classes.TransparentPanel transparentPanel1;
    }
}
