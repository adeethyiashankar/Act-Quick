namespace Act_Quick
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
#if WINDOWS
            window.HandlerChanged += (s, e) =>
            {
                var mauiWindow = window.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
                if (mauiWindow != null)
                {
                    var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mauiWindow);
                    var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                    if (appWindow != null)
                    {
                        appWindow.Resize(new Windows.Graphics.SizeInt32(500, 800));
                    }
                }
            };
#endif
            return window;
        }
    }
}