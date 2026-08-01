using Microsoft.UI.Xaml;

namespace Writelong.Windows;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        Application.Start(_ => new App());
    }
}
