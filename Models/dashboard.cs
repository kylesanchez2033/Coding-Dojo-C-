using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class dashboard
    {
        public User userLogged{get;set;}
        public List<Wedding> weddingList{get;set;}
        public Rsvp isRSVP{get;set;}
    }
}