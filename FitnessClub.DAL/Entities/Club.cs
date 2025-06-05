using System.Collections.Generic;

namespace FitnessClub.DAL.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        
        // Navigation properties
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        
        public Club()
        {
            Schedules = new HashSet<Schedule>();
            Memberships = new HashSet<Membership>();
            Visits = new HashSet<Visit>();
        }
    }
} 