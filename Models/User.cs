using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models{
    public class User{
        [Key]
        public int UserId{get;set;}
        [Required]
        [Display(Name="First Name")]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters!")]
        public string firstname{get;set;}
        [Required]
        [Display(Name="Last Name")]
        [MinLength(2, ErrorMessage="Last Name must be at least 2 characters!")]
        public string lastname{get;set;}
        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        [MinLength(2, ErrorMessage="Email must be at least characters!")]
        public string email{get;set;}
        [Display(Name="Password")]
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password{get;set;}
        [Display(Name="Confirm Password")]
        [NotMapped]
        [Compare("password", ErrorMessage="Passwords must match!")]
        [DataType(DataType.Password)]
        public string cpassword{get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;
        public List<Wedding> CreatedWeddings {get;set;} // List of weddings the user Created
        public List<Rsvp> CreatedRsvp{get;set;}//List of Rsvp to the weddings the user can attend
        
    }
    [NotMapped]
    public class Login
    {
        [Required]
        [EmailAddress]
        public string LoginEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}