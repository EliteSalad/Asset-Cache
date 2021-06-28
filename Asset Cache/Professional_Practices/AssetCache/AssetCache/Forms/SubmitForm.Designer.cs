using System.Drawing;
using System.Windows.Forms;

namespace AssetCache.Forms
{
    partial class SubmitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubmitForm));
            this.LoadingImage = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleInputBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionInputBox = new System.Windows.Forms.TextBox();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.PoundsInputBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PenceInputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadingImage
            // 
            this.LoadingImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingImage.Image = global::AssetCache.Properties.Resources.LoadingSymbol;
            this.LoadingImage.Location = new System.Drawing.Point(728, 12);
            this.LoadingImage.Name = "LoadingImage";
            this.LoadingImage.Size = new System.Drawing.Size(50, 50);
            this.LoadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoadingImage.TabIndex = 22;
            this.LoadingImage.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.TitleLabel.Location = new System.Drawing.Point(112, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(83, 39);
            this.TitleLabel.TabIndex = 23;
            this.TitleLabel.Text = "Title";
            // 
            // TitleInputBox
            // 
            this.TitleInputBox.BackColor = System.Drawing.Color.Black;
            this.TitleInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleInputBox.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.TitleInputBox.Location = new System.Drawing.Point(201, 3);
            this.TitleInputBox.MaxLength = 25;
            this.TitleInputBox.Name = "TitleInputBox";
            this.TitleInputBox.Size = new System.Drawing.Size(336, 39);
            this.TitleInputBox.TabIndex = 24;
            this.TitleInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputBox_KeyPress);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 45);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(192, 39);
            this.DescriptionLabel.TabIndex = 25;
            this.DescriptionLabel.Text = "Description";
            // 
            // DescriptionInputBox
            // 
            this.DescriptionInputBox.BackColor = System.Drawing.Color.Black;
            this.DescriptionInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionInputBox.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.DescriptionInputBox.Location = new System.Drawing.Point(201, 48);
            this.DescriptionInputBox.MaxLength = 4000;
            this.DescriptionInputBox.Multiline = true;
            this.DescriptionInputBox.Name = "DescriptionInputBox";
            this.DescriptionInputBox.Size = new System.Drawing.Size(336, 233);
            this.DescriptionInputBox.TabIndex = 26;
            this.DescriptionInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputBox_KeyPress);
            // 
            // PriceLabel
            // 
            this.PriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.PriceLabel.Location = new System.Drawing.Point(46, 289);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(149, 39);
            this.PriceLabel.TabIndex = 27;
            this.PriceLabel.Text = "Price (£)";
            // 
            // PoundsInputBox
            // 
            this.PoundsInputBox.BackColor = System.Drawing.Color.Black;
            this.PoundsInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PoundsInputBox.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.PoundsInputBox.Location = new System.Drawing.Point(3, 3);
            this.PoundsInputBox.Name = "PoundsInputBox";
            this.PoundsInputBox.Size = new System.Drawing.Size(165, 39);
            this.PoundsInputBox.TabIndex = 28;
            this.PoundsInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceInputBox_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.DescriptionInputBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TitleInputBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PriceLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TitleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(128, 91);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 329);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.PenceInputBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.PoundsInputBox, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(201, 292);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(343, 34);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // PenceInputBox1
            // 
            this.PenceInputBox.BackColor = System.Drawing.Color.Black;
            this.PenceInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenceInputBox.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.PenceInputBox.Location = new System.Drawing.Point(174, 3);
            this.PenceInputBox.MaxLength = 2;
            this.PenceInputBox.Name = "PenceInputBox1";
            this.PenceInputBox.Size = new System.Drawing.Size(165, 39);
            this.PenceInputBox.TabIndex = 29;
            this.PenceInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PenceInputBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(347, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 34);
            this.label1.TabIndex = 30;
            this.label1.Text = "Submit";
            this.label1.Click += new System.EventHandler(this.SubmitForm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LoadingImage);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 490);
            this.panel1.TabIndex = 31;
            // 
            // SubmitForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(39)))), ((int)(((byte)(63)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SubmitForm";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.SubmitForm_Load);
            this.Click += new System.EventHandler(this.SubmitForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox LoadingImage;
        private Label TitleLabel;
        private TextBox TitleInputBox;
        private Label DescriptionLabel;
        private TextBox DescriptionInputBox;
        private Label PriceLabel;
        private TextBox PoundsInputBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox PenceInputBox;
    }
}