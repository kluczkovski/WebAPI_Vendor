using System;
using System.ComponentModel.DataAnnotations;

namespace DevEK.Api.ViewModels
{
    public class ProductDTO
    {
        public ProductDTO()
        {
        }

        [Key]
        public Guid Id { get; set; }

        public Guid VendorId { get; set; }

        [Required(ErrorMessage = "The field {0} must be informed")]
        [StringLength(100, ErrorMessage = "The field {0} must be between {1} and {2} caracters.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} must be informed")]
        [StringLength(300, ErrorMessage = "The field {0} must be between {1} and {2} caracters.", MinimumLength = 2)]
        public string Description { get; set; }


        public string ImageUpload { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "The field {0} must be informed")]
        public decimal Value { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool IsActive { get; set; }
    }
}
