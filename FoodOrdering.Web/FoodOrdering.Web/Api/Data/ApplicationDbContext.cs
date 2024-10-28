using FoodOrdering.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Web.Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<FoodMenuItem> MenuItems => Set<FoodMenuItem>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure FoodMenuItem
            modelBuilder.Entity<FoodMenuItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Category).IsRequired();
            });

            // Configure Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CustomerPhone).HasMaxLength(20);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");

                entity.HasMany(e => e.Items)
                    .WithOne(e => e.Order)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Notes).IsRequired();

                entity.HasOne(e => e.MenuItem)
                    .WithMany()
                    .HasForeignKey(e => e.MenuItemId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}