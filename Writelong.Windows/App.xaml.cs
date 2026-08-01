using Microsoft.UI.Xaml;
using Writelong.Windows.Services;

namespace Writelong.Windows;

public partial class App : Application
{
    private Window? window;
    private SystemTrayService? systemTray;

    public App()
    {
        InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var settingsStore = new SettingsStore();
        window = new MainWindow(settingsStore);
        systemTray = new SystemTrayService();
        systemTray.Initialize(ShowSettings, ExitApplication);
        window.Activate();
    }

    private void ShowSettings()
    {
        window?.Activate();
    }

    private void ExitApplication()
    {
        systemTray?.Dispose();
        Exit();
    }
}
