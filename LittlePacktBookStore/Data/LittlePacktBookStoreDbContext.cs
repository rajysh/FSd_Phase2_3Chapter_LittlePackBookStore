using LittlePacktBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LittlePacktBookStore.Data
{
    public class LittlePacktBookStoreDbContext: DbContext
    {
        public LittlePacktBookStoreDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Order> Orders { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LittlePackt;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    //base.OnConfiguring(optionsBuilder);
        //}
    }
}
