namespace Act_Quick;

public partial class FactListPage : ContentPage
{
    public string Page { get; set; } = "Emergency Kit";
    public FactItem[] FactItems { get; set; } = [];
	public FactListPage()
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
        if (Page == "null") Page = "Emergency Kit";
        // Set title
        this.Title = Page;
        // Your string array
        string[] Facts;
        if (Page == "Emergencies List")
        {
            Facts = EmergencyTips.GetEmergencies();
        }
        else if (Page == "Emergency Kit")
        {
            Facts = EmergencyTips.GetEmergencyKitItems();
        }
        else
        {
            Facts = EmergencyTips.GetFacts(Page);
        }
        FactItems = Array.ConvertAll(Facts, fact => new FactItem { Fact = fact, IsChecked = false });
        OnPropertyChanged(nameof(FactItems));
    }
    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Handle the CheckedChanged event here
        if (sender is CheckBox checkBox)
        {
            checkBox.IsChecked = e.Value;
        }
    }
    private void OnLabelTapped(object sender, EventArgs e)
    {
        // Get the Label that was tapped
        if (sender is Label label)
        {
            // Get the CheckBox from the parent layout (assuming it's the first child)
            if (label.Parent is StackLayout sl)
            {
                if (sl.Children[0] is CheckBox checkBox)
                {
                    // Toggle the IsChecked property of the CheckBox
                    checkBox.IsChecked = !checkBox.IsChecked;
                }
            }
        }
    }

    public class FactItem
    {
        public string Fact { get; set; } = "";
        public bool IsChecked { get; set; } = false;
    }
}