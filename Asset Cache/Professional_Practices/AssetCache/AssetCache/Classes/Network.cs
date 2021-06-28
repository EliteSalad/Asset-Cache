using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;

namespace AssetCache
{
    public enum Format
    {
        MemoryBmp,
        Bmp,
        Emf,
        Wmf,
        Gif,
        Jpeg,
        Png,
        Tiff,
        Exif,
        Icon,
        NONE,
    }

    public enum PacketSendType
    {
        NONE,
        RequestMessages,
        Login,
        SubmitAsset,
        GetAssets,
        RateAsset,
        CreateAccount,
        LogOut,
        GetAsset,
        SearchRequest,
        UploadImage,
        SendMessage,
        MessageReceived,
        SearchAccountList,
        BasketRequest,
    };

    public enum PacketReceivedType
    {
        NONE = 0,
        RequestMessages = 1,
        Login = 2,
        SubmitAsset = 6,
        GetAssets = 5,
        RateAsset = -1,
        CreateAccount = 7,
        LogOut = 3,
        GetAsset = 8,
        SearchRequest = 9,
        UploadImage = 10,
        SendMessage = 13,
        SearchAccountList = 14,
        ReturnBasket = 16,
    };

    public class Network
    {
        public static Network instance;
        public bool loggedIn;
        public bool CreatedAccount;
        public DateTime timeOfPacketSent;
        public bool packetSent = false;
        public int expectedResponse = -1;
        public bool responseReceived = false;
        public bool clicked = false;

        private string IP;
        private int Port;
        public TcpClient Socket;
        public NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public Cache cache;

        private byte[] AsyncBuff;
        private bool isConnected;
        private Account account = new Account();

        const int bufferSize = 20971520;

        public Network(string ip, int port)
        {
            IP = ip;
            Port = port;
            instance = this;
            cache = new Cache();
            timeOfPacketSent = default(DateTime);
        }

        public void Disconnect()
        {
            isConnected = false;
            if (Socket != null)
            {
                Socket.Close();
                Socket = null;
            }
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (reader != null)
            {
                reader.Close();
                reader = null;
            }
            if (writer != null)
            {
                writer.Close();
                writer = null;
            }
        }

        public void Connect()
        {
            try
            {
                if (Socket != null)
                {
                    if (Socket.Connected || isConnected)
                        return;
                    Socket.Close();
                    Socket = null;
                }

                Socket = new TcpClient();
                Socket.ReceiveBufferSize = bufferSize;
                Socket.SendBufferSize = bufferSize;
                Socket.NoDelay = false;
                Array.Resize(ref AsyncBuff, bufferSize * 2);

                Socket.BeginConnect(IP, Port, new AsyncCallback(ConnectCallback), Socket);

                isConnected = true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with Connect, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
                Cache.Instance.pageCount = -1;
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                if (Socket != null)
                {
                    Socket.EndConnect(ar);
                    if (!Socket.Connected)
                    {
                        isConnected = false;
                        Disconnect();
                        return;
                    }
                    else
                    {
                        Socket.NoDelay = true;
                        stream = Socket.GetStream();
                        stream.BeginRead(AsyncBuff, 0, bufferSize, onReceive, null);
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error with ConnectCallback, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
                Cache.Instance.pageCount = -1;
            }
        }

        private void onReceive(IAsyncResult ar)
        {
            Console.WriteLine("Recieved");
            try
            {
                if (Socket != null)
                {
                    int ReadBytes = stream.EndRead(ar);
                    byte[] newBytes = null;
                    Array.Resize(ref newBytes, ReadBytes);
                    Buffer.BlockCopy(AsyncBuff, 0, newBytes, 0, ReadBytes);
                    if (ReadBytes == 0)
                    {
                        Disconnect();
                        account.LogOut();
                        return;
                    }

                    ProcessData.processData(newBytes);
                    if (Socket == null)
                        return;
                    stream.BeginRead(AsyncBuff, 0, bufferSize, onReceive, null);
                }
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("Error with onReceive, error message: " + e.Message + ". This could be due to the server, please contact James to restart the server if necessary");
                Cache.Instance.pageCount = -1;
            }
            
        }

        public Format ConvertType(string format)
        {
            
            if (format.ToLower() == ".bmp")
            {
                return Format.Bmp;
            }
            else if (format.ToLower() == ".jpeg" || format.ToLower() == ".jpg")
            {
                return Format.Jpeg;
            }
            else if (format.ToLower() == ".gif")
            {
                return Format.Gif;
            }
            else if (format.ToLower() == ".exif")
            {
                return Format.Exif;
            }
            else if (format.ToLower() == ".emf")
            {
                return Format.Emf;
            }
            else if (format.ToLower() == ".png")
            {
                return Format.Png;
            }
            else if (format.ToLower() == ".tiff")
            {
                return Format.Tiff;
            }
            else if (format.ToLower() == ".wmf")
            {
                return Format.Wmf;
            }
            else if (format.ToLower() == ".icon")
            {
                return Format.Icon;
            }
            else
            {
                return Format.NONE;
            }
        }
    }
}