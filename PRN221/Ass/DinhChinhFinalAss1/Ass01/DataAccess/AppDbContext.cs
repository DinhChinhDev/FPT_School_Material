using BusinessObject;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBContext"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" },
                new Category { CategoryId = 4, CategoryName = "Beverages" },
                new Category { CategoryId = 5, CategoryName = "Condiments" },
                new Category { CategoryId = 6, CategoryName = "Confections" },
                new Category { CategoryId = 7, CategoryName = "Beverages" },
                new Category { CategoryId = 8, CategoryName = "Condiments" },
                new Category { CategoryId = 9, CategoryName = "Confections" },
                new Category { CategoryId = 10, CategoryName = "Beverages" },
                new Category { CategoryId = 11, CategoryName = "Condiments" },
                new Category { CategoryId = 12, CategoryName = "Confections" }
                );

            modelBuilder.Entity<Member>().HasData(
                new Member { MemberId = 1, Email = "admin@gmail.com", Password = "123", City = "Da Nang", CompanyName = "FPT Software", Country = "Viet Nam" },
                new Member { MemberId = 2, Email = "customer@gmail.com", Password = "123", City = "Da Nang", CompanyName = "FPT Software", Country = "Viet Nam" }
                );

            modelBuilder.Entity<Product>(options =>
            {
                options.HasData(
                    new Product
                    {
                        ProductId = 1,
                        CategoryId = 1,
                        ProductName = "Chocopie",
                        Weight = "1.5 kg",
                        UnitPrice = 10,
                        UnitsInStock = 103
                    },
                    new Product
                    {
                        ProductId = 2,
                        CategoryId = 1,
                        ProductName = "Vanilla Dream Cake",
                        Weight = "2 kg",
                        UnitPrice = 25,
                        UnitsInStock = 50
                    },
                    new Product
                    {
                        ProductId = 3,
                        CategoryId = 2,
                        ProductName = "Green Tea",
                        Weight = "250 g",
                        UnitPrice = 8,
                        UnitsInStock = 75
                    },
                    new Product
                    {
                        ProductId = 4,
                        CategoryId = 2,
                        ProductName = "Espresso Beans",
                        Weight = "500 g",
                        UnitPrice = 15,
                        UnitsInStock = 40
                    },
                    new Product
                    {
                        ProductId = 5,
                        CategoryId = 3,
                        ProductName = "Organic Avocado",
                        Weight = "0.5 kg",
                        UnitPrice = 5,
                        UnitsInStock = 90
                    },
                    new Product
                    {
                        ProductId = 6,
                        CategoryId = 3,
                        ProductName = "Mango Delight",
                        Weight = "1 kg",
                        UnitPrice = 12,
                        UnitsInStock = 60
                    },
                    new Product
                    {
                        ProductId = 7,
                        CategoryId = 4,
                        ProductName = "Lemon Zest Cookies",
                        Weight = "300 g",
                        UnitPrice = 7,
                        UnitsInStock = 80
                    },
                    new Product
                    {
                        ProductId = 8,
                        CategoryId = 4,
                        ProductName = "Caramel Crunch Popcorn",
                        Weight = "200 g",
                        UnitPrice = 6,
                        UnitsInStock = 120
                    },
                    new Product
                    {
                        ProductId = 9,
                        CategoryId = 5,
                        ProductName = "Strawberry Yogurt",
                        Weight = "1.2 kg",
                        UnitPrice = 18,
                        UnitsInStock = 55
                    },
                    new Product
                    {
                        ProductId = 10,
                        CategoryId = 5,
                        ProductName = "Blueberry Muffins",
                        Weight = "400 g",
                        UnitPrice = 9,
                        UnitsInStock = 70
                    },
                    new Product
                    {
                        ProductId = 11,
                        CategoryId = 6,
                        ProductName = "Spicy Salsa",
                        Weight = "250 ml",
                        UnitPrice = 4,
                        UnitsInStock = 100
                    },
                    new Product
                    {
                        ProductId = 12,
                        CategoryId = 6,
                        ProductName = "Garlic Hummus",
                        Weight = "350 g",
                        UnitPrice = 6,
                        UnitsInStock = 85
                    },
                    new Product
                    {
                        ProductId = 13,
                        CategoryId = 7,
                        ProductName = "Classic Barbecue Sauce",
                        Weight = "500 ml",
                        UnitPrice = 8,
                        UnitsInStock = 65
                    },
                    new Product
                    {
                        ProductId = 14,
                        CategoryId = 7,
                        ProductName = "Honey Mustard Dressing",
                        Weight = "300 ml",
                        UnitPrice = 5,
                        UnitsInStock = 110
                    },
                    new Product
                    {
                        ProductId = 15,
                        CategoryId = 8,
                        ProductName = "Whole Wheat Pasta",
                        Weight = "1 kg",
                        UnitPrice = 7,
                        UnitsInStock = 75
                    },
                    new Product
                    {
                        ProductId = 16,
                        CategoryId = 8,
                        ProductName = "Quinoa Rice Blend",
                        Weight = "750 g",
                        UnitPrice = 10,
                        UnitsInStock = 50
                    }, new Product
                    {
                        ProductId = 17,
                        CategoryId = 9,
                        ProductName = "Assorted Nuts Mix",
                        Weight = "400 g",
                        UnitPrice = 12,
                        UnitsInStock = 40
                    }, new Product
                    {
                        ProductId = 18,
                        CategoryId = 9,
                        ProductName = "Dried Cranberries",
                        Weight = "250 g",
                        UnitPrice = 6,
                        UnitsInStock = 85
                    },
                    new Product
                    {
                        ProductId = 19,
                        CategoryId = 10,
                        ProductName = "Herbal Chamomile Tea",
                        Weight = "100 g",
                        UnitPrice = 5,
                        UnitsInStock = 120
                    },
                    new Product
                    {
                        ProductId = 20,
                        CategoryId = 10,
                        ProductName = "Peppermint Infusion",
                        Weight = "150 g",
                        UnitPrice = 8,
                        UnitsInStock = 60
                    },
                    new Product
                    {
                        ProductId = 21,
                        CategoryId = 11,
                        ProductName = "Organic Tomato Soup",
                        Weight = "750 ml",
                        UnitPrice = 4,
                        UnitsInStock = 95
                    }
                );
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
