using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FoodOrdering.Web.Client.Services;
using System;
using System.Net.Http;

namespace FoodOrdering.Web.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // Register HttpClient
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            // Register the service
            builder.Services.AddScoped<IFoodOrderService, FoodOrderService>();

            await builder.Build().RunAsync();
        }
    }
}