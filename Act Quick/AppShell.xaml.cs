namespace Act_Quick
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("ButtonListPage", typeof(ButtonListPage));
            Routing.RegisterRoute("FactListPage", typeof(FactListPage));
        }
    }
}