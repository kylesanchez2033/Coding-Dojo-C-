using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        public int WeddingId{get;set;}
        public int Userid{get;set;}//Foreign Key
        public User Creator{get;set;}//Navigation Property
        [Required]
        [Display(Name="Wedder One")]
        [MinLength(2, ErrorMessage = "Wedder One must be at least 2 characters!")]
        public string WedderOne {get;set;}
        [Required]
        [Display(Name="Wedder Two")]
        [MinLength(2, ErrorMessage = "Wedder Two must be at least 2 characters!")]
        public string WedderTwo {get;set;}
        [FutureDate]
        [Required(ErrorMessage = "Wedding Date must be in the future!")]
        [Display(Name="Wedder Date")]
        [DataType(DataType.Date)]

        public DateTime WeddingDate {get;set;}
        public string WeddingAddress{get;set;}

        public List<Rsvp> CreatedRsvp{get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;
    }
}