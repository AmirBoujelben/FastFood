using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [MinLength(1)]
        public required int Count { get; set; }
    }
}
