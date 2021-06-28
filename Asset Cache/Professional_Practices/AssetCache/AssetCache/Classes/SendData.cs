using System;
using System.Drawing;
using System.IO;

namespace AssetCache
{
    public enum BasketFunctions
    {
        Request,
        Add,
        Remove,
        Clear,
    }

    public class SendData
    {
        public static void sendData(byte[] data)
        {
            try
            {
                if (!Network.instance.Socket.Connected)
                {
                    Network.instance.Connect();
                }
                else
                {
                    ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
                    buffer.WriteBytes(data);
                    Network.instance.stream.BeginWrite(buffer.ToArray(), 0, buffer.ToArray().Length, null, null);
                    buffer = null;
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error with Connecting, error message: " + e.Message);
            }
        }

        //Packet 1 - Request Conversation
        public static PacketSendType RequestConversation(RequestType requestType, int conversationID = -1)
        {
            PacketControl.Add(PacketSendType.RequestMessages, PacketReceivedType.RequestMessages, requestType, conversationID);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.RequestMessages);
            buffer.WriteInteger((int)requestType);
            if (requestType == RequestType.Specific && conversationID > 0)
            {
                Console.WriteLine("Request packet 1 " + conversationID.ToString());
                buffer.WriteInteger(conversationID);
            }          
            else
                Console.WriteLine("Request packet 1 " + conversationID.ToString());

            sendData(buffer.ToArray());
            return PacketSendType.RequestMessages;
        }

        //Packet 2 - Login Attempt
        public static PacketSendType Login(string username, string password)
        {
            PacketControl.Add(PacketSendType.Login, PacketReceivedType.Login, username, password);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.Login);
            buffer.WriteString(username);
            buffer.WriteString(password);
            sendData(buffer.ToArray());
            return PacketSendType.Login;
        }

        //Packet 3 - Submit Asset
        public static PacketSendType SubmitAsset(string AssetName, string Description, float Price)
        {
            PacketControl.Add(PacketSendType.SubmitAsset, PacketReceivedType.SubmitAsset, AssetName, Description, Price);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.SubmitAsset);
            buffer.WriteString(AssetName);
            buffer.WriteString(Description);
            buffer.WriteFloat(Price);
            sendData(buffer.ToArray());
            return PacketSendType.SubmitAsset;
        }

        //Packet 4 - Get Assets
        public static PacketSendType GetAssets(int AssetsPerPageToReturn, int PageNumber)
        {
            PacketControl.Add(PacketSendType.GetAssets, PacketReceivedType.GetAssets, AssetsPerPageToReturn, PageNumber);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.GetAssets);
            buffer.WriteInteger(AssetsPerPageToReturn);
            buffer.WriteInteger(PageNumber);
            sendData(buffer.ToArray());
            return PacketSendType.GetAssets;
        }

        //Packet 5 - Rate Asset
        public static PacketSendType RateAsset(int AssetID, int Rating, string Comment)
        {
            PacketControl.Add(PacketSendType.RateAsset, PacketReceivedType.RateAsset, AssetID, Rating);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.RateAsset);
            buffer.WriteInteger(AssetID);
            buffer.WriteInteger(Rating);
            buffer.WriteString(Comment);
            sendData(buffer.ToArray());
            return PacketSendType.RateAsset;
        }

        //Packet 6 - Create Account
        public static PacketSendType CreateAccount(string username, string password, string email)
        {
            PacketControl.Add(PacketSendType.CreateAccount, PacketReceivedType.CreateAccount, username, password, email);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.CreateAccount);
            buffer.WriteString(username);
            buffer.WriteString(password);
            buffer.WriteString(email);
            sendData(buffer.ToArray());
            return PacketSendType.CreateAccount;
        }

        //Packet 7 - Log out
        public static PacketSendType LogOut()
        {
            PacketControl.Add(PacketSendType.LogOut, PacketReceivedType.LogOut);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.LogOut);
            sendData(buffer.ToArray());
            return PacketSendType.LogOut;
        }

        //Packet 8 - GetAsset
        public static PacketSendType GetAsset(int asset_id)
        {
            PacketControl.Add(PacketSendType.GetAsset, PacketReceivedType.GetAsset, asset_id);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.GetAsset);
            buffer.WriteInteger(asset_id);
            sendData(buffer.ToArray());
            return PacketSendType.GetAsset;
        }

        //Packet 9 - SearchRequest
        public static PacketSendType SearchRequest(string searchPhrase, int resultsPerPage, int pageNumber)
        {
            PacketControl.Add(PacketSendType.SearchRequest, PacketReceivedType.SearchRequest, searchPhrase, resultsPerPage, pageNumber);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.SearchRequest);
            buffer.WriteString(searchPhrase);
            buffer.WriteInteger(resultsPerPage);
            buffer.WriteInteger(pageNumber);
            sendData(buffer.ToArray());
            return PacketSendType.SearchRequest;
        }

        //Packet 10 - Upload Image
        public static PacketSendType UploadImage(Image image, int assetID, int imageNumber, string fileExtension,  bool avatar = false)
        {
            PacketControl.Add(PacketSendType.UploadImage, PacketReceivedType.UploadImage, image, assetID, imageNumber);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.UploadImage);
            buffer.WriteInteger(assetID);
            buffer.WriteByte((avatar) ? (byte)1 : (byte)0);
            buffer.WriteInteger((int)Network.instance.ConvertType(fileExtension));
            byte[] img = ImageToByteArray(image);
            buffer.WriteInteger(img.Length);
            buffer.WriteBytes(img);
            if (!avatar)            
                buffer.WriteInteger(imageNumber);            
            sendData(buffer.ToArray());
            return PacketSendType.UploadImage;
        }

        //Packet 11 - Send Message
        public static PacketSendType SendMessage(int destinationID, string message )
        {
            PacketControl.Add(PacketSendType.SendMessage, PacketReceivedType.SendMessage, destinationID, message);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.SendMessage);
            buffer.WriteInteger(destinationID);
            buffer.WriteString(message);
            sendData(buffer.ToArray());
            return PacketSendType.SendMessage;
        }

        //Packet 12 - Message Received
        public static PacketSendType MessageReceived(int messageID)
        {
            PacketControl.Add(PacketSendType.MessageReceived, PacketReceivedType.NONE, messageID);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.MessageReceived);
            buffer.WriteInteger(messageID);
            sendData(buffer.ToArray());
            return PacketSendType.MessageReceived;
        }

        //Packet 13 - Search Account List
        public static PacketSendType SearchAccountList(string searchPhrase)
        {
            PacketControl.Add(PacketSendType.SearchAccountList, PacketReceivedType.SearchAccountList, searchPhrase);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.SearchAccountList);
            buffer.WriteString(searchPhrase);
            sendData(buffer.ToArray());
            return PacketSendType.SearchAccountList;
        }

        //Packet 14 - Basket Request
        public static PacketSendType BasketRequest(BasketFunctions requestType, int assetID = -1)
        {
            PacketControl.Add(PacketSendType.BasketRequest, PacketReceivedType.ReturnBasket);
            ByteBuffer.ByteBuffer buffer = new ByteBuffer.ByteBuffer();
            buffer.WriteInteger((int)PacketSendType.BasketRequest);
            buffer.WriteInteger((int)requestType);
            buffer.WriteInteger(assetID);
            sendData(buffer.ToArray());
            return PacketSendType.BasketRequest;
        }

        private static byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}