using FoodOrdering.MAUI.Pages;

namespace FoodOrdering.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        }
    }
}