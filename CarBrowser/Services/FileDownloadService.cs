using Microsoft.Win32;
using System.Net.Http;
using System.IO;


namespace CarBrowser.Services
{
    public class FileDownloadService
    {
        private readonly HttpClient _client;

        public FileDownloadService()
        {
            _client = new HttpClient();
        }

        public async Task DownloadFileWithDialogAsync(string url, string suggestedName, CancellationToken ct = default)
        {
            var dialog = new SaveFileDialog
            {
                FileName = suggestedName.EndsWith(".zip") ? suggestedName : suggestedName + ".zip",
                Filter = "ZIP files (*.zip)|*.zip|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() != true)
                return;

            var bytes = await _client.GetByteArrayAsync(url, ct);

            await File.WriteAllBytesAsync(dialog.FileName, bytes, ct);
        }
    }
}
