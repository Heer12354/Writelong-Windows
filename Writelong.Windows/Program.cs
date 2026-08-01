using Microsoft.UI.Xaml;

namespace Writelong.Windows;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        Environment.SetEnvironmentVariable("MICROSOFT_WINDOWSAPPRUNTIME_BASE_DIRECTORY", AppContext.BaseDirectory);
        Application.Start(_ => new App());
    }
}
