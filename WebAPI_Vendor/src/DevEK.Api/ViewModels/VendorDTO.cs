using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevEK.Api.ViewModels
{
    public class VendorDTO
    {
        public VendorDTO()
        {
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="The field {0} must have informed.")]
        [StringLength(100, ErrorMessage = "The field {0} shoud be between {1} and {2} caracters.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} must have informed.")]
        [StringLength(14, ErrorMessage = "The field {0} shoud be between {1} and {2} caracters.", MinimumLength = 11)]
        public string IdentifiyDocument { get; set; }

        public int TypeOfVendor { get; set; }

        public AddressDTO Address { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
