using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.ViewModels
{
    [Keyless]
    public class OrderDetailsViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public  IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
