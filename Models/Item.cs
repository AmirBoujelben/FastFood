using FastFood.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SubCategoryId { get; set; }
        [ValidateNever]
        public SubCategory SubCategory { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
