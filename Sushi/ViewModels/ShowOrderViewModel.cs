using Sushi.Data.Models;
using System;
using System.Collections.Generic;

namespace Sushi.ViewModels
{
    public class ShowOrderViewModel
    {
        public string Name { get; set; }
        public string Adress {  get; set; }
        public string Email { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
