using Sushi.Data.Models;
using System;

namespace Sushi.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public uint Price { get; set; }
        public virtual Food Food { get; set; }
        public virtual Order Order { get; set; }
    }
}
