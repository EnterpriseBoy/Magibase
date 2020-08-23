using MagiApi.Entities;
using MagiApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagiApi.Context
{
    public class EventStaffContext : IdentityDbContext
    {
        public EventStaffContext(DbContextOptions<EventStaffContext> options): base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
