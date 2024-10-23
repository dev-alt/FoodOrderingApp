using FoodOrdering.Shared.Models;
using FoodOrdering.Web.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Web.Services
{
    public class FoodOrderingService(ApplicationDbContext context)
    {
        public async Task<List<MenuItem>> GetMenuItemsAsync()
        {
            return await context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem?> GetMenuItemAsync(int id)
        {
            return await context.MenuItems.FindAsync(id);
        }

        public async Task<MenuItem> CreateMenuItemAsync(MenuItem item)
        {
            context.MenuItems.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<MenuItem?> UpdateMenuItemAsync(int id, MenuItem item)
        {
            var existingItem = await context.MenuItems.FindAsync(id);
            if (existingItem == null)
            {
                return null;
            }

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.Price = item.Price;
            existingItem.Category = item.Category;
            existingItem.IsAvailable = item.IsAvailable;

            await context.SaveChangesAsync();
            return existingItem;
        }
    }
}