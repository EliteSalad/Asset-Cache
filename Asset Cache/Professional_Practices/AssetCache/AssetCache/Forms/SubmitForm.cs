using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetCache.Forms
{
    public partial class SubmitForm : Form
    {
        public string username;
        public string password;
        public string email;
        public int IDNumber;

        LogIn LoginForm = new LogIn();
        public static bool LoggedInFormOpen = false;

        public SubmitForm()
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

        public void SetIDNumber(int id)
        {
            IDNumber = id;
        }

        private void SubmitForm_Load(object sender, EventArgs e)
        {
            this.LoadingImage.Hide();
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

        private void SubmitForm_Click(object sender, EventArgs e)
        {
            if (Account.instance.isLoggedIn)
            {

                if (TitleInputBox.Text != "")
                {
                    if (DescriptionInputBox.Text != "")
                    {
                        if (PoundsInputBox.Text != "" && PenceInputBox.Text != "")
                        {
                            PacketSendType packetNumber = PacketSendType.SubmitAsset;
                            if (!PacketControl.packets.ContainsKey((int)packetNumber))
                            {
                                SendData.SubmitAsset(TitleInputBox.Text, DescriptionInputBox.Text, Convert.ToSingle(PoundsInputBox.Text+"."+PenceInputBox.Text));

                                DateTime expireTime = DateTime.Now.AddSeconds(15);

                                while (PacketControl.packets.ContainsKey((int)packetNumber))
                                {
                                    this.LoadingImage.Hide();
                                    this.LoadingImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    this.LoadingImage.Show();
                                    this.LoadingImage.Update();

                                    if (DateTime.Now >= expireTime)
                                    {
                                        Console.WriteLine("Waited too long");
                                        break;
                                    }
                                }
                                this.LoadingImage.Hide();
                            }
                            StoreItem item = new StoreItem(IDNumber);
                            item.Visible = false;
                            item.Show();
                            item.Visible = true;
                            this.Close();
                        }
                        else
                            System.Windows.Forms.MessageBox.Show("Please insert Pounds and Pence.");
                    }
                    else
                        System.Windows.Forms.MessageBox.Show("Please insert description.");
                }
                else
                    System.Windows.Forms.MessageBox.Show("Please insert title.");
            }
            else
            {
                Login();
                System.Windows.Forms.MessageBox.Show("Please log in, to submit something.");
            }
        }

        private void PriceInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9\b]"))
            {
                // Allow only numeric characters to be entered
                e.Handled = true;
            }
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[;']"))
            {
                // Stop the certain characters to be entered to stop SQL injection
                e.Handled = true;
            }
        }

        private void Login()
        {
            if (!Network.instance.loggedIn && !LoggedInFormOpen)
            {
                LoginForm.Show();
                LoggedInFormOpen = true;

            }
            else
            {
                LoginForm.Hide();
                LoggedInFormOpen = false;
            }
        }

        private void PenceInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9\b]"))
            {
                // Allow only numeric characters to be entered
                e.Handled = true;
            }
        }
    }
}
