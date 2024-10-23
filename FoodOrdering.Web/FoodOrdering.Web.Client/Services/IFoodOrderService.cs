using FoodOrdering.Shared.Models;

namespace FoodOrdering.Web.Client.Services
{
    public interface IFoodOrderService
    {
        Task<List<MenuItem>> GetMenuItemsAsync();
        Task<MenuItem?> GetMenuItemAsync(int id);
        Task<MenuItem> CreateMenuItemAsync(MenuItem item);
        Task<bool> UpdateMenuItemAsync(int id, MenuItem item);
        Task<bool> DeleteMenuItemAsync(int id);
    }
}
