using AssetCache.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace AssetCache
{
    public partial class HomePage : Form
    {
        public static HomePage instance;
        
        public bool LoggedInFormOpen = false;

        public enum Page { Home, ThreeD, TwoD, Audio, VFX, Basket, Account, Other }

        public Page currentPage;

        public Network NW;
        public Account m_account = new Account();
        private List<int> currentScreenItems = new List<int>();
        private string SearchTerm = "";
        public int maxNumberOfPages = 1;
        private int currentPageNumber = 1;

        public HomePage()
        {
            instance = this;

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
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            //NW = new Network("86.31.34.75", 5500);
            NW = new Network("35.177.136.79", 5500);
            NW.Connect();

            while (!NW.Socket.Connected)
            {
                //Rotating gif until is connected
                this.LoadingImage.Hide();
                this.LoadingImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.LoadingImage.Show();
                this.LoadingImage.Update();
            }
            RetrieveAssets("Home");
            Console.WriteLine("Connected");
            BackPageButton.Hide();            
        }

        private void AccountBtn_Click(object sender, EventArgs e)
        {
            currentPage = Page.Account;
            ShowPage();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            RetrieveAssets("Home");
        }

        public void ShowPage()
        {
            this.searchBox.Hide();
            switch (currentPage)
            {
                case Page.Account:
                     LogIn LoginForm = new LogIn();
                    if (!Network.instance.loggedIn && !LoggedInFormOpen)
                    {
                        LoginForm.Show();
                        LoggedInFormOpen = true;
                    }
                    else if (!LoggedInFormOpen && Account.instance.isLoggedIn)
                    {
                        var ac = new AccountForm();
                        ac.Show();
                        ac.BringToFront();
                    }
                    else
                    {
                        LoginForm.Hide();
                        LoggedInFormOpen = false;
                    }
                    break;

                case Page.Basket:
                    //show relevant data
                    this.PageTitle.Text = "Basket";
                    break;

                case Page.Home:
                    //shows relevant data
                    SearchTerm = "Home";
                    this.PageTitle.Text = SearchTerm;
                    SetThumbnails();
                    break;

                case Page.ThreeD:
                    //shows relevant data
                    SearchTerm = "3D";
                    this.PageTitle.Text = SearchTerm;
                    SetThumbnails();
                    break;

                case Page.TwoD:
                    //shows relevant data
                    SearchTerm = "2D";
                    this.PageTitle.Text = SearchTerm;
                    SetThumbnails();
                    break;

                case Page.Audio:
                    //show relevant data
                    SearchTerm = "Audio";
                    this.PageTitle.Text = SearchTerm;
                    SetThumbnails();
                    break;

                case Page.VFX:
                    //shows relevant data
                    SearchTerm = "VFX";
                    this.PageTitle.Text = SearchTerm;
                    SetThumbnails();
                    break;

                case Page.Other:
                    this.PageTitle.Text = "'" + SearchTerm + "'";
                    SetThumbnails();
                    break;
            }
        }

        private void threeDBtn_Click(object sender, EventArgs e)
        {
            currentPage = Page.ThreeD;
            currentPageNumber = 1;
            RetrieveAssets("3D");
        }

        private void twoDBtn_Click(object sender, EventArgs e)
        {
            currentPage = Page.TwoD;
            currentPageNumber = 1;
            RetrieveAssets("2D");
        }

        private void audioBtn_Click(object sender, EventArgs e)
        {
            currentPage = Page.Audio;
            currentPageNumber = 1;
            RetrieveAssets("Audio");
        }

        private void vfxBtn_Click(object sender, EventArgs e)
        {
            currentPage = Page.VFX;
            currentPageNumber = 1;
            RetrieveAssets("VFX");
        }

        private void basketBtn_Click(object sender, EventArgs e)
        {
            if (Account.instance.isLoggedIn)
            {
                currentPage = Page.Basket;
                currentPageNumber = 1;
                Basket basket = new Basket();
                basket.Show();
            }
            else
            {
                Login();
                System.Windows.Forms.MessageBox.Show("Please log in, to open the basket.");
            }
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            currentPage = Page.Other;
            searchBox.Show();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAssets(this, new EventArgs());
            }
        }

        private void SearchAssets(object sender, EventArgs e)
        {
            SearchTerm = searchBox.Text;
            currentPageNumber = 1;
            RetrieveAssets(SearchTerm);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PeekMessage(out NativeMessage message,
                                        IntPtr handle, uint filterMin, uint filterMax, uint flags);

        private const UInt32 WM_MOUSEFIRST = 0x0200;
        private const UInt32 WM_MOUSELAST = 0x020D;
        public const int PM_REMOVE = 0x0001;

        // Flush all pending mouse events.
        private void FlushMouseMessages()
        {
            NativeMessage msg;
            // Repeat until PeekMessage returns false.
            while (PeekMessage(out msg, IntPtr.Zero,
                WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE))
                ;
        }

        private void SetThumbnails()
        {
            int itemNumber = 0;
            Control textHolder = null;
            AssetLoadingcontrol textBox = null;
            foreach (KeyValuePair<int, Item> asset in Cache.Instance.Assets)
            {
                textHolder = Controls.Find("assetLoadingcontrol" + itemNumber, true).FirstOrDefault();
                textBox = textHolder as AssetLoadingcontrol;
                textBox.AssetName.Text = asset.Value.Name;
                if (asset.Value.Price != 0)
                    textBox.Price.Text = asset.Value.Price.ToString("C"); //C Means Currency
                else
                    textBox.Price.Text = "FREE";
                textBox.CompanyName.Text = asset.Value.Author;
                textBox.AssetPicture.Image = asset.Value.Thumbnail;
                textBox.ID = itemNumber;
                textBox.Visible = true;
                ++itemNumber;
            }
            
            while (itemNumber < 8)
            {
                textHolder = Controls.Find("assetLoadingcontrol" + itemNumber, true).FirstOrDefault();
                textBox = textHolder as AssetLoadingcontrol;
                textBox.AssetName.Text = "";
                textBox.Price.Text = "";
                textBox.CompanyName.Text = "";
                textBox.AssetPicture.Image?.Dispose();
                textBox.Visible = false;
                ++itemNumber;
            }
        }

        public void RetrieveAssets(string searchFilter)
        {    
            this.Cursor = Cursors.WaitCursor;
            this.LoadingImage.Show();
            if (!Network.instance.clicked)
            {
                Network.instance.clicked = true;
                if (searchFilter == "Home")
                {
                    PacketSendType packetNumber = PacketSendType.GetAssets;
                    if (!PacketControl.packets.ContainsKey((int)packetNumber))
                    {
                        SendData.GetAssets(8, currentPageNumber);
                        ProcessPacket(packetNumber);
                    }
                    Console.WriteLine("Loaded");
                    currentPage = Page.Home;
                }
                else
                {

                    PacketSendType packetNumber = PacketSendType.SearchRequest;
                    if (!PacketControl.packets.ContainsKey((int)packetNumber))
                    {
                        SendData.SearchRequest(searchFilter, 8, currentPageNumber);
                        ProcessPacket(packetNumber);
                    }
                    Console.WriteLine(searchFilter + " Page Loaded");
                    currentPage = Page.Other;
                }
            }
            this.LoadingImage.Hide();
            Network.instance.clicked = false;
            FlushMouseMessages();
            this.Cursor = Cursors.Default;
            PageNumber.Text = currentPageNumber.ToString() + " / " + maxNumberOfPages.ToString();
            ShowPage();
            HidePageButtons();
        }

        public void LoadAsset(int imageNumber)
        {
            int assetId = 0;
            foreach (KeyValuePair<int, Item> asset in Cache.Instance.Assets)
            {
                if (assetId == imageNumber)
                {
                    assetId = asset.Key;
                    break;
                }
                ++assetId;
            }
            StoreItem item = new StoreItem(assetId);
            item.Visible = false;
            item.Show();
            item.Visible = true;
        }

        private void SearchBoxCancel_Click(object sender, EventArgs e)
        {
            searchBox.Hide();
        }

        public void ProcessPacket(PacketSendType packetNumber)
        {
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

        private void timer_Tick(object sender, EventArgs e)
        {
            //Check user is still connected
            if (!NW.Socket.Connected)
            {
                NW.Connect();
                while (!NW.Socket.Connected)
                {
                    //Rotating gif until is connected
                    this.LoadingImage.Hide();
                    this.LoadingImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    this.LoadingImage.Show();
                    this.LoadingImage.Update();
                }
                this.LoadingImage.Hide();
                Console.WriteLine("ReConnected");
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                do
                {
                    Application.OpenForms[Application.OpenForms.Count - 1].Close();
                } while (Application.OpenForms.Count > 0);
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

        private void BackPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                --currentPageNumber;
                RetrieveAssets(SearchTerm);
            }
        }

        private void ForwaredPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < maxNumberOfPages)
            {
                ++currentPageNumber;
                RetrieveAssets(SearchTerm);
            }
        }

        private void HidePageButtons()
        {
            if (currentPageNumber == 1)
            {
                BackPageButton.Hide();
                ForwardPageButton.Show();
            }
            else
            {
                BackPageButton.Show();
                ForwardPageButton.Show();
            }
            if(currentPageNumber >= maxNumberOfPages)
            {
                ForwardPageButton.Hide();
            }
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
    }
}