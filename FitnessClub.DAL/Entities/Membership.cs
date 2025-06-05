using System;
using System.Collections.Generic;

namespace FitnessClub.DAL.Entities
{
    public class Membership
    {
        public int Id { get; set; }
        public string Type { get; set; } // Regular, Network (for all clubs)
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        // Foreign keys
        public int ClientId { get; set; }
        public int? ClubId { get; set; } // Null for network memberships
        
        // Navigation properties
        public virtual Client Client { get; set; }
        public virtual Club Club { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        
        public Membership()
        {
            Visits = new HashSet<Visit>();
        }
    }
} 