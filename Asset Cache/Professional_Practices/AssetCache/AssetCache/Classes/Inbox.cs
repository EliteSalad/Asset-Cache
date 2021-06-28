using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetCache
{
    public enum RequestType
    {
        Inbox,
        Specific
    }
    public class Message
    {
        public int Message_ID = -1;
        public int Sender_ID = -1;
        public string Sender_Username = "";
        public int Receiver_ID = -1;
        public string Receiver_Username = "";
        public string message = "";
        public DateTime Sent = default(DateTime);
        public DateTime Received = default(DateTime);

        public Message(int message_ID, int sender_ID, string sender_Username,
            int receiver_ID, string receiver_Username,
            string _message, DateTime sent, DateTime received = default(DateTime))
        {
            Message_ID = message_ID;
            Sender_ID = sender_ID;
            Sender_Username = sender_Username;
            Receiver_ID = receiver_ID;
            Receiver_Username = receiver_Username;
            message = _message;
            Sent = sent;
            Received = received;
        }
    }
    public class Inbox
    {
        public int MessageCount = -1;
        public int UnreadMessageCount = -1;
        public Dictionary<int, Conversation> Conversations = new Dictionary<int, Conversation>();

        public Inbox(int messageCount, int unreadMessageCount, Dictionary<int, Conversation> conversations = null)
        {
            MessageCount = messageCount;
            UnreadMessageCount = unreadMessageCount;
            if (conversations != null)
            {
                Conversations = conversations;
            }
        }
    }
    public class Conversation
    {
        private Inbox Inbox;
        public int Owner_ID = -1;
        public string Username = "";
        public int MessageCount = 0;
        public int UnreadMessages = 0;
        public byte[] Avatar = null;
        public string MostRecentMessage = "";
        public bool Online = false;
        /// <summary>
        /// DO NOT ADD TO THIS DICTIONARY DIRECTLY, PLEASE USE THE "ADD" FUNCTION TO ADD RECORDS!
        /// </summary>
        public Dictionary<int, Message> Messages = new Dictionary<int, Message>();
        public Conversation(Inbox _inbox, int owner_ID, string username, int messageCount, int unreadMessages,string mostRecentMessage, bool online, byte[] avatar)
        {
            Inbox = _inbox;
            Owner_ID = owner_ID;
            Username = username;
            MessageCount = messageCount;
            UnreadMessages = unreadMessages;
            Avatar = avatar;
            MostRecentMessage = mostRecentMessage;
            Online = online;
        }
        public void Add(int message_ID, int sender_ID, string sender_Username, int receiver_ID, string receiver_Username, string Message, DateTime sent, DateTime received = default(DateTime))
        {
            if (!Messages.ContainsKey(message_ID))
            {
                Messages.Add(message_ID, new Message(message_ID, sender_ID, sender_Username, receiver_ID, receiver_Username, Message, sent, received));
            }
            else
            {
                Messages[message_ID].Sender_ID = sender_ID;
                Messages[message_ID].Sender_Username = sender_Username;
                Messages[message_ID].Receiver_ID = receiver_ID;
                Messages[message_ID].Receiver_Username = receiver_Username;
                Messages[message_ID].message = Message;
                Messages[message_ID].Sent = sent;
                Messages[message_ID].Received = received;
            }
            ++Inbox.MessageCount;
            if (received == default(DateTime))
            {
                ++UnreadMessages;
                ++Inbox.UnreadMessageCount;
            }
        }
    }
}
