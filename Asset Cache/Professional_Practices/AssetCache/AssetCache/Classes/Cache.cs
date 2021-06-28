using System.Collections.Generic;
using System.Drawing;

namespace AssetCache
{
    public class Cache
    {
        public static Cache Instance;
        public Dictionary<int, Item> Assets = new Dictionary<int, Item>();
        public Cache()
        {
            Instance = this;
        }

        public Item Asset;
        public int pageCount = -1;
        public List<int> basketItemIDs = new List<int>();
    }
    public class Rating
    {
        public int rating;
        public string comment;
        public string username;
        public Image avatar; 
        public Rating(int Rating, string Comment, string username, Image avatar = null)
        {
            rating = Rating;
            comment = Comment;
            this.username = username;
            this.avatar = avatar;
        }
    }
}