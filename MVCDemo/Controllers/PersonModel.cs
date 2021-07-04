using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Controllers
{
    public class PersonModel
    {
        [Required(ErrorMessage = "First name must be specified")]
        [RegularExpression(@"^[a-zA-Z0-9]{2,255}",
            ErrorMessage = "First name should contain only letters and numbers.\n" +
            "Minimum length is 2, maximum is 255.\n")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name must be specified")]
        [RegularExpression(@"^[a-zA-Z0-9]{2,255}",
            ErrorMessage = "Last name should contain only letters and numbers.\n" +
            "Minimum length is 2, maximum is 255.\n")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Partner Number must be specified")]
        [RegularExpression(@"^[0-9]{10}",
            ErrorMessage = "Partner number must be 10 digit number\n")]
        public long PartnerNumber { get; set; }
        [RegularExpression(@"^[0-9]{11}",
            ErrorMessage = "CroatianPIN must be 11 digit number\n")]
        public long CroatianPIN { get; set; }
        [Required(ErrorMessage = "Partner Type Id must be specified")]
        public PartnerType PartnerTypeId { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        [Required(ErrorMessage = "User must be specified")]
        public string CreateByUser { get; set; }
        [Required(ErrorMessage = "Is foreign must be specified")]
        public bool IsForeign { get; set; }
        [Required(ErrorMessage = "Unique External Code must be specified")]
        [RegularExpression(@"^[a-zA-Z0-9]{10,20}",
            ErrorMessage = "External code should contain only letters and numbers.\n" +
            "Minimum length is 10, maximum is 20.\n")]
        public string ExternalCode { get; set; }
        [Required(ErrorMessage = "Person gender must be specified")]
        public char PersonGender { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        public string getFullName() { return FirstName + " " + LastName; }
    }

    public enum Gender
    {
        M,
        F,
        N
    }

    public enum PartnerType
    {
        Personal = 1,
        Legal,
    }
}