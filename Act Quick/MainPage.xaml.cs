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
            string page = "";
            string nextPage = "FactListPage";
            if (sender is Button button)
            {
                page = button.Text;
            }
            if (page == "Emergencies List") nextPage = "ButtonListPage";

            // Navigate to the new page
            await Shell.Current.GoToAsync($"{nextPage}");
        }
    }
}