using AssetCache.Classes;
using System.Drawing;

namespace AssetCache
{
    public class Account
    {
        public static Account instance;
        private string m_username;
        private string m_email;
        private string m_password;
        public Image avatar;
        public Inbox m_inbox;
        public bool isLoggedIn = false;

        public Account()
        {
            instance = this;
            m_username = "";
            m_email = "";
            m_password = "";
        }

        public void LogOut()
        {
            m_username = "";
            m_email = "";
            m_password = "";
        }

        public void Login(string username, string password)
        {
            m_username = username;
            m_password = password;
            isLoggedIn = true;
        }
        public void Register(string username, string password, string email)
        {
            m_username = username;
            m_password = password;
            m_email = email;
        }

        public string GetUsername()
        {
            return m_username;
        }
        public string GetPassword()
        {
            return m_password;
        }

        public string GetEmail()
        {
            return m_email;
        }
        public void SetEmail(string email)
        {
            m_email = email;
        }
    }

    public class AccountInfo
    {
        public string   userName = "";
        public int      accountID = -1;
        public string   email = "";
        public bool     loggedIn = false;
        public Image avatar = null;

        public AccountInfo(string UserName, int AccountID, string Email, bool LoggedIn, Image Avatar = null)
        {
            userName = UserName;
            accountID = AccountID;
            email = Email;
            loggedIn = LoggedIn;
            avatar = Avatar;
        }
    }
}