namespace Sushi.Data.Models
{
    public class ShopCartItems
    {
        public int Id { get; set; }
        public Food Food { get; set; }
        public int Price { get; set; }
        public string ShopCartTd { get; set; }
    }
}
