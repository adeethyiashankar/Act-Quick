namespace Act_Quick
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ChangePageCommand(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string? nextPage = button.Text switch
                {
                    "Emergencies List" => "ButtonListPage",
                    "Emergency Kit" => "FactListPage",
                    _ => null // Default for unsupported button text
                };

                // Check that nextPage is not null before navigating
                if (nextPage is not null)
                {
                    await Shell.Current.GoToAsync(nextPage);
                }
            }
        }
    }
}
