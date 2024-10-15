using ManageTickets.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManageTickets.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Status)
                .HasConversion<string>(); 
        }
    }
}
