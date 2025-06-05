using FitnessClub.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.DAL
{
    public class FitnessClubContext : DbContext
    {
        public FitnessClubContext(DbContextOptions<FitnessClubContext> options)
            : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Schedules)
                .WithOne(s => s.Club)
                .HasForeignKey(s => s.ClubId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Club>()
                .HasMany(c => c.Memberships)
                .WithOne(m => m.Club)
                .HasForeignKey(m => m.ClubId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Club>()
                .HasMany(c => c.Visits)
                .WithOne(v => v.Club)
                .HasForeignKey(v => v.ClubId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Memberships)
                .WithOne(m => m.Client)
                .HasForeignKey(m => m.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Visits)
                .WithOne(v => v.Client)
                .HasForeignKey(v => v.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Reservations)
                .WithOne(r => r.Client)
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Membership>()
                .HasMany(m => m.Visits)
                .WithOne(v => v.Membership)
                .HasForeignKey(v => v.MembershipId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.Reservations)
                .WithOne(r => r.Schedule)
                .HasForeignKey(r => r.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure required fields
            modelBuilder.Entity<Club>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.LastName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .IsRequired();

            modelBuilder.Entity<Membership>()
                .Property(m => m.Type)
                .IsRequired();

            modelBuilder.Entity<Schedule>()
                .Property(s => s.ActivityName)
                .IsRequired();
        }
    }
} 