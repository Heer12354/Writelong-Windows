namespace Writelong.Windows.Services;

public sealed class SystemTrayService : IDisposable
{
    private Action? showSettings;
    private Action? quit;

    public void Initialize(Action showSettingsAction, Action quitAction)
    {
        showSettings = showSettingsAction;
        quit = quitAction;
    }

    public void Dispose()
    {
        showSettings = null;
        quit = null;
    }
}
