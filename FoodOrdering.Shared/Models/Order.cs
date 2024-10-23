using FoodOrdering.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Shared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = [];
        public decimal TotalAmount { get; set; }
    }

}
