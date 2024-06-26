using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sushi.Data.Models;
using System.Collections.Generic;

namespace Sushi.Data
{
    public class appDBContent : DbContext
    {

        public appDBContent(DbContextOptions<appDBContent> options) : base(options)
        {

        }
        public DbSet<Food> Food { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItems> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sushi;Username=postgres;Password=9105");
        }
    }
}
