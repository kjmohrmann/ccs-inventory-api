using System;

namespace API.Models
{
    public class Item
    {
        public int invID { get; set; }
        public string invTitle { get; set; }
        public double price { get; set; }
        public string condition {get; set;}
        public string imgID {get; set;}
        public string ischeckedout {get; set;}

        public Item()
        {

        }

    }
}