using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Newsletter { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Dob { get; set; }
        public string Handler { get; set; }
        [Display(Name = "Gender")]
        public string Sex { get; set; }
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Country Code")]
        public int CountryCode { get; set; }

        //FK MembershipType
        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}