using Launcher.Utils;
using System.Diagnostics;

Console.Clear();

await Task.Delay(1000);

string? version = Argument.GetVersion();
if (version == null)
{
    Console.WriteLine("Version argument wasn't provided.");
    await Task.Delay(10000);
    Environment.Exit(1);
}

IEnumerable<string> list = Argument.GenerateLauncherArguments();
Console.WriteLine($"Got arguments: {string.Join(" ", list)}");
string launcherPath = $"{Directory.GetCurrentDirectory()}/launcher.exe";

if (File.Exists(launcherPath))
    File.Delete(launcherPath);

Console.WriteLine($"Downloading {version}");
await DownloadManager.DownloadLauncher(version, launcherPath);
Process launcherProcess = new Process();
launcherProcess.StartInfo.FileName = launcherPath;
launcherProcess.StartInfo.Arguments = string.Join(" ", list);
launcherProcess.Start();
Environment.Exit(1);