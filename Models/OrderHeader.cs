﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace FastFood.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [ValidateNever]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public DateTime TimeOfPick {  get; set; }
        public DateTime DateOfPick { get; set; }
        public double SubTotal { get; set; }
        public double OrderTotal { get; set; }
        public string? CouponCode { get; set; }
        public double? CouponDis {  get; set; }

        public string? TransId { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }

        public string Name {  get; set; }
        public string Phone { get; set; }

    }
}
