using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetCache
{
    public class PacketControl
    {
        private static Thread packetControlThread;
        public static Dictionary<int, PacketTrackInfo> packets = new Dictionary<int, PacketTrackInfo>();
        public static double secondsBeforeResend = 5.0;

        public PacketControl()
        {
            packetControlThread = new Thread(new ThreadStart(Start));
            packetControlThread.Start();
        }

        public void Start()
        {
            while (true)
            {
                foreach (var packet in packets)
                {
                    packet.Value.resendPacket();
                }
            }
        }

        public static void Add(PacketSendType packetNumber, PacketReceivedType packetNumberExpected,
            object Param1 = null, object Param2 = null, object Param3 = null,
            object Param4 = null, object Param5 = null)
        {
            if (!packets.ContainsKey((int)packetNumber))
            {
                packets.Add((int)packetNumber, new PacketTrackInfo(packetNumber, packetNumberExpected, Param1, Param2, Param3, Param4, Param5));
            }
        }

        public static void Send(PacketSendType packetNumber)
        {
            packets[(int)packetNumber].resendPacket();
        }

        public static void Recieve(PacketReceivedType packetNumber)
        {
            foreach (var packet in packets)
            {
                if (packet.Value.packetNumberExpected == packetNumber)
                {
                    packets.Remove(packet.Key);
                    break;
                }
            }
        }
    }

    public class PacketTrackInfo
    {
        public PacketSendType packetNumberSent = PacketSendType.NONE;
        public PacketReceivedType packetNumberExpected = PacketReceivedType.NONE;
        public bool packetRecieved = false;
        public bool packetSent = false;
        public DateTime sentTime = default(DateTime);
        public DateTime resendTime = default(DateTime);
        public object param1;
        public object param2;
        public object param3;
        public object param4;
        public object param5;

        public PacketTrackInfo(PacketSendType PacketNumberSent, PacketReceivedType PacketNumberExpected,
            object Param1 = null, object Param2 = null, object Param3 = null,
            object Param4 = null, object Param5 = null)
        {
            packetNumberSent = PacketNumberSent;
            packetNumberExpected = PacketNumberExpected;
            sentTime = DateTime.Now;
            resendTime = sentTime.AddSeconds(PacketControl.secondsBeforeResend);
            packetSent = true;
            param1 = Param1;
            param2 = Param2;
            param3 = Param3;
            param4 = Param4;
            param5 = Param5;
        }

        public void resendPacket()
        {
            if (packetNumberSent != PacketSendType.NONE)
            {
                if (DateTime.Now >= resendTime)
                {
                    resendTime = DateTime.Now.AddSeconds(PacketControl.secondsBeforeResend);
                    Console.WriteLine("Loading");
                    switch (packetNumberSent)
                    {
                        case PacketSendType.NONE:
                            break;
                        //case PacketSendType.connectivityConfirmation:
                        //  SendData.connectivityConfirmation();
                        //  break;
                        case PacketSendType.Login:
                            SendData.Login(param1.ToString(), param2.ToString());
                            break;
                        case PacketSendType.SubmitAsset:
                            SendData.SubmitAsset(param1.ToString(), param2.ToString(), Convert.ToSingle(param3));
                            break;
                        case PacketSendType.GetAssets:
                            SendData.GetAssets(Convert.ToInt32(param1), Convert.ToInt32(param2));
                            break;
                        case PacketSendType.RateAsset:
                            SendData.RateAsset(Convert.ToInt32(param1), Convert.ToInt32(param2), param3.ToString());
                            break;
                        case PacketSendType.CreateAccount:
                            SendData.CreateAccount(param1.ToString(), param2.ToString(), param3.ToString());
                            break;
                        case PacketSendType.LogOut:
                            SendData.LogOut();
                            break;
                        case PacketSendType.GetAsset:
                            SendData.GetAsset(Convert.ToInt32(param1));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
