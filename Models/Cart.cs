using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        [ValidateNever]
        public Item Item { get; set; }
        [ValidateNever]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public int Count { get; set; } = 1;
    }
}
