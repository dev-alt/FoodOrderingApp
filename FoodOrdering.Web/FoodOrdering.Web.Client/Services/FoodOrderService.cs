using FoodOrdering.Shared.Models;
using System.Net.Http.Json;

namespace FoodOrdering.Web.Client.Services
{
    public class FoodOrderService : IFoodOrderService
    {
        private readonly HttpClient _httpClient;

        public FoodOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MenuItem>> GetMenuItemsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<MenuItem>>("api/menu")
                       ?? new List<MenuItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching menu items: {ex.Message}");
                return new List<MenuItem>();
            }
        }

        public async Task<MenuItem?> GetMenuItemAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MenuItem>($"api/menu/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<MenuItem> CreateMenuItemAsync(MenuItem item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/menu", item);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MenuItem>() ?? item;
        }

        public async Task<bool> UpdateMenuItemAsync(int id, MenuItem item)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/menu/{id}", item);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/menu/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}