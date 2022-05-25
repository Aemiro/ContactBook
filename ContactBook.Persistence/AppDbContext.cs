using ContactBook.Domain.Contacts;
using ContactBook.Domain.Groups;
using ContactBook.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Persistence
{
    public class AppDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "contact_book";
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Group> groups { get; set; }
        public DbSet<Contact> contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactEntityTypeConfiguration());

        }
    }
}
