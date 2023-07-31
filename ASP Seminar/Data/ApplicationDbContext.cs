using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ASP_Seminar.Models;

namespace ASP_Seminar.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product>? Product { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<ProductCategory>? ProductCategory { get; set; }
        public DbSet<Order>? Order { get; set; }
        public DbSet<OrderItem>? OrderItem { get; set; }
        //public DbSet<CartItem>? ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole() { Name = "User", NormalizedName = "USER" });

            SeedCategories(builder);
            SeedProducts(builder);
            SeedProductCategories(builder);
        }

        internal void SeedCategories(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(   new Category() { Id = 1, Title = "LRF" },
                            new Category() { Id = 2, Title = "HRF" },
                            new Category() { Id = 3, Title = "Udica" },
                            new Category() { Id = 4, Title = "Stap" },
                            new Category() { Id = 5, Title = "Jig" },
                            new Category() { Id = 6, Title = "Najlon" },
                            new Category() { Id = 7, Title = "Upredenica" },
                            new Category() { Id = 8, Title = "Olovo" }
                );
        }

        internal void SeedProducts(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasData(   new Product() { Id = 1, Title = "Udica 1/0", Description = "Sharpest hook in the shed.", Price = 3.90m, Quantity = 15, HasImage = true },
                            new Product() { Id = 2, Title = "Udica 2/0", Description = "Sharpest hook in the shed.", Price = 3.90m, Quantity = 25, HasImage = true },
                            new Product() { Id = 3, Title = "Udica 4/0", Description = "Sharpest hook in the shed.", Price = 3.90m, Quantity = 17, HasImage = true },
                            new Product() { Id = 4, Title = "Udica 2", Description = "Sharpest hook in the shed.", Price = 3.90m, Quantity = 23, HasImage = true },
                            new Product() { Id = 5, Title = "Udica 4", Description = "Sharpest hook in the shed.", Price = 3.90m, Quantity = 12, HasImage = true },
                            new Product() { Id = 6, Title = "Jigmaher 5000", Description = "Mostly for jigging, action 25-50g", Price = 79.9m, Quantity = 7, HasImage = true },
                            new Product() { Id = 7, Title = "Jigmaher 3000", Description = "Mostly for jigging, action 15-25g", Price = 69.9m, Quantity = 2, HasImage = true },
                            new Product() { Id = 8, Title = "Jigmaher 2000", Description = "Mostly for jigging, action 5-15g", Price = 59.9m, Quantity = 0, HasImage = true },
                            new Product() { Id = 9, Title = "Fermaher 50", Description = "Grounded design! Action 20-50g", Price = 65m, Quantity = 5, HasImage = true },
                            new Product() { Id = 10, Title = "Fermaher 60", Description = "Grounded design! Action 40-70g", Price = 75m, Quantity = 3, HasImage = true },
                            new Product() { Id = 11, Title = "Fermaher 70", Description = "Grounded design! Action 60-120g", Price = 95m, Quantity = 3, HasImage = true },
                            new Product() { Id = 12, Title = "Plovakher 10", Description = "Float like a butterfly, fish in the sea. 3.0m", Price = 52m, Quantity = 4, HasImage = true },
                            new Product() { Id = 13, Title = "Plovakher 11", Description = "Float like a butterfly, fish in the sea. 3.7m", Price = 59m, Quantity = 2, HasImage = true },
                            new Product() { Id = 14, Title = "Plovakher 12", Description = "Float like a butterfly, fish in the sea. 4.0m", Price = 69m, Quantity = 1, HasImage = true },
                            new Product() { Id = 15, Title = "Plovakher 13", Description = "Float like a butterfly, fish in the sea. 4.2m", Price = 85m, Quantity = 1, HasImage = true },
                            new Product() { Id = 16, Title = "Monolayn .17 Ultra", Description = "Durable, better than the rest!", Price = 8.9m, Quantity = 12, HasImage = true },
                            new Product() { Id = 17, Title = "Monolayn .22 Ultra", Description = "Durable, better than the rest!", Price = 8.9m, Quantity = 15, HasImage = true },
                            new Product() { Id = 18, Title = "Monolayn .25 Ultra", Description = "Durable, better than the rest!", Price = 8.9m, Quantity = 9, HasImage = true },
                            new Product() { Id = 19, Title = "Monolayn .28 Ultra", Description = "Durable, better than the rest!", Price = 9.9m, Quantity = 8, HasImage = true },
                            new Product() { Id = 20, Title = "Monolayn .35 Ultra", Description = "Durable, better than the rest!", Price = 9.9m, Quantity = 10, HasImage = true },
                            new Product() { Id = 21, Title = "Monolayn .40 Ultra", Description = "Durable, better than the rest!", Price = 12.9m, Quantity = 5, HasImage = true },
                            new Product() { Id = 22, Title = "Monolayn .16 Mid", Description = "Durable!", Price = 6.9m, Quantity = 13, HasImage = true },
                            new Product() { Id = 23, Title = "Monolayn .235 Mid", Description = "Durable!", Price = 7.9m, Quantity = 12, HasImage = true },
                            new Product() { Id = 24, Title = "Shpagodenica #.4 Pro X8", Description = "For tournaments and recreational use.", Price = 18.25m, Quantity = 7, HasImage = true },
                            new Product() { Id = 25, Title = "Shpagodenica #.6 Pro X8", Description = "For tournaments and recreational use.", Price = 18.25m, Quantity = 6, HasImage = true },
                            new Product() { Id = 26, Title = "Shpagodenica #.8 Pro X8", Description = "For tournaments and recreational use.", Price = 22.25m, Quantity = 7, HasImage = true },
                            new Product() { Id = 27, Title = "Shpagodenica #1 Pro X8", Description = "For tournaments and recreational use.", Price = 24.25m, Quantity = 4, HasImage = true },
                            new Product() { Id = 28, Title = "Shpagodenica #.6 X4", Description = "For recreational use.", Price = 14.25m, Quantity = 9, HasImage = true },
                            new Product() { Id = 29, Title = "Shpagodenica #.8 X4", Description = "For recreational use.", Price = 15.25m, Quantity = 4, HasImage = true },
                            new Product() { Id = 30, Title = "Shpagodenica #1 X4", Description = "For recreational use.", Price = 16.25m, Quantity = 5, HasImage = true },
                            new Product() { Id = 31, Title = "Olovnica Teary 5g", Description = "Floats to the bottom.", Price = 0.5m, Quantity = 15, HasImage = true },
                            new Product() { Id = 32, Title = "Olovnica Teary 10g", Description = "Floats to the bottom.", Price = 0.5m, Quantity = 12, HasImage = true },
                            new Product() { Id = 33, Title = "Olovnica Teary 15g", Description = "Floats to the bottom.", Price = 0.5m, Quantity = 14, HasImage = true },
                            new Product() { Id = 34, Title = "Olovnica Diamonde 25g", Description = "Sinks like a small rock.", Price = 1m, Quantity = 11, HasImage = true },
                            new Product() { Id = 35, Title = "Olovnica Diamonde 30g", Description = "Sinks like a small rock.", Price = 1m, Quantity = 7, HasImage = true }
                );
        }

        internal void SeedProductCategories(ModelBuilder builder)
        {
            builder.Entity<ProductCategory>()
                .HasData(   new ProductCategory() { Id = 1, CategoryId = 3, ProductId = 1 },
                            new ProductCategory() { Id = 2, CategoryId = 3, ProductId = 2 },
                            new ProductCategory() { Id = 3, CategoryId = 3, ProductId = 3 },
                            new ProductCategory() { Id = 4, CategoryId = 3, ProductId = 4 },
                            new ProductCategory() { Id = 5, CategoryId = 3, ProductId = 5 },
                            new ProductCategory() { Id = 6, CategoryId = 4, ProductId = 6 },
                            new ProductCategory() { Id = 7, CategoryId = 4, ProductId = 7 },
                            new ProductCategory() { Id = 8, CategoryId = 4, ProductId = 8 },
                            new ProductCategory() { Id = 9, CategoryId = 4, ProductId = 9 },
                            new ProductCategory() { Id = 10, CategoryId = 4, ProductId = 10 },
                            new ProductCategory() { Id = 11, CategoryId = 4, ProductId = 11 },
                            new ProductCategory() { Id = 12, CategoryId = 4, ProductId = 12 },
                            new ProductCategory() { Id = 13, CategoryId = 4, ProductId = 13 },
                            new ProductCategory() { Id = 14, CategoryId = 4, ProductId = 14 },
                            new ProductCategory() { Id = 15, CategoryId = 4, ProductId = 15 },
                            new ProductCategory() { Id = 16, CategoryId = 6, ProductId = 16 },
                            new ProductCategory() { Id = 17, CategoryId = 6, ProductId = 17 },
                            new ProductCategory() { Id = 18, CategoryId = 6, ProductId = 18 },
                            new ProductCategory() { Id = 19, CategoryId = 6, ProductId = 19 },
                            new ProductCategory() { Id = 20, CategoryId = 6, ProductId = 20 },
                            new ProductCategory() { Id = 21, CategoryId = 6, ProductId = 21 },
                            new ProductCategory() { Id = 22, CategoryId = 6, ProductId = 22 },
                            new ProductCategory() { Id = 23, CategoryId = 6, ProductId = 23 },
                            new ProductCategory() { Id = 24, CategoryId = 7, ProductId = 24 },
                            new ProductCategory() { Id = 25, CategoryId = 7, ProductId = 25 },
                            new ProductCategory() { Id = 26, CategoryId = 7, ProductId = 26 },
                            new ProductCategory() { Id = 27, CategoryId = 7, ProductId = 27 },
                            new ProductCategory() { Id = 28, CategoryId = 7, ProductId = 28 },
                            new ProductCategory() { Id = 29, CategoryId = 7, ProductId = 29 },
                            new ProductCategory() { Id = 30, CategoryId = 7, ProductId = 30 },
                            new ProductCategory() { Id = 31, CategoryId = 8, ProductId = 31 },
                            new ProductCategory() { Id = 32, CategoryId = 8, ProductId = 32 },
                            new ProductCategory() { Id = 33, CategoryId = 8, ProductId = 33 },
                            new ProductCategory() { Id = 34, CategoryId = 8, ProductId = 34 },
                            new ProductCategory() { Id = 35, CategoryId = 8, ProductId = 35 },
                            new ProductCategory() { Id = 36, CategoryId = 5, ProductId = 6 },
                            new ProductCategory() { Id = 37, CategoryId = 5, ProductId = 7 },
                            new ProductCategory() { Id = 38, CategoryId = 5, ProductId = 8 },
                            new ProductCategory() { Id = 39, CategoryId = 1, ProductId = 8 }
                );
        }
    }
    public class AppUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(150)]
        public string? Address { get; set; }

        [ForeignKey("UserId")]
        public List<Order>? Orders { get; set; }
    }
}
