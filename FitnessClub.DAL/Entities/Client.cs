using System.Collections.Generic;

namespace FitnessClub.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        // Navigation properties
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        
        public Client()
        {
            Memberships = new HashSet<Membership>();
            Visits = new HashSet<Visit>();
            Reservations = new HashSet<Reservation>();
        }
    }
} 