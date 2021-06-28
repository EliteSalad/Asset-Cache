 using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using AssetCache.Classes;
using AssetCache.Forms;

namespace AssetCache
{
    public class ProcessData
    {
        public static void processData(byte[] data)
        {
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteBytes(data);
            int packetNumber = buffer.ReadInteger();
            buffer = null;
            if (packetNumber == 0)
                return;
            ProcessPackets(packetNumber, data);
        }

        private static void ProcessPackets(int packetNumber, byte[] data)
        {
            switch (packetNumber)
            {
                case 1:
                    RetrieveMessages(data);
                    break;

                case 2:
                    LoginResponse(data);
                    break;

                case 3:
                    LogOutNotification(data);
                    break;

                case 4:
                    KickNotification(data);
                    break;

                case 5:
                    ReturnAssets(data);
                    break;

                case 6:
                    SubmitAssetResponse(data);
                    break;

                case 7:
                    CreateAccountResponse(data);
                    break;

                case 8:
                    ReturnAsset(data);
                    break;

                case 9:
                    SearchAssets(data);
                    break;

                case 10:
                    AddImageResponse(data);
                    break;

                case 11:
                    ReceiveMessage(data);
                    break;

                case 13:
                    ConfirmMessageReceived(data);
                    break;

                case 14:
                    GetAccountList(data);
                    break;

                case 15:
                    ConnectionNotification(data);
                    break;

                case 16:
                    ReturnBasket(data);
                    break;

                default:
                    break;
            }
            PacketControl.Recieve((PacketReceivedType)packetNumber);
        }

        //Packet 1 - Retrieve Messages
        private static void RetrieveMessages(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();
                RequestType requestType = (RequestType)buffer.ReadInteger();
                if (requestType == RequestType.Inbox)
                {
                    int messageCount = buffer.ReadInteger();
                    int unreadMessageCount = buffer.ReadInteger();
                    if (Account.instance.m_inbox == null)
                    {
                        Account.instance.m_inbox = new Inbox(messageCount, unreadMessageCount,new Dictionary<int, Conversation>());
                    }
                    int conversationCount = buffer.ReadInteger();
                    for (int i = 0; i < conversationCount; i++)
                    {
                        string userName = buffer.ReadString();
                        int accountID = buffer.ReadInteger();
                        int messageCountToAccountID = buffer.ReadInteger();
                        int unreadMessageToAccountID = buffer.ReadInteger();
                        string mostRecentMessage = buffer.ReadString();
                        bool online = (buffer.ReadByte() == 1) ? true : false;
                        if (!Account.instance.m_inbox.Conversations.ContainsKey(accountID))
                        {
                            Account.instance.m_inbox.Conversations.Add(accountID, new Conversation(Account.instance.m_inbox, accountID, userName, messageCountToAccountID, unreadMessageToAccountID,mostRecentMessage,online, null));
                        }

                        bool hasAvatar = (buffer.ReadByte() == 1) ? true : false;
                        if (hasAvatar)
                        {
                            int avatarLength = buffer.ReadInteger();
                            Account.instance.m_inbox.Conversations[accountID].Avatar = buffer.ReadBytes(avatarLength);
                        }
                    }
                }
                else
                {
                    int contactID = buffer.ReadInteger();
                    string userName = buffer.ReadString();
                    int messageCount = buffer.ReadInteger();
                    int unreadMessageCount = buffer.ReadInteger();
                    if (!Account.instance.m_inbox.Conversations.ContainsKey(contactID))
                    {
                        Account.instance.m_inbox.Conversations.Add(contactID, new Conversation(Account.instance.m_inbox, contactID, userName, messageCount, unreadMessageCount,"",false, null));
                    }
                    for (int i = 0; i < messageCount; i++)
                    {
                        int messageID = buffer.ReadInteger();
                        int senderID = buffer.ReadInteger();
                        string senderUserName = buffer.ReadString();
                        int receiverID = buffer.ReadInteger();
                        string receiverUserName = buffer.ReadString();
                        string message = buffer.ReadString();
                        string sent = buffer.ReadString();
                        string received = buffer.ReadString();
                        DateTime sentDT = (sent == "NULL") ? default(DateTime) : Convert.ToDateTime(sent);
                        DateTime receivedDT = (received == "NULL") ? default(DateTime) : Convert.ToDateTime(received);
                        Account.instance.m_inbox.Conversations[contactID].Add(messageID, senderID, senderUserName, receiverID, receiverUserName, message, sentDT, receivedDT);
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Retrieve Messages, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }
        
        //Packet 2 - Login Response
        private static void LoginResponse(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();

                byte response = buffer.ReadByte();

                Network.instance.loggedIn = ((response == 1) ? true : false);
                if (Network.instance.loggedIn)
                {
                    Account.instance.Login(buffer.ReadString(), LogIn.login.password);
                    Account.instance.SetEmail(buffer.ReadString());
                    byte Check = buffer.ReadByte();
                    if (Check == 1)
                    {
                        int imageLength = buffer.ReadInteger();
                        Account.instance.avatar = byteArrayToImage(buffer.ReadBytes(imageLength));
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Login Response, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 3 - Log out Notification
        private static void LogOutNotification(byte[] data)
        {
            try
            {
                Network.instance.loggedIn = false;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Log Out Notification, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 4 - Kick Notification
        private static void KickNotification(byte[] data)
        {
            try
            {
                Network.instance.loggedIn = false;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Kick Notification, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 5 - Return Assets
        private static void ReturnAssets(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);

                int packetNumber = buffer.ReadInteger();
                int numberAssetsReturned = buffer.ReadInteger();
                int maxNumberOfAssets = buffer.ReadInteger();
                int maxNumberOfPages = buffer.ReadInteger();

                HomePage.instance.maxNumberOfPages = maxNumberOfPages;

                Cache.Instance.Assets.Clear();
                for (int i = 0; i < numberAssetsReturned; i++)
                {
                    int asset_Id = buffer.ReadInteger();

                    Cache.Instance.Assets.Add(asset_Id, new Item(asset_Id, buffer.ReadString(), buffer.ReadString(), buffer.ReadString(),
                        buffer.ReadFloat(), buffer.ReadFloat()));
                    byte check = buffer.ReadByte();
                    if (check != 0)
                    {
                        int ImageLength = buffer.ReadInteger();
                        byte[] image = buffer.ReadBytes(ImageLength);
                        Cache.Instance.Assets[asset_Id].Thumbnail = byteArrayToImage(image);
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with returning assets, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 6 - Submit Asset Response
        private static void SubmitAssetResponse(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();
                byte response = buffer.ReadByte();

                if (response == 1)
                {
                    int Asset_ID = buffer.ReadInteger();

                    for (int i = 0; i < System.Windows.Forms.Application.OpenForms.Count; i++)
                    {
                        if (System.Windows.Forms.Application.OpenForms[i].Name == "SubmitForm")
                        {
                            SubmitForm submitForm = (SubmitForm)System.Windows.Forms.Application.OpenForms[i];
                            submitForm.IDNumber = Asset_ID;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Submit Asset Response, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 7 - Create Account Response
        private static void CreateAccountResponse(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();

                byte response = buffer.ReadByte();

                string respondMessage = buffer.ReadString();
                Network.instance.CreatedAccount = ((response == 1) ? true : false);
                if (Network.instance.CreatedAccount)
                {
                    Account.instance.Register(LogIn.login.username, LogIn.login.password, LogIn.login.email);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Create Account Response, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 8 - Return Asset
        private static void ReturnAsset(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();
                
                Cache.Instance.Asset = new Item(buffer.ReadInteger(), buffer.ReadString(), buffer.ReadString(), buffer.ReadString(), buffer.ReadFloat(), buffer.ReadFloat());

                byte check = buffer.ReadByte();
                int avatarLength = 0;
                if (check == 1)
                {
                    avatarLength = buffer.ReadInteger();
                    Cache.Instance.Asset.Avatar = byteArrayToImage(buffer.ReadBytes(avatarLength));
                }

                // Add ratings to the asset in the cache
                Cache.Instance.Asset.Ratings = new List<Rating>();
                int ratingsCount = buffer.ReadInteger();
                for (int h = 0; h < ratingsCount; h++)
                {
                    Cache.Instance.Asset.Ratings.Add(new Rating(buffer.ReadInteger(), buffer.ReadString(), buffer.ReadString()));
                    check = buffer.ReadByte();
                    if (check == 1)
                    {
                        avatarLength = buffer.ReadInteger();
                        Cache.Instance.Asset.Ratings[h].avatar = byteArrayToImage(buffer.ReadBytes(avatarLength));
                    }

                }

                // Add images to the asset in the cache
                List<Image> i = new List<Image>();
                int imageCount = buffer.ReadInteger();
                for (int j = 0; j < imageCount; j++)
                {
                    int imageSize = buffer.ReadInteger();
                    i.Add(byteArrayToImage(buffer.ReadBytes(imageSize)));
                }
                Cache.Instance.Asset.Images = i;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Return Asset, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 9 - Search
        private static void SearchAssets(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);

                int packetNumber = buffer.ReadInteger();
                int pageCount = buffer.ReadInteger();
                int assetCount = buffer.ReadInteger();

                Cache.Instance.Assets.Clear();
                for (int i = 0; i < assetCount; i++)
                {
                    int asset_Id = buffer.ReadInteger();
                    Cache.Instance.Assets.Add(asset_Id, new Item(asset_Id, buffer.ReadString(), buffer.ReadString(), buffer.ReadString(), buffer.ReadFloat(), buffer.ReadFloat()));
                    byte hasImage = buffer.ReadByte();
                    if (hasImage == 1)
                    {
                        int imageLength = buffer.ReadInteger();
                        Cache.Instance.Assets[asset_Id].Thumbnail = byteArrayToImage(buffer.ReadBytes(imageLength));
                    }
                }
                Cache.Instance.pageCount = pageCount;
                HomePage.instance.maxNumberOfPages = pageCount;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Search Assets, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
                Cache.Instance.pageCount = -1;
            }
        }

        //Packet 10 - Image Response
        private static void AddImageResponse(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);

                int packetNumber = buffer.ReadInteger();
                bool isSuccessful = (buffer.ReadByte() == 1 ? true : false);
                string response = buffer.ReadString();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Image Response, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 11 - Receive Message
        private static void ReceiveMessage(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);

                int packetNumber = buffer.ReadInteger();
                int messageID = buffer.ReadInteger();
                int senderID = buffer.ReadInteger();
                string senderUserName = buffer.ReadString();
                int receiverID = buffer.ReadInteger();
                string receiverUserName = buffer.ReadString();
                string message = buffer.ReadString();
                string sent = buffer.ReadString();
                string received = buffer.ReadString();

                if (!Account.instance.m_inbox.Conversations.ContainsKey(senderID))
                {
                    Account.instance.m_inbox.Conversations.Add(senderID, new Conversation(Account.instance.m_inbox, senderID, senderUserName, 0, 0,"",false, null));
                }
                DateTime sentDT = (sent == "NULL" || sent == "") ? default(DateTime) : Convert.ToDateTime(sent);
                DateTime receivedDT = (received == "NULL" || received == "") ? default(DateTime) : Convert.ToDateTime(received);

                Account.instance.m_inbox.Conversations[senderID].Add(messageID, senderID, senderUserName, receiverID, receiverUserName, message, sentDT, receivedDT);
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i].Name == "Messenger")
                    {
                        Messenger messenger = (Messenger)Application.OpenForms[i];
                        messenger.Invoke(new Action(() => messenger.AddMessageRows(senderID, Account.instance.m_inbox.Conversations[senderID].Messages[messageID])));
                    }
                }
                SendData.MessageReceived(messageID);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Receive Message, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 13 - Confirm Message Received
        private static void ConfirmMessageReceived(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();
                int messageId = buffer.ReadInteger();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Confirm Message Received, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 14 - Get Account List
        private static void GetAccountList(byte[] data)
        {
            try
            {
                Messenger messenger = null;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i].Name == "Messenger")
                    {

                        messenger = (Messenger)Application.OpenForms[i];
                        messenger.AccountList.Clear(); 
                            break;
                    }
                }
                        ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();
                int amountResults = buffer.ReadInteger();
                for (int i = 0; i < amountResults; i++)
                {
                    string userName = buffer.ReadString();
                    int accountID = buffer.ReadInteger();
                    string email = buffer.ReadString();
                    bool loggedIn = (buffer.ReadByte() == 1) ? true : false;
                    bool hasAvatar = (buffer.ReadByte() == 1) ? true : false;
                    Image Avatar = null;
                    if (hasAvatar)
                    {
                        int avatarLength = buffer.ReadInteger();
                        Avatar = byteArrayToImage(buffer.ReadBytes(avatarLength));
                    }
                    messenger.AccountList.Add(new AccountInfo(userName, accountID, email, loggedIn, Avatar));
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Get Account List, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 15 - Connection Notification
        private static void ConnectionNotification(byte[] data)
        {
            try
            {                
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();
                int accountID = buffer.ReadInteger();
                bool status = (buffer.ReadByte() == 1) ? true : false;
                Messenger messenger = null;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i].Name == "Messenger")
                    {
                        messenger = (Messenger)Application.OpenForms[i];
                        for (int j  = 0; j < messenger.AccountList.Count; j++)
                        {
                            if (messenger.AccountList[j].accountID == accountID)
                            {
                                messenger.AccountList[j].loggedIn = status;
                                if (Account.instance.m_inbox.Conversations.ContainsKey(accountID))
                                {
                                    Account.instance.m_inbox.Conversations[accountID].Online = status;
                                    if (messenger.searchResults.ContainsKey(accountID))
                                    {
                                        messenger.ChangeState(messenger.searchResults[accountID].status, status);
                                    }
                                    if (messenger.inboxResults.ContainsKey(accountID))
                                    {
                                        messenger.ChangeState(messenger.inboxResults[accountID].status, status);
                                    }
                                }
                                return;
                            }
                        }                    
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("Error with Connection Notification, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }

        //Packet 16 - Return Basket
        private static void ReturnBasket(byte[] data)
        {
            try
            {
                ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                buffer.WriteBytes(data);
                int packetNumber = buffer.ReadInteger();

                int itemCount = buffer.ReadInteger();
                Cache.Instance.basketItemIDs.Clear();
                for (int i = 0; i < itemCount; i++)
                {                    
                    Cache.Instance.basketItemIDs.Add(buffer.ReadInteger());
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Return Basket, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
            }
        }


        //Convert byte array to image
        private static Image byteArrayToImage(byte[] data)
        {
            MemoryStream MS = new MemoryStream(data);
            Image returnImage = Image.FromStream(MS);
            return returnImage;
        }
    }
}