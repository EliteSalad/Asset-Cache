using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetCache.Forms
{

    public partial class Basket : Form
    {
        
        private float m_subTotal = 0.0f;
        LogIn LoginForm = new LogIn();
        public static bool LoggedInFormOpen = false;
        private string SearchTerm = "";

        public Basket()
        {
            InitializeComponent();

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
            searchBox.Hide();
        }

        private void EmptyBasket_Click(object sender, EventArgs e)
        {
            PacketSendType packetNumber = PacketSendType.BasketRequest;

            if (!PacketControl.packets.ContainsKey((int)packetNumber))
            {
                SendData.BasketRequest(BasketFunctions.Clear);
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
            LoadBasket();
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

        private void copyControl(Control sourceControl, Control targetControl)
        {
            // make sure these are the same
            if (sourceControl.GetType() != targetControl.GetType())
            {
                throw new Exception("Incorrect control types");
            }

            foreach (PropertyInfo sourceProperty in sourceControl.GetType().GetProperties())
            {
                object newValue = sourceProperty.GetValue(sourceControl, null);

                MethodInfo mi = sourceProperty.GetSetMethod(true);
                if (mi != null)
                {
                    sourceProperty.SetValue(targetControl, newValue, null);
                }
            }
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search...")
            {
                searchBox.Text = "";
            }
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

        private void Basket_Load(object sender, EventArgs e)
        {
            LoadBasket();
        }

        public void LoadBasket()
        {


            PacketSendType packetNumber = PacketSendType.BasketRequest;

            if (!PacketControl.packets.ContainsKey((int)packetNumber))
            {
                SendData.BasketRequest(BasketFunctions.Request);
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

            List<Item> bi = new List<Item>();
            packetNumber = PacketSendType.GetAsset;
            for (int i = 0; i < Cache.Instance.basketItemIDs.Count; i++)
            {
                if (!PacketControl.packets.ContainsKey((int)packetNumber))
                {
                    SendData.GetAsset(Cache.Instance.basketItemIDs[i]);
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
                    bi.Add(Cache.Instance.Asset);
                }
            }

            if (BasketLayoutTable.RowCount < bi.Count)
            {
                for (int i = BasketLayoutTable.RowCount; i < bi.Count; i++)
                {
                    //increase panel rows count by one
                    BasketLayoutTable.RowCount++;
                    //add a new RowStyle as a copy of the previous one
                    BasketLayoutTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
                    string controlName = "basketItems" + BasketLayoutTable.RowCount.ToString("00000");
                    BasketLayoutTable.Controls.Add(new BasketItems()
                    {
                        Name = controlName,
                        // Location = new Point(0, 0),
                        Margin = Padding.Empty
                    }, 0, BasketLayoutTable.RowCount - 1);
                }
                BasketLayoutTable.HorizontalScroll.Maximum = 0;
                BasketLayoutTable.AutoScroll = false;
                BasketLayoutTable.VerticalScroll.Visible = false;
                BasketLayoutTable.AutoScroll = true;
            }
            else
            {
                for (int i = BasketLayoutTable.RowCount; i > bi.Count; --i)
                {
                    Control Asset = BasketLayoutTable.Controls.Find("basketItems" + (BasketLayoutTable.RowCount).ToString("00000"), true)[0];
                    BasketLayoutTable.Controls.Remove(Asset);
                    Asset.Dispose();
                    BasketLayoutTable.RowCount--;
                }
            }

            TableLayoutRowStyleCollection styles = BasketLayoutTable.RowStyles;
            foreach (RowStyle style in styles)
            {
                // Set the row height to 150 pixels.
                style.SizeType = SizeType.Absolute;
                style.Height = 150.0f;
            }

            for (int i = 0; i < bi.Count; i++)
            {
                string controlName = "basketItems" + (i + 1).ToString("00000");
                BasketItems temp = (BasketItems)BasketLayoutTable.Controls.Find(controlName, true)[0];
                temp.Margin = Padding.Empty;
                if (bi[i].Images.Count != 0)
                    temp.AssetPicture.BackgroundImage = bi[i].Images[0];

                temp.ID = bi[i].ID;
                temp.AssetName.Text = bi[i].Name;
                temp.Price.Text = "£" + bi[i].Price.ToString();
                m_subTotal += bi[i].Price;
            }
            SubTotalPrice.Text = m_subTotal.ToString();
        }

        private void AccountBtn_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            LoadMainForm("Home");
        }

        private void threeDBtn_Click(object sender, EventArgs e)
        {
            LoadMainForm("3D");
        }

        private void twoDBtn_Click(object sender, EventArgs e)
        {
            LoadMainForm("2D");
        }

        private void audioBtn_Click(object sender, EventArgs e)
        {
            LoadMainForm("Audio");
        }

        private void vfxBtn_Click(object sender, EventArgs e)
        {
            LoadMainForm("VFX");
        }

        private void LoadMainForm(string filter)
        {
            HomePage.instance.RetrieveAssets(filter);
            HomePage.instance.Show();
            HomePage.instance.BringToFront();
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
            SearchTerm = searchBox.Text;
            LoadMainForm(SearchTerm);
        }

        private void Login()
        {
            this.searchBox.Hide();

            if (!Network.instance.loggedIn && !LoggedInFormOpen)
            {
                LoginForm.Show();
                LoggedInFormOpen = true;
            }
            else if (!LoggedInFormOpen && Account.instance.isLoggedIn)
            {
                var ac = new AccountForm();
                ac.ShowDialog();
            }
            else
            {
                LoginForm.Hide();
                LoggedInFormOpen = false;
            }
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[;'\n]"))
            {
                // Stop the certain characters to be entered to stop SQL injection
                e.Handled = true;
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }
    }        
}
