using System.Collections.Generic;
using System.Drawing;

namespace AssetCache
{
    public class Item
    {
        public int ID;
        public string Name;
        public string Description;
        public float Rating;
        public float Price;
        public string Author;
        public List<Rating> Ratings = new List<Rating>();
        public List<Image> Images = new List<Image>();
        public Image Thumbnail;
        public Image Avatar;

        public Item()
        {

        }
        public Item(int id, string name, string author, string description, float rating, float price,  List<Rating> ratings = null, List<Image> images = null, Image thumbnail = null)
        {
            ID = id;
            Name = name;
            Description = description;
            Rating = rating;
            Price = price;
            Ratings = ratings;
            Images = images;
            Thumbnail = thumbnail;
            Author = author;
        }
    }
}