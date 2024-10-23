using FoodOrdering.Shared.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Web.Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    }
}
