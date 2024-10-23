using FoodOrdering.Shared.Enums;
using FoodOrdering.Shared.Models;

namespace FoodOrdering.Web.Services
{
    public interface IFoodOrderingService
    {
        Task<List<MenuItem>> GetMenuItemsAsync();
        Task<MenuItem?> GetMenuItemAsync(int id);
        Task<MenuItem?> CreateMenuItemAsync(MenuItem item);
        Task<bool> UpdateMenuItemAsync(int id, MenuItem item);
        Task<bool> DeleteMenuItemAsync(int id);
        Task<List<Order>> GetOrdersAsync();
        Task<Order?> GetOrderAsync(int id);
        Task<bool> UpdateOrderStatusAsync(int id, OrderStatus newStatus);
    }

}
