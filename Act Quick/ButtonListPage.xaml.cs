namespace Act_Quick;

[QueryProperty(nameof(Page), "page")]
public partial class ButtonListPage : ContentPage
{
    public string Page { get; set; } = "Emergencies List";
    public string[] ButtonNames { get; set; } = [];
    public ButtonListPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        SetupLayout(this.Page);
    }
    private void SetupLayout(string Page)
    {
        // Set title
        this.Title = Page;
        if (Page == "Emergencies List")
        {
            ButtonNames = EmergencyTips.GetEmergencies();
        }
        else if (Page == "Emergency Kit")
        {
            ButtonNames = EmergencyTips.GetEmergencyKitItems();
        }
        else
        {
            ButtonNames = EmergencyTips.GetFacts(Page);
        }
        OnPropertyChanged(nameof(ButtonNames));
    }
    private async void OnButtonClicked(object sender, EventArgs e)
    {
        // Get the text of the button
        string page = "";
        if (sender is Button button) page = button.Text;

        // Handle the button click event here
        var nextPage = EmergencyTips.GetPage(page);
        // Navigate to the new page
        await Navigation.PushAsync(nextPage);
    }
}