using FoodOrdering.MAUI.Pages;
using FoodOrdering.MAUI.Services;
using Microsoft.Extensions.Logging;

namespace FoodOrdering.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            // Register services
            builder.Services.AddSingleton<IApiService, ApiService>();


            builder.Services.AddTransient<MainPage>();

            // Register pages (add these as you create them)
            builder.Services.AddTransient<MenuPage>();
            //builder.Services.AddTransient<CartPage>();
            //builder.Services.AddTransient<OrdersPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
