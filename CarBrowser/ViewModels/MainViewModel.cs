using CarBrowser.Tools;
using CarBrowser.ViewModels.Base;
using System.Windows;

namespace CarBrowser.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _mainContent;
        public ViewModelBase MainContent
        {
            get => _mainContent;
            set { _mainContent = value; OnPropertyChanged(); }
        }

        public RelayCommand ShowLoginCommand { get; }
        public RelayCommand ShowFilteringCommand { get; }
        public RelayCommand ShowFilesCommand { get; }
        public RelayCommand ExitCommand { get; }

        public MainViewModel()
        {
            // Komendy menu
            ShowLoginCommand = new RelayCommand(() => ShowLogin());
            ShowFilteringCommand = new RelayCommand(() => ShowFiltering());
            ShowFilesCommand = new RelayCommand(() => ShowFiles());
            ExitCommand = new RelayCommand(() => Application.Current.Shutdown());

            // Start od logowania
            ShowLogin();
        }

        private void ShowLogin()
        {
            MainContent = new LoginViewModel(OnLoginSuccess);
        }

        private void ShowFiltering()
        {
            MainContent = new FilteringViewModel();
        }

        private void ShowFiles()
        {
            MainContent = new FilesViewModel();
        }

        // Callback wywoływany przez LoginViewModel
        private void OnLoginSuccess(string username)
        {
            // Można przechować username
            ShowFiltering();
        }
    }
}
