using System;

namespace FitnessClub.DAL.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime VisitTime { get; set; }
        public bool IsSingleVisit { get; set; } // True if it's a one-time visit, false if using membership
        public decimal? SingleVisitPrice { get; set; } // Price for single visit, null if using membership
        
        // Foreign keys
        public int ClientId { get; set; }
        public int ClubId { get; set; }
        public int? MembershipId { get; set; } // Null for single visits
        
        // Navigation properties
        public virtual Client Client { get; set; }
        public virtual Club Club { get; set; }
        public virtual Membership Membership { get; set; }
    }
} 