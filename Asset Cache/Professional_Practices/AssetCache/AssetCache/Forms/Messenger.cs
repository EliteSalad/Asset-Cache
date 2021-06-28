using AssetCache.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetCache
{

    public partial class Messenger : Form
    {
        public Network NW;
        const int lineHeight = 30;
        LogIn LoginForm = new LogIn();
        public static bool LoggedInFormOpen = false;
        private string SearchTerm = "";
        public int openContact = -1;
        private RowStyle InboxRowStyle = null;
        private RowStyle AccountRowStyle = null;
        private RowStyle MessageRowStyle = null;
        public List<AccountInfo> AccountList = new List<AccountInfo>();
        public Dictionary<int, SimpleAccountInfo> searchResults = new Dictionary<int, SimpleAccountInfo>();
        public Dictionary<int, InboxAccount> inboxResults = new Dictionary<int, InboxAccount>();

        public Messenger()
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
                // 
                // AccountBtn
                // 
                this.AccountBtn.BackColor = Color.Transparent;
                this.AccountBtn.BackgroundImage = Properties.Resources.LoginIcon;
                this.AccountBtn.BackgroundImageLayout = ImageLayout.Stretch;
                //Some test for the location of the button
                this.AccountBtn.Location = new Point(25, h - 60);
                this.AccountBtn.Name = "AccountBtn";
                this.AccountBtn.Size = new Size(40, 40);
                this.AccountBtn.TabIndex = 0;
                this.AccountBtn.TabStop = false;
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
            this.searchBox.Hide();
            this.LoadingImage.Hide();
            MessagePanel.Hide();
            CurrentConversationPanel.Show();
            AccountListPanel.Hide();
            AccountSearch.Hide();
            if (InboxRowStyle == null)
            {
                InboxRowStyle = CurrentConversationPanel.RowStyles[0];
            }
            if (AccountRowStyle == null)
            {
                AccountRowStyle = AccountListPanel.RowStyles[0];
            }
            if (MessageRowStyle == null)
            {
                MessageRowStyle = MessagesPanel.RowStyles[0];
            }
            LoadConversations();
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
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[;'\n]"))
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

        private void SubmitAssetBtn_Click(object sender, EventArgs e)
        {
            SubmitForm submitForm = new SubmitForm();
            submitForm.Visible = false;
            submitForm.Show();
            submitForm.Visible = true;
        }

        private void LoadMessages(int ContactID, Image avatar = null)
        {
            openContact = ContactID;
            CurrentConversationPanel.Hide();
            MessagePanel.Show();
            MessagePanel.BringToFront();
            Title.BringToFront();
            // Get Messages

            PacketSendType packetNumber = PacketSendType.RequestMessages;
            if (!PacketControl.packets.ContainsKey((int)packetNumber))
            {
                SendData.RequestConversation(RequestType.Specific, ContactID);
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


            int messageCount = Account.instance.m_inbox.Conversations[ContactID].Messages.Count;
            if (MessagesPanel.RowCount < messageCount)
            {
                for (int i = MessagesPanel.RowCount; i < messageCount; i++)
                {
                    //increase panel rows count by one
                    MessagesPanel.RowCount++;
                    //add a new RowStyle as a copy of the previous one
                    MessagesPanel.RowStyles.Add(new RowStyle(MessageRowStyle.SizeType, MessageRowStyle.Height));
                    MessagesPanel.Controls.Add(new MessageBox() { Name = "messageBox" + MessagesPanel.RowCount.ToString("00000"), Margin = Padding.Empty}, 0, MessagesPanel.RowCount - 1);
                }
            }
            else
            {
                for (int i = MessagesPanel.RowCount; i > messageCount; --i)
                {
                    string controlName = "messageBox" + i.ToString("00000");
                    Control messageHolder = MessagesPanel.Controls.Find(controlName, true)[0];
                    messageHolder.Dispose();
                    MessagesPanel.RowCount--;
                }
            }

            int messageNumber = 1;
            foreach (KeyValuePair<int, Message> message in Account.instance.m_inbox.Conversations[ContactID].Messages)
            {
                if (message.Value.Receiver_ID != Account.instance.m_inbox.Conversations[ContactID].Owner_ID && message.Value.Received == default(DateTime))
                {
                    SendData.MessageReceived(message.Key);
                }

                string controlName = "messageBox" + messageNumber.ToString("00000");
                MessageBox messageBox = (MessageBox)MessagesPanel.Controls.Find(controlName, true)[0];
                messageBox.messageTextBox.Text = message.Value.message.Replace("`", "'");
                messageBox.messageTextBox.Size = new Size(messageBox.messageTextBox.Size.Width, messageBox.messageTextBox.Lines.Count() * lineHeight);
                if (message.Value.Sender_ID == ContactID)
                {
                    messageBox.messageTextBox.TextAlign = HorizontalAlignment.Left;
                }
                else
                {
                    messageBox.messageTextBox.TextAlign = HorizontalAlignment.Right;
                }

                ++messageNumber;
                if (messageNumber > MessagesPanel.RowCount)
                    break;
            }

            if (Account.instance.m_inbox.Conversations[ContactID].Avatar == null && avatar != null)
            {
                ContactAvatar.BackgroundImage = avatar;
            }
            else if (Account.instance.m_inbox.Conversations[ContactID].Avatar != null)
            {
                ContactAvatar.BackgroundImage = byteArrayToImage(Account.instance.m_inbox.Conversations[ContactID].Avatar);
            }
            else
            {
                ContactAvatar.BackgroundImage = null;
            }
            Title.Text = Account.instance.m_inbox.Conversations[ContactID].Username;
            MessagesPanel.HorizontalScroll.Maximum = 0;
            MessagesPanel.AutoScroll = false;
            MessagesPanel.VerticalScroll.Visible = false;
            MessagesPanel.AutoScroll = true;
            if (MessagesPanel.RowCount > 0)
            {
                string controlName = "messageBox" + MessagesPanel.RowCount.ToString("00000");
                MessagesPanel.ScrollControlIntoView(Controls.Find(controlName, true)[0]);
            }
        }

        private void ContactAvatar_Click(object sender, EventArgs e)
        {
            //TODO: go to contacts profile
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            if (CurrentMessage.Text != "")
            {
                PacketSendType packetNumber = PacketSendType.SendMessage;
                if (!PacketControl.packets.ContainsKey((int)packetNumber))
                {
                    SendData.SendMessage(openContact, CurrentMessage.Text.Replace("'", "`"));

                    RowStyle rowStyle = MessagesPanel.RowStyles[0];
                    //increase panel rows count by one
                    MessagesPanel.RowCount++;
                    //add a new RowStyle as a copy of the previous one
                    MessagesPanel.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));

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

                    string controlName = "messageBox" + MessagesPanel.RowCount.ToString("00000");
                    MessagesPanel.Controls.Add(new MessageBox() { Name = controlName, Margin = Padding.Empty }, 0, MessagesPanel.RowCount - 1);
                    MessageBox messageBox = (MessageBox)Controls.Find(controlName, true)[0];

                    messageBox.messageTextBox.ForeColor = Color.White;
                    messageBox.messageTextBox.Text = CurrentMessage.Text;
                    messageBox.messageTextBox.TextAlign = HorizontalAlignment.Right;
                    messageBox.messageTextBox.Size = new Size(messageBox.messageTextBox.Size.Width, messageBox.messageTextBox.Lines.Count() * lineHeight);
                    MessagesPanel.ScrollControlIntoView(messageBox.messageTextBox);
                }
                this.LoadingImage.Hide();
                CurrentMessage.Text = "";
            }
        }

        public void Conversation(object sender, EventArgs e)
        {
            InboxAccount temp = sender as InboxAccount;
            int conversaionNumber = Convert.ToInt32(temp.Name.Substring(temp.Name.Length - 5)) - 1;
            int i = 0;
            foreach (KeyValuePair<int, Conversation> item in Account.instance.m_inbox.Conversations)
            {
                if (i == conversaionNumber)
                {
                    LoadMessages(item.Value.Owner_ID);
                    break;
                }
                ++i;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            openContact = -1;
            CurrentConversationPanel.Show();
            CurrentMessage.Text = "";
            MessagePanel.SendToBack();
            MessagePanel.Hide();
            LoadConversations();
        }

        //Convert byte array to image
        public Image byteArrayToImage(byte[] data)
        {
            MemoryStream MS = new MemoryStream(data);
            Image returnImage = Image.FromStream(MS);
            return returnImage;
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

        public void AddMessageRows(int senderID, Message message)
        {
            if (senderID == openContact)
            {
                //increase panel rows count by one
                MessagesPanel.RowCount++;
                //add a new RowStyle as a copy of the previous one
                MessagesPanel.RowStyles.Add(new RowStyle(AccountRowStyle.SizeType, AccountRowStyle.Height));

                string controlName = "messageBox" + MessagesPanel.RowCount.ToString("00000");
                MessagesPanel.Controls.Add(new MessageBox() { Name = controlName, Margin = Padding.Empty }, 0, MessagesPanel.RowCount - 1);
                MessageBox messageBox = (MessageBox)Controls.Find(controlName, true)[0];
                string messageText = message.message.Replace("`", "'");


                messageBox.messageTextBox.TextAlign = HorizontalAlignment.Left;
                messageBox.messageTextBox.Text = messageText;
                messageBox.messageTextBox.Size = new Size(messageBox.messageTextBox.Size.Width, messageBox.messageTextBox.Lines.Count() * lineHeight);
                MessagesPanel.ScrollControlIntoView(messageBox.messageTextBox);
            }
        }

        private void CurrentMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CurrentMessage.Text != "")
                {
                    PacketSendType packetNumber = PacketSendType.SendMessage;
                    if (!PacketControl.packets.ContainsKey((int)packetNumber))
                    {
                        SendData.SendMessage(openContact, CurrentMessage.Text.Replace("'", "`"));

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

                        RowStyle rowStyle = MessagesPanel.RowStyles[0];
                        //increase panel rows count by one
                        MessagesPanel.RowCount++;
                        //add a new RowStyle as a copy of the previous one
                        MessagesPanel.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));


                        string controlName = "messageBox" + MessagesPanel.RowCount.ToString("00000");
                        MessagesPanel.Controls.Add(new MessageBox() { Name = controlName, Margin = Padding.Empty }, 0, MessagesPanel.RowCount - 1);
                        MessageBox messageBox = (MessageBox)Controls.Find(controlName, true)[0];

                        messageBox.messageTextBox.TextAlign = HorizontalAlignment.Right;
                        messageBox.messageTextBox.ForeColor = Color.White;
                        messageBox.messageTextBox.Text = CurrentMessage.Text;
                        messageBox.messageTextBox.Size = new Size(messageBox.messageTextBox.Size.Width, messageBox.messageTextBox.Lines.Count() * lineHeight);
                        MessagesPanel.ScrollControlIntoView(messageBox.messageTextBox);
                    }
                    this.LoadingImage.Hide();
                    CurrentMessage.Text = "";
                }
                else
                {
                    CurrentMessage.Text = "";
                }
            }

        }

        private void NewMessage_Click(object sender, EventArgs e)
        {
            AccountListPanel.Show();
            for (int i = 0; i < AccountListPanel.RowCount; i++)
            {
                string controlName = "simpleAccountInfo" + (i + 1).ToString("00000");
                SimpleAccountInfo accountInfo = (SimpleAccountInfo)AccountListPanel.Controls.Find(controlName, true)[0];
                accountInfo.Margin = Padding.Empty;
                accountInfo.Location = new Point(0, 0);
                accountInfo.AutoSize = true;
            }
            AccountSearch.Show();
            SearchAccountList();
        }

        private void AccountSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAccountList();
            }
        }

        private void SearchAccountList()
        {
            PacketSendType packetNumber = PacketSendType.SearchAccountList;
            if (!PacketControl.packets.ContainsKey((int)packetNumber))
            {
                if (AccountSearch.Text == "Search...")
                {
                    AccountSearch.Text = "";
                }
                SendData.SearchAccountList(AccountSearch.Text);

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

                if (AccountListPanel.RowCount < AccountList.Count)
                {

                    for (int i = AccountListPanel.RowCount; i < AccountList.Count; i++)
                    {
                        //increase panel rows count by one
                        AccountListPanel.RowCount++;
                        //add a new RowStyle as a copy of the previous one
                        AccountListPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                        string controlName = "simpleAccountInfo" + AccountListPanel.RowCount.ToString("00000");
                        AccountListPanel.Controls.Add(new SimpleAccountInfo()
                        {
                            Name = controlName,
                            Location = new Point(0, 0),
                            Margin = Padding.Empty
                        }, 0, AccountListPanel.RowCount - 1);
                    }
                    AccountListPanel.HorizontalScroll.Maximum = 0;
                    AccountListPanel.AutoScroll = false;
                    AccountListPanel.VerticalScroll.Visible = false;
                    AccountListPanel.AutoScroll = true;
                }
                else
                {
                    for (int i = AccountListPanel.RowCount; i > AccountList.Count; --i)
                    {
                        AccountListPanel.RowCount--;
                        Control accountInfo = AccountListPanel.Controls.Find("simpleAccountInfo" + (AccountListPanel.RowCount + 1).ToString("00000"), true)[0];
                        accountInfo.Dispose();
                    }
                }
                searchResults.Clear();
                for (int i = 0; i < AccountList.Count; i++)
                {
                    string controlName = "simpleAccountInfo" + (i + 1).ToString("00000");
                    SimpleAccountInfo temp = (SimpleAccountInfo)AccountListPanel.Controls.Find(controlName, true)[0];
                    temp.Margin = Padding.Empty;
                    temp.AvatarImage.BackgroundImage = AccountList[i].avatar;
                    temp.AccountName.Text = AccountList[i].userName;
                    ChangeState(temp.status, AccountList[i].loggedIn);
                    searchResults.Add(AccountList[i].accountID, temp);
                }
            }
        }

        public void OpenConversation(int inList)
        {
            for (int i = 0; i < AccountList.Count; i++)
            {
                if (i == inList - 1)
                {
                    openContact = AccountList[i].accountID;
                    LoadMessages(AccountList[i].accountID, AccountList[i].avatar);
                    break;
                }
            }
        }

        private void InboxButton_Click(object sender, EventArgs e)
        {
            openContact = -1;
            CurrentConversationPanel.Show();
            CurrentMessage.Text = "";
            MessagePanel.SendToBack();
            MessagePanel.Hide();
        }

        private void LoadConversations()
        {
            PacketSendType packetNumber = PacketSendType.RequestMessages;
            if (!PacketControl.packets.ContainsKey((int)packetNumber))
            {
                SendData.RequestConversation(RequestType.Inbox);
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

            Title.Text = "Inbox";


            // Get Inbox
            int conversationCount = Account.instance.m_inbox.Conversations.Count;

            if (CurrentConversationPanel.RowCount < conversationCount)
            {
                for (int i = CurrentConversationPanel.RowCount; i < conversationCount; i++)
                {
                    //increase panel rows count by one
                    CurrentConversationPanel.RowCount++;
                    //add a new RowStyle as a copy of the previous one
                    CurrentConversationPanel.RowStyles.Add(new RowStyle(InboxRowStyle.SizeType, InboxRowStyle.Height));
                    CurrentConversationPanel.Controls.Add(new InboxAccount() { Name = "inboxAccount" + CurrentConversationPanel.RowCount.ToString("00000"), Margin = Padding.Empty }, 0, CurrentConversationPanel.RowCount - 1);
                }
            }
            else
            {
                for (int i = CurrentConversationPanel.RowCount; i > conversationCount; --i)
                {
                    Control accountHolder = Controls.Find("inboxAccount" + CurrentConversationPanel.RowCount.ToString("00000"), true)[0];
                    accountHolder.Dispose();
                    CurrentConversationPanel.RowCount--;
                }
            }

            inboxResults.Clear();
            int contactNumber = 1;
            foreach (KeyValuePair<int, Conversation> Contact in Account.instance.m_inbox.Conversations)
            {
                string controlName = "inboxAccount" + contactNumber.ToString("00000");
                InboxAccount account = (InboxAccount)CurrentConversationPanel.Controls.Find(controlName, true)[0];
                account.AccountName.Text = Contact.Value.Username;
                account.RecentMessageBox.Text = Contact.Value.MostRecentMessage;                
                ChangeState(account.status, Contact.Value.Online);

                if (Contact.Value.Avatar != null)
                {
                    account.AvatarImage.BackgroundImage = byteArrayToImage(Contact.Value.Avatar);
                }
                inboxResults.Add(Contact.Value.Owner_ID, account);
                ++contactNumber;
                if (contactNumber > CurrentConversationPanel.RowCount)
                    break;
            }

            CurrentConversationPanel.HorizontalScroll.Maximum = 0;
            CurrentConversationPanel.AutoScroll = false;
            CurrentConversationPanel.VerticalScroll.Visible = false;
            CurrentConversationPanel.AutoScroll = true;
            CurrentConversationPanel.AutoScrollPosition = new Point(0, 0);
        }

        public void ChangeState(PictureBox pictureBox, bool online)
        {
            pictureBox.Image = (online) ? Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Online.png")) :
                       Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Offline.png"));
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