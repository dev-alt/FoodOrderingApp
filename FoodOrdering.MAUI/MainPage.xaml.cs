namespace FoodOrdering.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnViewMenuClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.MenuPage));
        }

        private async void OnViewOrdersClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Coming Soon", "Order history will be available in the next update!", "OK");
        }
    }
}