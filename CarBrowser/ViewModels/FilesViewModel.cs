using CarBrowser.Services;
using CarBrowser.Tools;
using CarBrowser.ViewModels.Base;
using CarLibrary.Models.DTO;
using CarLibrary.Models.DTO.FilesDetails;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace CarBrowser.ViewModels
{
    public class FilesViewModel : ViewModelBase
    {
        private readonly FilesListService _fileListService;
        private readonly FileDetailsService _detailsService;
        private readonly FileDownloadService _downloadService;

        public ObservableCollection<FileNameDTO> AvailableFiles { get; } = new();

        private FileNameDTO? _selectedFile;
        public FileNameDTO? SelectedFile
        {
            get => _selectedFile;
            set
            {
                _selectedFile = value;
                OnPropertyChanged();
                (DownloadMetadataCommand as AsyncRelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private FileDetailsDTO? _details;
        public FileDetailsDTO? Details
        {
            get => _details;
            set
            {
                _details = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DetailsText));
                (DownloadFileCommand as AsyncRelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private bool _isMetadataLoading;
        public bool IsMetadataLoading
        {
            get => _isMetadataLoading;
            set
            {
                _isMetadataLoading = value;
                OnPropertyChanged();
            }
        }

        private bool _isFileDownloading;
        public bool IsFileDownloading
        {
            get => _isFileDownloading;
            set
            {
                _isFileDownloading = value;
                OnPropertyChanged();
            }
        }

        private int _downloadProgress;
        public int DownloadProgress
        {
            get => _downloadProgress;
            set
            {
                _downloadProgress = value;
                OnPropertyChanged();
            }
        }

        public string DetailsText
        {
            get
            {
                if (Details == null)
                    return string.Empty;

                var a = Details.Attributes;

                return
                    $"ID: {Details.Id}\n" +
                    $"File URL: {a?.FileUrl}\n" +
                    $"Metadata URL: {a?.MetadataUrl}\n" +
                    $"Opis: {a?.ContentDescription}\n" +
                    $"Format: {a?.FileFormatDescription}\n" +
                    $"Typ zasobu: {a?.ResourceType}\n" +
                    $"Data utworzenia: {a?.FileCreationDate}";
            }
        }

        public ICommand LoadFilesCommand { get; }
        public ICommand DownloadMetadataCommand { get; }
        public ICommand DownloadFileCommand { get; }

        public FilesViewModel()
        {
            _fileListService = new FilesListService();
            _detailsService = new FileDetailsService();
            _downloadService = new FileDownloadService();

            DownloadMetadataCommand = new AsyncRelayCommand(
                DownloadMetadataAsync,
                () => SelectedFile != null
            );

            DownloadFileCommand = new AsyncRelayCommand(
                DownloadFileAsync,
                () => Details?.Attributes?.FileUrl != null
            );

            LoadFilesAsync();
        }

        private async void LoadFilesAsync()
        {
            var files = await _fileListService.GetFilesAsync();

            AvailableFiles.Clear();
            foreach (var file in files)
                AvailableFiles.Add(file);
        }

        private async Task DownloadMetadataAsync()
        {
            if (SelectedFile == null)
                return;

            var match = Regex.Match(SelectedFile.Name, @"\((.*?)\)");
            if (!match.Success)
                return;

            var id = match.Groups[1].Value;

            IsMetadataLoading = true;

            try
            {
                Details = await _detailsService.GetDetailsAsync(id);
            }
            finally
            {
                IsMetadataLoading = false;
            }
        }

        private async Task DownloadFileAsync()
        {
            if (Details?.Attributes?.FileUrl == null)
                return;

            IsFileDownloading = true;

            try
            {
                await _downloadService.DownloadFileWithDialogAsync(
                    Details.Attributes.FileUrl,
                    $"{Details.Id}.zip"
                );
            }
            finally
            {
                IsFileDownloading = false;
            }
        }
    }
}
