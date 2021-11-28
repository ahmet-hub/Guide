using Contact.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Contact.Domain.Entities.Contact> Contacts { get; set; }
        public DbSet<Communication> Communications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}