using System.Text.Json;
using Writelong.Windows.Models;

namespace Writelong.Windows.Services;

public sealed class SettingsStore
{
    private static readonly JsonSerializerOptions SerializerOptions = new() { WriteIndented = true };
    private readonly string path = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "Writelong",
        "settings.json");

    public WritelongSettings Load()
    {
        try
        {
            return File.Exists(path)
                ? JsonSerializer.Deserialize<WritelongSettings>(File.ReadAllText(path)) ?? new WritelongSettings()
                : new WritelongSettings();
        }
        catch (JsonException)
        {
            return new WritelongSettings();
        }
    }

    public void Save(WritelongSettings settings)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonSerializer.Serialize(settings, SerializerOptions));
    }
}
