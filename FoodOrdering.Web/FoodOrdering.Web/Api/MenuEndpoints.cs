using FoodOrdering.Shared.Models;
using FoodOrdering.Web.Services;

namespace FoodOrdering.Web.Api
{
    public static class MenuEndpoints
    {
        public static RouteGroupBuilder MapMenuApi(this RouteGroupBuilder group)
        {
            group.MapGet("/menu", async (FoodOrderingService service) =>
                await service.GetMenuItemsAsync());

            group.MapGet("/menu/{id}", async (int id, FoodOrderingService service) =>
                await service.GetMenuItemAsync(id));

            group.MapPost("/menu", async (MenuItem item, FoodOrderingService service) =>
                await service.CreateMenuItemAsync(item));

            group.MapPut("/menu/{id}", async (int id, MenuItem item, FoodOrderingService service) =>
            {
                var updatedItem = await service.UpdateMenuItemAsync(id, item);
                return updatedItem != null ? Results.NoContent() : Results.NotFound();
            });

            return group;
        }
    }
}