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
            ShowLoginCommand = new RelayCommand(() => ShowLogin());
            ShowFilteringCommand = new RelayCommand(() => ShowFiltering());
            ShowFilesCommand = new RelayCommand(() => ShowFiles());
            ExitCommand = new RelayCommand(() => Application.Current.Shutdown());

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

        private void OnLoginSuccess(string username)
        {
            ShowFiltering();
        }
    }
}
