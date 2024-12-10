using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double Discount { get; set; }
        public double MinimumAmount { get; set; }
        public byte[] CouponPicture { get; set; }
        public bool IsActive { get; set; }
    }

}
