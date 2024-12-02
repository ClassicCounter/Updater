namespace Launcher.Utils
{
    public static class Argument
    {
        public static string? GetVersion()
        {
            IEnumerable<string> arguments = Environment.GetCommandLineArgs();

            foreach (string arg in arguments)
                if (arg.ToLowerInvariant().StartsWith("--version="))
                    return arg.Replace("--version=", "");

            return null;
        }

        public static List<string> GenerateLauncherArguments()
        {
            IEnumerable<string> updaterArguments = Environment.GetCommandLineArgs();
            List<string> launcherArguments = new();

            foreach (string arg in updaterArguments)
                if (!arg.ToLowerInvariant().StartsWith("--version=") && !arg.EndsWith(".exe"))
                    launcherArguments.Add(arg.ToLowerInvariant());

            return launcherArguments;
        }
    }
}
