using Microsoft.EntityFrameworkCore;

namespace chefsndishes.Models
{
    public class ChefsDishesContext : DbContext
    {
        public ChefsDishesContext(DbContextOptions options) : base(options) { }

        public DbSet<Chef> Chef { get; set; }

        public DbSet<Dish> Dish { get; set; }
    }
}