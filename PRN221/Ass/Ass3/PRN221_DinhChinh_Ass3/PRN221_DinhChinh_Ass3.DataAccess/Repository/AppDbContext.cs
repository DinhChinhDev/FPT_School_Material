using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PRN221_DinhChinh_Ass3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_DinhChinh_Ass3.DataAccess.Repository
{
    public class AppDbContext: DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Caterories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Ship> Ships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("Ass3"));
        }

    }
    


}
