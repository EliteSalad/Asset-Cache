namespace AssetCache
{
    partial class MessageBox
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
            this.messageBox00001 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // messageBox00001
            // 
            this.messageBox00001.BackColor = System.Drawing.Color.Black;
            this.messageBox00001.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBox00001.Enabled = false;
            this.messageBox00001.ForeColor = System.Drawing.Color.White;
            this.messageBox00001.Location = new System.Drawing.Point(0, 0);
            this.messageBox00001.Multiline = true;
            this.messageBox00001.Name = "messageBox00001";
            this.messageBox00001.ReadOnly = true;
            this.messageBox00001.Size = new System.Drawing.Size(1215, 30);
            this.messageBox00001.TabIndex = 7;
            this.messageBox00001.Text = "Rating: 5";
            // 
            // MessageBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.messageBox00001);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MessageBox";
            this.Size = new System.Drawing.Size(1215, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageBox00001;
    }
}
