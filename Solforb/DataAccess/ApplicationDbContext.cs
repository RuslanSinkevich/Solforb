using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solforb.Models;

namespace Solforb.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Order>? Order { get; set; }
        public DbSet<OrderItem>? OrderItem { get; set; }
        public DbSet<Provider>? Provider { get; set; }

    }
}
