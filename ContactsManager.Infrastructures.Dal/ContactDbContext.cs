using ContactsManager.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Infrastructures.Dal
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
            
        }


        public DbSet<Contact> contacts { get; set; }
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
