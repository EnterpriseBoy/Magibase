using MagiApi.Entities;
using MagiApi.Models;
using Microsoft.EntityFrameworkCore;


namespace MagiApi.Context
{
    public class EventStaffContext : DbContext
    {
        public EventStaffContext(DbContextOptions<EventStaffContext> options): base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
