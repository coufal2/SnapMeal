using Microsoft.EntityFrameworkCore;
using SnapMeal.API.Models;

namespace SnapMeal.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
