using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Call IdentityDbContext onModelCreating method to insert IdentityTables
            base.OnModelCreating(modelBuilder);
        }
    }
}
