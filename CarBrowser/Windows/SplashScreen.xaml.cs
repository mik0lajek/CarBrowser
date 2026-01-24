using System.Windows;
using System.Threading.Tasks;

namespace CarBrowser.Windows
{
    public partial class SplashScreen : Window
    {
        private readonly AvailabilityService _availability;

        public SplashScreen()
        {

            InitializeComponent();

            _availability = new AvailabilityService(App.Configuration);

            Loaded += SplashScreen_Loaded;
        }


        private async void SplashScreen_Loaded(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "Sprawdzanie CarGate...";

            bool carGateOk = await _availability.CheckCarGateAsync();
            if (!carGateOk)
            {
                MessageBox.Show("Brak dostępności serwera CarGate.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
                return;
            }

            statusLabel.Content = "CarGate dostępny.";
            await Task.Delay(500);

            statusLabel.Content = "Sprawdzanie CEPiK...";

            bool cepikOk = await _availability.CheckCepikAsync();
            if (!cepikOk)
            {
                MessageBox.Show("Brak dostępności serwisu CEPiK.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
                return;
            }

            statusLabel.Content = "CEPiK dostępny.";
            await Task.Delay(500);

            var main = new MainWindow();
            main.Show();

            Close();
        }
    }
}
