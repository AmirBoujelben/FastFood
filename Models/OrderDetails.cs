﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }
        public int ItemId { get; set; }
        [ValidateNever]
        public Item Item { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
