namespace Writelong.Windows.Services;

public sealed record TextContext(
    string BeforeCursor,
    string AfterCursor,
    string ApplicationName,
    string BundleIdentifier);

public sealed record CompletionSuggestion(string Text, double Confidence);

public interface ITextContextProvider
{
    Task<TextContext?> GetFocusedTextContextAsync(CancellationToken cancellationToken);
}

public interface ICompletionEngine
{
    Task<CompletionSuggestion?> GenerateAsync(TextContext context, CancellationToken cancellationToken);
}

public interface ICompletionOverlay
{
    void Show(CompletionSuggestion suggestion);
    void Hide();
}
