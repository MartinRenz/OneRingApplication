using OneRingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace OneRingAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Anel> Aneis { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
    }
}
