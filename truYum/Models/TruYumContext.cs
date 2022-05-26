using Microsoft.EntityFrameworkCore;

namespace truYum.Models
{
    public class TruYumContext : DbContext
    {
        public TruYumContext(DbContextOptions<TruYumContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Cart> Cart { get; set; }

   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Main Course",
                },
                new Category
                {
                    Id = 2,
                    Name = "Starters",
                },
                new Category
                {
                    Id = 3,
                    Name = "Snack",
                }
            );
        }
    }
}
