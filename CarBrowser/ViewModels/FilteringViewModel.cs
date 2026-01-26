using CarBrowser.Services;
using CarBrowser.Tools;
using CarBrowser.ViewModels.Base;
using CarLibrary.Models.DTO;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarBrowser.ViewModels
{
    public class FilteringViewModel : ViewModelBase
    {

        private readonly DictionaryService _dictionaryService;
        private readonly VehicleSearchService _vehicleSearchService;
        public string Username { get; private set; }

        public string LoggedUser => string.IsNullOrWhiteSpace(Username)
            ? "Nie zalogowano" : $"Zalogowany: {Username}";

        public ObservableCollection<string> Voivodeship { get; } = new();

        private bool _isSearching;
        public bool IsSearching
        {
            get => _isSearching;
            set
            {
                _isSearching = value;
                OnPropertyChanged();
            }
        }

        public string? SelectedVoivodeship
        {
            get => _selectedVoivodeship;
            set
            {
                _selectedVoivodeship = value;
                OnPropertyChanged();
            }
        }
        private string? _selectedVoivodeship;

        public DateTime MinAllowedDate => DateTime.Today.AddYears(-2); 
        public DateTime MaxAllowedDate => DateTime.Today;

        public DateTime? DateFrom
        {
            get => _dateFrom;
            set
            {
                _dateFrom = value;
                OnPropertyChanged();
            }
        }
        private DateTime? _dateFrom;

        public DateTime? DateTo
        {
            get => _dateTo;
            set
            {
                _dateTo = value;
                OnPropertyChanged();
            }
        }
        private DateTime? _dateTo;

        public bool IsRegistered
        {
            get => _isRegistered;
            set
            {
                _isRegistered = value;
                OnPropertyChanged();
            }
        }
        private bool _isRegistered;

        public ObservableCollection<int> PaginationOptions { get; } = new() { 10, 25, 50, 100 };
        public int SelectedPagination
        {
            get => _selectedPagination;
            set
            {
                _selectedPagination = value;
                OnPropertyChanged();
            }
        }
        private int _selectedPagination = 10;

        public ObservableCollection<VehicleBasicDTO> Vehicles { get; } = new();

        public VehicleBasicDTO? SelectedVehicle
        {
            get => _selectedVehicle;
            set
            {
                _selectedVehicle = value;
                OnPropertyChanged();
                LoadVehicleDetailsAsync();
            }
        }
        private VehicleBasicDTO? _selectedVehicle;

        public ObservableCollection<KeyValuePair<string, string>> VehicleDetails { get; } = new();

        public ICommand SearchCommand { get; }

        public FilteringViewModel(string username)
        {
            Username = username; 

            _dictionaryService = new DictionaryService();
            _vehicleSearchService = new VehicleSearchService();

            SearchCommand = new AsyncRelayCommand(SearchAsync);

            LoadProvincesAsync();
        }

        private async void LoadProvincesAsync()
        {
            var list = await _dictionaryService.GetProvincesAsync();

            Voivodeship.Clear();

            foreach (var p in list)
            {
                Voivodeship.Add($"{p.Code} - {p.Name}");
            }
        }

        private async Task SearchAsync()
        {
            if (IsSearching)
                return;

            IsSearching = true;

            try
            {
                Vehicles.Clear();

                var results = await _vehicleSearchService.SearchVehiclesAsync(
                    SelectedVoivodeship,
                    DateFrom,
                    DateTo,
                    IsRegistered,
                    SelectedPagination
                );

                foreach (var v in results)
                    Vehicles.Add(v);
            }
            finally
            {
                IsSearching = false;
            }
        }


        private async void LoadVehicleDetailsAsync()
        {
            if (SelectedVehicle == null)
                return;

            VehicleDetails.Clear();

            var details = await _vehicleSearchService.GetVehicleDetailsAsync(SelectedVehicle.Id);

            foreach (var kv in details)
            {
                var formattedKey = FormatKey(kv.Key);
                VehicleDetails.Add(new KeyValuePair<string, string>(formattedKey, kv.Value));
            }
        }

        private string FormatKey(string key)
        {
            var spaced = key.Replace("-", " ");
            return char.ToUpper(spaced[0]) + spaced.Substring(1);
        }

    }
}