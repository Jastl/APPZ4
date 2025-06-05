using System;
using System.Collections.Generic;

namespace FitnessClub.DAL.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxParticipants { get; set; }
        
        // Foreign keys
        public int ClubId { get; set; }
        
        // Navigation properties
        public virtual Club Club { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        
        public Schedule()
        {
            Reservations = new HashSet<Reservation>();
        }
    }
} 