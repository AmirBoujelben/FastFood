using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public required string Title {  get; set; }
        public int CategoryId {  get; set; }
        public Category Category { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
