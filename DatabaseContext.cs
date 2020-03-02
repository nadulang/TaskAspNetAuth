using Microsoft.EntityFrameworkCore;
using TaskAuth.Models;

namespace TaskAuth.Models
{
    public class TheCustomerContext : DbContext
    {
        public TheCustomerContext(DbContextOptions<TheCustomerContext> options): base(options){ }
        public DbSet<CustomersData> CustomersDatas { get; set; }
        public DbSet<Products> ProductsData { get; set; }
    }
    
}