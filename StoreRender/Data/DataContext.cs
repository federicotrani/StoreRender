using Microsoft.EntityFrameworkCore;
using StoreRender.Data.Entities;

namespace StoreRender.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
    }
}
