using System;

namespace FitnessClub.DAL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public bool IsConfirmed { get; set; }
        
        // Foreign keys
        public int ClientId { get; set; }
        public int ScheduleId { get; set; }
        
        // Navigation properties
        public virtual Client Client { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
} 