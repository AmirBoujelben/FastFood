using System.ComponentModel.DataAnnotations;

namespace FastFood.ViewModels
{
    public class CouponViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Type { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount must be a positive value")]
        public double Discount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Minimum amount must be a positive value")]
        public double MinimumAmount { get; set; }

        public IFormFile CouponPicture { get; set; } // For the uploaded file

        public bool IsActive { get; set; }
        public string CouponPictureBase64 { get; set; }
    }
}
