namespace AssetCache
{
    partial class SimpleAccountInfo
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.UserName = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.PictureBox();
            this.transparentPanel1 = new AssetCache.Classes.TransparentPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 401F));
            this.tableLayoutPanel1.Controls.Add(this.Avatar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UserName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Status, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Avatar
            // 
            this.Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Avatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Avatar.Location = new System.Drawing.Point(0, 0);
            this.Avatar.Margin = new System.Windows.Forms.Padding(0);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(50, 50);
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // UserName
            // 
            this.UserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.Color.White;
            this.UserName.Location = new System.Drawing.Point(73, 5);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(178, 39);
            this.UserName.TabIndex = 1;
            this.UserName.Text = "Username";
            this.UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Status
            // 
            this.Status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Status.BackgroundImage = global::AssetCache.Properties.Resources.Online;
            this.Status.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Status.InitialImage = global::AssetCache.Properties.Resources.Offline;
            this.Status.Location = new System.Drawing.Point(55, 20);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(10, 10);
            this.Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Status.TabIndex = 2;
            this.Status.TabStop = false;
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Size = new System.Drawing.Size(471, 50);
            this.transparentPanel1.TabIndex = 1;
            this.transparentPanel1.Click += new System.EventHandler(this.transparentPanel1_Click);
            this.transparentPanel1.MouseLeave += new System.EventHandler(this.transparentPanel1_MouseLeave);
            this.transparentPanel1.MouseHover += new System.EventHandler(this.transparentPanel1_MouseHover);
            // 
            // SimpleAccountInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.transparentPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SimpleAccountInfo";
            this.Size = new System.Drawing.Size(471, 50);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox Avatar;
        private Classes.TransparentPanel transparentPanel1;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.PictureBox Status;
    }
}
