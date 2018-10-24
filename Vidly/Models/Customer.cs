using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "First name cannot be longer than 255 characters.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Newsletter { get; set; }
        [Display(Name = "Date of Birth")]
        [MinAgeToSubscribe]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Dob { get; set; }
        [Display(Name = "Username")]
        [StringLength(25, ErrorMessage = "Username cannot be longer than 25 characters.")]
        public string Handler { get; set; }
        [Display(Name = "Gender")]
        public string Sex { get; set; }
        [Display(Name = "Phone Number")]
        public int? PhoneNumber { get; set; }
        [Display(Name = "Country Code")]
        [RegularExpression("^\\+\\d+", ErrorMessage = "Country code must have the following format +X")]
        public string CountryCode { get; set; }
        [Display(Name = "Postal Code")]
        [RegularExpression("\\d{4}-\\d{3}", ErrorMessage = "Country code must have the following format XXXX-XXX")]
        public string PostalCode { get; set; }
        [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters.")]
        public string Address { get; set; }


        //FK MembershipType
        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        //TODO: UserID must be unique 1 user 1 customer
        //FK User
        [ForeignKey("ApplicationUser"), Required]
        [Index("IX_UserId", IsUnique = true)]
        [Display(Name = "User")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}