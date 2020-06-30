using MagiApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagiApi.Context
{
    public class EventStaffContext : DbContext
    {
        public EventStaffContext(DbContextOptions<EventStaffContext> options): base(options){}

        public DbSet<Event> Events { get; set; }
    }
}
