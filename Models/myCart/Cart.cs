namespace API.Models.MyCart
{
    public class Cart
    {
        
        public int cartID {get; set;}
        public int invID {get; set;}
        public int empID {get; set;}
        public string invTitle { get; set; }
        public double price { get; set; }
        public string condition {get; set;}
        public string imgID {get; set;}
        public string ischeckedout {get; set;}

        public Cart()
        {
            
        }   
    }
}