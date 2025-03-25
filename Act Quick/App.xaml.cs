namespace Act_Quick
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);
            if (activationState != null && window != null)
            {
#if WINDOWS
                window.Width = 400; // Set the width of the window
                window.Height = 700; // Set the height of the window
#endif
                return window;
            }
            return base.CreateWindow(activationState);
        }
    }
}