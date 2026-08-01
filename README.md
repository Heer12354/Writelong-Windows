# Writelong for Windows

Writelong is a private, local-first writing assistant for Windows 11. It is the Windows counterpart to the macOS Writelong app.

## Planned capabilities

- System-wide text completion using Windows UI Automation.
- A notification-area icon, keyboard shortcuts, and a settings window.
- Local ONNX-based language models and opt-in cloud providers.
- Per-app controls, writing profiles, and privacy-first local storage.

## Development setup (Windows 11)

1. Install Visual Studio 2026 with the **WinUI application development** workload and .NET 10 SDK.
2. Open `Writelong.Windows.sln`.
3. Restore NuGet packages, then run the `Writelong.Windows` project on `x64` or `ARM64`.

For a hosted Windows build, push the project to GitHub and run the **Build Writelong for Windows** workflow. It publishes a self-contained `Writelong.Windows.exe` artifact for Windows x64.

The project targets Windows 11 build 22000 or newer and uses WinUI 3 through the Windows App SDK.

## Releases

Create public releases manually from the **Build and Release Windows App** GitHub Action. Enter the next version without the `v` prefix: `1.1`, then `1.2`, and so on. This creates releases named `v1.1`, `v1.2`, and so forth.

## Current foundation

The first scaffold includes the WinUI app shell, local JSON-backed settings, the appearance chooser, and contracts for UI Automation context capture, local inference, and the completion overlay. The next implementation phase wires these contracts to Windows APIs and a local ONNX model runtime.
