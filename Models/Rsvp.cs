using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Rsvp
    {
        [Key]
        public int RsvpId{set; get;}
        public int UserId{get; set;}
        public int WeddingId{get; set;}

        public User Guest{get; set; }
        public Wedding Wedding{get; set; }
    }
}