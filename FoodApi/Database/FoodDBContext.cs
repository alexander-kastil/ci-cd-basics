using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodApi
{
    //To manage Migrations & create the DB go to console:
    //[dotnet restore]
    //dotnet ef migrations add MIGRATION-NAME
    //dotnet ef database update

    public class FoodDBContext : DbContext //Use DbContext if not using Identity
    {
        public FoodDBContext(DbContextOptions<FoodDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FoodItem> Food { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<FoodItem> list = new List<FoodItem>();
            list.Add(new FoodItem { ID = 1, Name = "Butter Chicken", Amount = 12, Code = "1200", Date = DateTime.Now });
            list.Add(new FoodItem { ID = 2, Name = "Blini with Salmon", Amount = 9, Code = "900", Date = DateTime.Now });
            list.Add(new FoodItem { ID = 3, Name = "Wurstknödel mit Sauerkraut", Amount = 8, Code = "1250",Date = DateTime.Now });
            modelBuilder.Entity<FoodItem>().HasData(list.ToArray());
        }
    }
}