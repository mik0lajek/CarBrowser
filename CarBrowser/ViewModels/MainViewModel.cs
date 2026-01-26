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
        public RelayCommand ShowAuthorsCommand { get; }

        public string CurrentUser { get; private set; }


        public MainViewModel()
        {
            ShowLoginCommand = new RelayCommand(() => ShowLogin());
            ShowFilteringCommand = new RelayCommand(() => ShowFiltering());
            ShowFilesCommand = new RelayCommand(() => ShowFiles());
            ExitCommand = new RelayCommand(() => Application.Current.Shutdown());
            ShowAuthorsCommand = new RelayCommand(ShowAuthors);


            ShowLogin();
        }

        private void ShowLogin()
        {
            CurrentUser = null;
            MainContent = new LoginViewModel(OnLoginSuccess);
        }

        private void ShowFiltering()
        {
            MainContent = new FilteringViewModel(CurrentUser);
        }

        private void ShowFiles()
        {
            MainContent = new FilesViewModel();
        }
        private void ShowAuthors()
        {
            MessageBox.Show(
                "Autorzy (Gr. 3):\n" +
                "• Dawid Zwolak\n" +
                "• Mikołaj Sosiński\n\n" +
                "Źródło danych:\n" +
                "• CEPiK: https://api.cepik.gov.pl/doc\n",
                "Informacje",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }

        private void OnLoginSuccess(string username)
        {
            CurrentUser = username;
            ShowFiltering();
        }
    }
}
