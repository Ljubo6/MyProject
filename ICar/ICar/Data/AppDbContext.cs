using ICar.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data
{
    public class AppDbContext : DbContext
    {
        //private readonly DbContextOptions<AppDbContext> options;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //this.options = options;
        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
