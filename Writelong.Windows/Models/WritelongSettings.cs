namespace Writelong.Windows.Models;

public enum MenuIcon
{
    Brand,
    Pen,
    Sparkle,
    Document
}

public sealed record WritelongSettings(
    bool CompletionsEnabled = true,
    bool LaunchAtLoginEnabled = false,
    MenuIcon MenuIcon = MenuIcon.Brand);
