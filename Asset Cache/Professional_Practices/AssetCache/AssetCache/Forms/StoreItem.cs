using AssetCache.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetCache
{
    public partial class StoreItem : Form
    {
        private int m_ID = -1;        

        public bool LoggedInFormOpen = false;

        LogIn LoginForm = new LogIn();

        public Network NW;

        private int m_RatingValue;

        private string SearchTerm = "";

        private string m_Comment = "";

        public StoreItem(int ID)
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

            // Asset ID assignment
            m_ID = ID;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Loading Icons
            this.LeaveReviewPanel.Hide();
            this.searchBox.Hide();
            this.UploadImagePanel.Hide();


            PacketSendType packetNumber = PacketSendType.GetAsset;
            if (!PacketControl.packets.ContainsKey((int)packetNumber))
            {
                SendData.GetAsset(m_ID);
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
            }
            this.LoadingImage.Hide();
            Console.WriteLine("Loaded");

            if (Cache.Instance.Asset.Author.ToLower() == Account.instance.GetUsername().ToLower())
            {
                this.UploadImagePanel.Show();
                this.leaveReviewBtn.Hide();
            }

            // Use Information collected from server to populate page
            Title.Text = Cache.Instance.Asset.Name;
            descriptionText.Text = Cache.Instance.Asset.Description;
            RatingLabel.Text = "Average Rating: " + Cache.Instance.Asset.Rating.ToString();

            //Apply Images to page
            for (int i = 0; i < Cache.Instance.Asset.Images.Count; i++)
            {
                Control pictureHolder = Controls.Find("pictureBox" + (i + 1), true)[0];
                PictureBox pictureBox = pictureHolder as PictureBox;
                pictureBox.Image = Cache.Instance.Asset.Images[i];
            }

            //Remove excess rows from reviews table
            int ratingCount = Cache.Instance.Asset.Ratings.Count;
            if (ratingCount < tableLayoutPanel2.RowCount)
            {

                int noReviewsCount = tableLayoutPanel2.RowCount - ratingCount;
                for (int i = tableLayoutPanel2.RowCount; i > ratingCount; --i)
                {
                    tableLayoutPanel2.RowCount--;
                    Control ratingHolder = Controls.Find("ReviewBox" + (i), true)[0];
                    ratingHolder.Dispose();
                    Control pictureHolder = Controls.Find("ReviewerAvatar" + (i), true)[0];
                    pictureHolder.Dispose();
                }
            }

            //Add rows to reviews table
            else if (ratingCount > tableLayoutPanel2.RowCount)
            {
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1];

                for (int i = tableLayoutPanel2.RowCount; i < ratingCount; i++)
                {
                    //increase panel rows count by one
                    tableLayoutPanel2.RowCount++;
                    //add a new RowStyle as a copy of the previous one
                    tableLayoutPanel2.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                    //add the control                    
                    tableLayoutPanel2.Controls.Add(new PictureBox() { Name = "ReviewerAvatar" + tableLayoutPanel2.RowCount, Image = null, Enabled = false, BorderStyle = BorderStyle.FixedSingle, Size = new Size(144, 144) }, 0, tableLayoutPanel2.RowCount - 1);
                    

                    TextBox reviewTextBox = new TextBox();
                    copyControl((TextBox)Controls.Find("ReviewBox1", true)[0], reviewTextBox);
                    reviewTextBox.Name = "ReviewBox" + tableLayoutPanel2.RowCount;
                    tableLayoutPanel2.Controls.Add(reviewTextBox, 1, tableLayoutPanel2.RowCount - 1);
                }
            }

            //Apply Ratings and comments to each control
            int ratingID = 1;
            foreach (Rating item in Cache.Instance.Asset.Ratings)
            {
                Control ratingHolder = Controls.Find("ReviewBox" + (ratingID), true)[0];
                TextBox textBox = ratingHolder as TextBox;
                textBox.Text = "Rating: " + item.rating + Environment.NewLine // Reviewers rating value
                               + item.comment; // Reviewers rating comment
                ratingHolder = Controls.Find("ReviewerAvatar" + (ratingID), true)[0];
                var imageBox = ratingHolder as PictureBox;
                imageBox.Image = item.avatar;
                imageBox.SizeMode = PictureBoxSizeMode.Zoom;
                ++ratingID;
                if (ratingID > tableLayoutPanel2.RowCount)
                    break;
            }

            tableLayoutPanel2.HorizontalScroll.Maximum = 0;
            tableLayoutPanel2.AutoScroll = false;
            tableLayoutPanel2.VerticalScroll.Visible = false;
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.AutoScrollPosition = new Point(0, 0);
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

        private void leaveReviewBtn_Click(object sender, EventArgs e)
        {
            LeaveReviewPanel.Show();
        }

        private void CancelLeaveReview_Click(object sender, EventArgs e)
        {
            LeaveReviewPanel.Hide();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            m_Comment = ReviewTextBox.Text;
            if (checkRatingsIsClicked())
            {
                if (Account.instance.isLoggedIn)
                {
                    SendData.RateAsset(m_ID, m_RatingValue, m_Comment);
                    LeaveReviewPanel.Hide();
                }
                else
                {
                    Login();
                    System.Windows.Forms.MessageBox.Show("Please log in, to leave a comment.");
                }
            }
        }

        private bool checkRatingsIsClicked()
        {
            foreach (var item in this.LeaveReviewPanel.Controls.OfType<RadioButton>())
            {
                if (item.Checked)
                {
                    m_RatingValue = Convert.ToInt32(item.Name.Substring(item.Name.Length - 1));
                    if (m_Comment != "")
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
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
            this.LeaveReviewPanel.Hide();

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

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search...")
            {
                searchBox.Text = "";
            }
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

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[;']"))
            {
                // Stop the certain characters to be entered to stop SQL injection
                e.Handled = true;
            }
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search...")
            {
                searchBox.Text = "";
            }
        }

        private void UploadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Image Files";
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                                        "All files(*.*) | *.* ";
            openFileDialog1.Multiselect = true;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                int imageNumber = 1;
                int maxImageNumber = 5;
                foreach (String file in openFileDialog1.FileNames)
                {
                    if (imageNumber <= maxImageNumber)
                    {
                        try
                        {
                            Image myBitmap = Image.FromFile(file);
                            Image image = myBitmap.GetThumbnailImage(256, 256, ThumbnailCallback, IntPtr.Zero);
                            PacketSendType packetNumber = PacketSendType.UploadImage;
                            if (!PacketControl.packets.ContainsKey((int)packetNumber))
                            {
                                SendData.UploadImage(image, m_ID, imageNumber, file.Substring(file.IndexOf(@".")));
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
                            //Apply Images to page                           
                            Control pictureHolder = Controls.Find("pictureBox" + (imageNumber), true)[0];
                            PictureBox pictureBox = pictureHolder as PictureBox;
                            pictureBox.Image = image;                            
                            ++imageNumber;
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    else
                        break;                    
                }                
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
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

        private void AddBasketButton_Click(object sender, EventArgs e)
        {
            if (Account.instance.isLoggedIn)
            {
                try
                {
                    PacketSendType packetNumber = PacketSendType.BasketRequest;

                    if (!PacketControl.packets.ContainsKey((int)packetNumber))
                    {
                        SendData.BasketRequest(BasketFunctions.Add, m_ID);
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
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                Login();
                System.Windows.Forms.MessageBox.Show("Please log in, to add to basket.");
            }
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
    }
}