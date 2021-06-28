using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetCache.Forms
{
    public partial class LogIn : Form
    {
        public static LogIn login;
        public string username;
        public string password;
        public string email;

        public LogIn()
        {
            InitializeComponent();
            //Avoids flickering on the program
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            //Center the form to the screen position
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            login = this;
            RegisterButton.Hide();
            EmailLabel.Hide();
            EmailTextbox.Hide();
            EmailTextBoxLabel.Hide();
            CancelButton.Hide();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            LogInButton.Hide();
            RegisterLabel.Hide();
            RegisterButton.Show();
            EmailTextbox.Show();
            EmailLabel.Show();
            EmailTextBoxLabel.Show();
            CancelButton.Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void PasswordInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void EmailTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Register();
            }
        }

        private void Login()
        {
            if (UsernameInputBox.Text != "" && PasswordInputBox.Text != "")
            {
                PacketSendType packetNumber = PacketSendType.Login;
                if (!PacketControl.packets.ContainsKey((int)packetNumber))
                {
                    SendData.Login(UsernameInputBox.Text.ToLower(), PasswordInputBox.Text);
                    username = UsernameInputBox.Text.ToLower();
                    password = PasswordInputBox.Text;
                    HomePage.instance.ProcessPacket(packetNumber);
                }
                Console.WriteLine("Sent");
                if (Network.instance.loggedIn)
                {
                    Account.instance.Login(username, password);
                    HomePage.instance.LoggedInFormOpen = false;
                    this.Close();
                }
                else if (!Network.instance.loggedIn)
                {
                    System.Windows.Forms.MessageBox.Show("Login incorrect");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Insert valid data");
            }
        }

        private void Register()
        {
            if (UsernameInputBox.Text != "" && PasswordInputBox.Text != "")
            {
                if(EmailTextbox.Text != "")
                {
                    PacketSendType packetNumber = PacketSendType.CreateAccount;
                    if (!PacketControl.packets.ContainsKey((int)packetNumber))
                    {
                        username = UsernameInputBox.Text;
                        password = PasswordInputBox.Text;
                        email = EmailTextbox.Text;
                        SendData.CreateAccount(UsernameInputBox.Text, PasswordInputBox.Text, EmailTextbox.Text);
                        HomePage.instance.ProcessPacket(packetNumber);
                    }

                    if (Network.instance.CreatedAccount)
                    {
                        System.Windows.Forms.MessageBox.Show("Account Created Successfully");
                    }
                    else if (!Network.instance.CreatedAccount)
                    {
                        System.Windows.Forms.MessageBox.Show("Insert valid data");
                    }
                }
                else 
                {
                    System.Windows.Forms.MessageBox.Show("Insert valid data");
                }

                if (Network.instance.CreatedAccount)
                {
                    PacketSendType packetNumber = PacketSendType.Login;
                    if (!PacketControl.packets.ContainsKey((int)packetNumber))
                    {
                        SendData.Login(UsernameInputBox.Text, PasswordInputBox.Text);
                        username = UsernameInputBox.Text;
                        password = PasswordInputBox.Text;
                        HomePage.instance.ProcessPacket(packetNumber);
                    }
                    if (Network.instance.loggedIn)
                    {
                        Account.instance.Login(username, password);
                        HomePage.instance.LoggedInFormOpen = false;
                        this.Close();
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Insert valid data");
            }
        }       

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelButton.Hide();
            RegisterButton.Hide();
            EmailTextbox.Hide();
            EmailLabel.Hide();
            EmailTextBoxLabel.Hide();
            RegisterLabel.Show();
            LogInButton.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            HomePage.instance.LoggedInFormOpen = false;
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
