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
    public partial class AccountForm : Form
    {
        private string SearchTerm = "";
        public bool LoggedInFormOpen = false;

        public AccountForm()
        {

            InitializeComponent();
            avatarPicture.SizeMode = PictureBoxSizeMode.Zoom;

            //Avoids flickering on the program
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            //Gets the screen resolution and divides the client size by 2
            int h = Screen.PrimaryScreen.WorkingArea.Height / 2;
            int w = Screen.PrimaryScreen.WorkingArea.Width / 2;
            if (w < 680)
            {
                this.ClientSize = new Size(w, h);
            }
            else
            {
                this.ClientSize = new Size(1366, 768);
                w = 1366;
                h = 768;
            }

            //Center the form to the screen position
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            this.LoadingImage.Hide();
            UsernameInputBox.Text = Account.instance.GetUsername();
            PasswordInputBox.Text = Account.instance.GetPassword();
            emailInputTextbox.Text = Account.instance.GetEmail();
            avatarPicture.Image = Account.instance.avatar;
        }

        private void AccountBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            HomePage.instance.RetrieveAssets("Home");
            this.Close();
        }

        private void threeDBtn_Click(object sender, EventArgs e)
        {
            HomePage.instance.RetrieveAssets("3D");
            this.Close();
        }

        private void twoDBtn_Click(object sender, EventArgs e)
        {
            HomePage.instance.RetrieveAssets("2D");
            this.Close();
        }

        private void audioBtn_Click(object sender, EventArgs e)
        {
            HomePage.instance.RetrieveAssets("Audio");
            this.Close();
        }

        private void vfxBtn_Click(object sender, EventArgs e)
        {
            HomePage.instance.RetrieveAssets("VFX");
            this.Close();
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            searchBox.Show();
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAssets(this, new EventArgs());
            }
        }

        private void SearchAssets(object sender, EventArgs e)
        {
            SearchTerm = searchBTN.Text;
            LoadMainForm(SearchTerm);
        }

        private void basketBtn_Click(object sender, EventArgs e)
        {
            if (Account.instance.isLoggedIn)
            {
                Basket basket = new Basket();
                basket.Show();
                this.Close();
            }
            else
            {
                Login();
                System.Windows.Forms.MessageBox.Show("Please log in, to open the basket.");
            }
        }

        private void UploadAvatarButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Image Files";
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                                        "All files(*.*) | *.* ";
             openFileDialog1.Multiselect = false;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        Image myBitmap = Image.FromFile(file);
                        Image avatarImage =  myBitmap.GetThumbnailImage(256, 256, ThumbnailCallback, IntPtr.Zero);
                        PacketSendType packetNumber = PacketSendType.UploadImage;
                        if (!PacketControl.packets.ContainsKey((int)packetNumber))
                        {
                            SendData.UploadImage(avatarImage, -1, -1, file.Substring(file.IndexOf(@".")), true);
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
                            avatarPicture.Image = avatarImage;
                            Account.instance.avatar = avatarImage;
                            avatarPicture.Update();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
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

        private void SubmitAssetBtn_Click(object sender, EventArgs e)
        {
            SubmitForm submitForm = new SubmitForm();
            submitForm.Visible = false;
            submitForm.Show();
            submitForm.Visible = true;
        }

        private void InboxButton_Click(object sender, EventArgs e)
        {
            if (Account.instance.isLoggedIn)
            {
                int contains = -1;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i].Name == "Messenger")
                    {
                        contains = i;
                    }
                }

                if (contains != -1)
                {
                    Application.OpenForms[contains].Show();
                    Application.OpenForms[contains].BringToFront();
                }
                else
                {
                    Messenger messenger = new Messenger();
                    messenger.Show();
                }
            }
            else
            {
                Login();
                System.Windows.Forms.MessageBox.Show("Please log in, to open your inbox.");
            }
        }

        private void Login()
        {
            LogIn LoginForm = new LogIn();
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

        private void searchBox_Click(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search...")
            {
                searchBox.Text = "";
            }
        }

        private void LoadMainForm(string filter)
        {
            HomePage.instance.RetrieveAssets(filter);
            HomePage.instance.Show();
            HomePage.instance.BringToFront();
            this.Close();
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[;'\n]"))
            {
                // Stop the certain characters to be entered to stop SQL injection
                e.Handled = true;
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search...")
            {
                searchBox.Text = "";
            }
        }
    }
}
