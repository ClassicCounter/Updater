using Downloader;

namespace Launcher.Utils
{
    public static class DownloadManager
    {
        private static DownloadConfiguration _settings = new()
        {
            ChunkCount = 4,
            ParallelDownload = true
        };
        private static DownloadService _downloader = new DownloadService(_settings);

        public static async Task DownloadLauncher(string version, string path)
        {
            await _downloader.DownloadFileTaskAsync(
                $"https://github.com/ClassicCounter/launcher/releases/download/{version}/launcher.exe",
                path
            );
        }
    }
}
