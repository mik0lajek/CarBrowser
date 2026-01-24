using CarBrowser.Tools;
using CarBrowser.ViewModels.Base;

namespace CarBrowser.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        private readonly Action<string> _onLoginSuccess;

        public string Login
        {
            get => _login;
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public RelayCommand LoginCommand { get; }

        public LoginViewModel(Action<string> onLoginSuccess)
        {
            _onLoginSuccess = onLoginSuccess; 
            LoginCommand = new RelayCommand(ExecuteLogin, CanLogin);
        }

        private void ExecuteLogin()
        {
            _onLoginSuccess?.Invoke(Login);
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Login)
                && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
