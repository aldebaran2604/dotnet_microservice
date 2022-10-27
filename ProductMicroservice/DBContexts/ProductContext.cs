using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models;

namespace ProductMicroservice.DBContexts;

public class ProductContext : DbContext
{
    #region Properties

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    #endregion Properties

    #region Constructors

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {

    }

    #endregion

    #region Methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Electronics",
                Description = "Electronic Items",
            },
            new Category
            {
                Id = 2,
                Name = "Clothes",
                Description = "Dresses",
            },
            new Category
            {
                Id = 3,
                Name = "Grocery",
                Description = "Grocery Items",
            }
        );
    }

    #endregion
}
