using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ConsoleApp1
{
    public class AppDbContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Event Config (Fluent API)
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(e => e.Organizer)
                    .WithMany(o => o.Events)
                    .HasForeignKey(e => e.OrganizerId);

                // Self Relation
                entity.HasOne(e => e.ParentEvent)
                    .WithMany(e => e.Sessions)
                    .HasForeignKey(e => e.ParentEventId);

                // Shadow Properties
                entity.Property<DateTime>("CreatedAt");
                entity.Property<DateTime>("UpdatedAt");
            });

            // Registration Config
            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(r => new { r.AttendeeId, r.EventId });

                entity.HasOne(r => r.Attendee)
                    .WithMany(a => a.Registrations)
                    .HasForeignKey(r => r.AttendeeId);

                entity.HasOne(r => r.Event)
                    .WithMany(e => e.Registrations)
                    .HasForeignKey(r => r.EventId);
            });

            // Apply Config Class
            modelBuilder.ApplyConfiguration(new AttendeeConfig());
        }
    }
}
