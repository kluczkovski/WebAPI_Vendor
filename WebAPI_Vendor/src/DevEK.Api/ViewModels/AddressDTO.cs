using System;
using System.ComponentModel.DataAnnotations;

namespace DevEK.Api.ViewModels
{
    public class AddressDTO
    {
        [Key]
        public Guid Id { get; set; }

        public Guid VendorId { get; set; }

        [Required(ErrorMessage = "The field {0} must be informed")]
        [StringLength(100, ErrorMessage = "The field {0} must be between {1} and {2} caracters.", MinimumLength = 2)]
        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        [Required(ErrorMessage = "The field {0} must be informed")]
        [StringLength(8, ErrorMessage = "The field {0} must be between {2}.", MinimumLength = 8)]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "The field {0} must be informed")]
        [StringLength(100, ErrorMessage = "The field {0} must be between {1} and {2} caracters.", MinimumLength = 2)]
        public string Region { get; set; }

        [Required(ErrorMessage = "The field {0} must be informed")]
        [StringLength(50, ErrorMessage = "The field {0} must be between {1} and {2} caracters.", MinimumLength = 5)]
        public string City { get; set; }

        public string State { get; set; }
    }
}