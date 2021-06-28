using System.Drawing;
using System.Windows.Forms;

namespace AssetCache.Forms
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameInputBox = new System.Windows.Forms.TextBox();
            this.EmaillineBreakLabel = new System.Windows.Forms.Label();
            this.PasswordBreakLineLabel = new System.Windows.Forms.Label();
            this.PasswordInputBox = new System.Windows.Forms.TextBox();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.EmailTextBoxLabel = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogInButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Black;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.UsernameLabel.Location = new System.Drawing.Point(67, 110);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(302, 64);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Black;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.PasswordLabel.Location = new System.Drawing.Point(72, 167);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(289, 64);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameInputBox
            // 
            this.UsernameInputBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.UsernameInputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameInputBox.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameInputBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.UsernameInputBox.Location = new System.Drawing.Point(245, 111);
            this.UsernameInputBox.Name = "UsernameInputBox";
            this.UsernameInputBox.Size = new System.Drawing.Size(301, 55);
            this.UsernameInputBox.TabIndex = 2;
            // 
            // EmaillineBreakLabel
            // 
            this.EmaillineBreakLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EmaillineBreakLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EmaillineBreakLabel.Location = new System.Drawing.Point(242, 140);
            this.EmaillineBreakLabel.Name = "EmaillineBreakLabel";
            this.EmaillineBreakLabel.Size = new System.Drawing.Size(303, 2);
            this.EmaillineBreakLabel.TabIndex = 3;
            // 
            // PasswordBreakLineLabel
            // 
            this.PasswordBreakLineLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PasswordBreakLineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PasswordBreakLineLabel.Location = new System.Drawing.Point(242, 193);
            this.PasswordBreakLineLabel.Name = "PasswordBreakLineLabel";
            this.PasswordBreakLineLabel.Size = new System.Drawing.Size(303, 2);
            this.PasswordBreakLineLabel.TabIndex = 4;
            // 
            // PasswordInputBox
            // 
            this.PasswordInputBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.PasswordInputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordInputBox.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInputBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.PasswordInputBox.Location = new System.Drawing.Point(245, 161);
            this.PasswordInputBox.MaxLength = 14;
            this.PasswordInputBox.Name = "PasswordInputBox";
            this.PasswordInputBox.PasswordChar = '♥';
            this.PasswordInputBox.Size = new System.Drawing.Size(301, 55);
            this.PasswordInputBox.TabIndex = 3;
            this.PasswordInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordInputBox_KeyDown);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.BackColor = System.Drawing.Color.Black;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.RegisterLabel.Location = new System.Drawing.Point(452, 314);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(162, 44);
            this.RegisterLabel.TabIndex = 6;
            this.RegisterLabel.Text = "Register";
            this.RegisterLabel.Click += new System.EventHandler(this.RegisterLabel_Click);
            // 
            // EmailTextBoxLabel
            // 
            this.EmailTextBoxLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EmailTextBoxLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EmailTextBoxLabel.Location = new System.Drawing.Point(242, 255);
            this.EmailTextBoxLabel.Name = "EmailTextBoxLabel";
            this.EmailTextBoxLabel.Size = new System.Drawing.Size(303, 2);
            this.EmailTextBoxLabel.TabIndex = 10;
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.BackColor = System.Drawing.SystemColors.MenuText;
            this.EmailTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTextbox.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.EmailTextbox.Location = new System.Drawing.Point(245, 226);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(301, 55);
            this.EmailTextbox.TabIndex = 9;
            this.EmailTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EmailTextbox_KeyDown);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BackColor = System.Drawing.Color.Black;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.EmailLabel.Location = new System.Drawing.Point(130, 221);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(185, 64);
            this.EmailLabel.TabIndex = 8;
            this.EmailLabel.Text = "Email:";
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.BackColor = System.Drawing.Color.Black;
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(268, 331);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(84, 35);
            this.CancelButton.TabIndex = 23;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.AutoSize = true;
            this.RegisterButton.BackColor = System.Drawing.Color.Black;
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Location = new System.Drawing.Point(370, 331);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(84, 35);
            this.RegisterButton.TabIndex = 24;
            this.RegisterButton.Text = "Submit";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.RegisterButton);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.EmailTextBoxLabel);
            this.panel1.Controls.Add(this.EmailTextbox);
            this.panel1.Controls.Add(this.EmailLabel);
            this.panel1.Controls.Add(this.RegisterLabel);
            this.panel1.Controls.Add(this.PasswordBreakLineLabel);
            this.panel1.Controls.Add(this.EmaillineBreakLabel);
            this.panel1.Controls.Add(this.UsernameInputBox);
            this.panel1.Controls.Add(this.PasswordLabel);
            this.panel1.Controls.Add(this.UsernameLabel);
            this.panel1.Controls.Add(this.PasswordInputBox);
            this.panel1.Controls.Add(this.LogInButton);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 390);
            this.panel1.TabIndex = 25;
            // 
            // LogInButton
            // 
            this.LogInButton.BackColor = System.Drawing.Color.Black;
            this.LogInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInButton.ForeColor = System.Drawing.Color.White;
            this.LogInButton.Location = new System.Drawing.Point(245, 230);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(192, 32);
            this.LogInButton.TabIndex = 0;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = false;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = global::AssetCache.Properties.Resources.X_logo;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseButton.Location = new System.Drawing.Point(658, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LogIn
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(39)))), ((int)(((byte)(63)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UsernameInputBox;
        private System.Windows.Forms.Label EmaillineBreakLabel;
        private Label PasswordBreakLineLabel;
        private TextBox PasswordInputBox;
        private Label RegisterLabel;
        private Label EmailTextBoxLabel;
        private TextBox EmailTextbox;
        private Label EmailLabel;
        private Button CancelButton;
        private Button RegisterButton;
        private Panel panel1;
        private Button LogInButton;
        private PictureBox CloseButton;
    }
}