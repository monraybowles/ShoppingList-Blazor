
using Microsoft.EntityFrameworkCore;

namespace ClientShoppingList.Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }


        public DbSet<Products> Products{ get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
