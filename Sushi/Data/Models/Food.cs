using System;

namespace Sushi.Data.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
        public bool ToViewHome { get; set; }
        public virtual Category Category { get; set; }

    }
}
