using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price {  get; set; }
        public int CategoryId {  get; set; }
        public Category Category { get; set; }
        public int SubCategoryId {  get; set; }
        public SubCategory SubCategory { get; set; }

    }
}
