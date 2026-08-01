using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Writelong.Windows.Models;
using Writelong.Windows.Services;

namespace Writelong.Windows;

public sealed partial class MainWindow : Window
{
    private readonly SettingsStore settingsStore;
    private WritelongSettings settings;

    public MainWindow(SettingsStore settingsStore)
    {
        InitializeComponent();
        this.settingsStore = settingsStore;
        settings = settingsStore.Load();
        CompletionsToggle.IsOn = settings.CompletionsEnabled;
        LaunchAtLoginToggle.IsOn = settings.LaunchAtLoginEnabled;
        MenuIconPicker.SelectedIndex = settings.MenuIcon switch
        {
            MenuIcon.Pen => 1,
            MenuIcon.Sparkle => 2,
            MenuIcon.Document => 3,
            _ => 0
        };
    }

    private void CompletionsToggle_Toggled(object sender, RoutedEventArgs args)
    {
        settings = settings with { CompletionsEnabled = CompletionsToggle.IsOn };
        settingsStore.Save(settings);
    }

    private void LaunchAtLoginToggle_Toggled(object sender, RoutedEventArgs args)
    {
        settings = settings with { LaunchAtLoginEnabled = LaunchAtLoginToggle.IsOn };
        settingsStore.Save(settings);
    }

    private void MenuIconPicker_SelectionChanged(object sender, SelectionChangedEventArgs args)
    {
        if (MenuIconPicker.SelectedItem is not ComboBoxItem item || item.Tag is not string icon)
        {
            return;
        }

        settings = settings with { MenuIcon = Enum.Parse<MenuIcon>(icon, true) };
        settingsStore.Save(settings);
    }

    private async void CheckForUpdates_Click(object sender, RoutedEventArgs args)
    {
        var dialog = new ContentDialog
        {
            Title = "Updates",
            Content = "Update checks will be connected to Writelong's GitHub Releases feed.",
            CloseButtonText = "OK",
            XamlRoot = Content.XamlRoot
        };
        await dialog.ShowAsync();
    }
}
