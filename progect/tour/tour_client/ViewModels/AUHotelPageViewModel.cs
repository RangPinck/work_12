using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.Generic;
using System.Threading.Tasks;
using tour_api.DTO;
using System.Linq;

namespace tour_client.ViewModels
{
    internal class AUHotelPageViewModel : ViewModelBase
    {
        private HotelShortDTO _newHotel;
        private List<CountryDTO> _countries;
        private int _selectedIndexCountry = 0;

        public List<CountryDTO> Countries
        {
            get => _countries;
            set => this.RaiseAndSetIfChanged(ref _countries, value);
        }

        public HotelShortDTO NewHotel
        {
            get => _newHotel;
            set => this.RaiseAndSetIfChanged(ref _newHotel, value);
        }

        public int SelectedIndexCountry
        {
            get => _selectedIndexCountry;
            set => this.RaiseAndSetIfChanged(ref _selectedIndexCountry, value);
        }

        public AUHotelPageViewModel()
        {
            _newHotel = new HotelShortDTO();
            GetCountries();
        }

        public AUHotelPageViewModel(HotelShortDTO newHotel)
        {
            _newHotel = new HotelShortDTO()
            {
                Id = newHotel.Id,
                Name = newHotel.Name,
                CountryCode = newHotel.CountryCode,
                CountOfStars = newHotel.CountOfStars,
                Description = newHotel.Description,
            };

            GetCountries();
        }

        private async Task GetCountries()
        {
            string result = await MainWindowViewModel.ApiClient.GetCountries();
            Countries = JsonConvert.DeserializeObject<List<CountryDTO>>(result);

            if (NewHotel.Id == 0)
            {
                SelectedIndexCountry = 1;
                SelectedIndexCountry = 0;
            }
            else
            {
                SelectedIndexCountry = Countries.IndexOf(Countries.FirstOrDefault(x => x.Code == NewHotel.CountryCode));
            }
        }

        public void GoToBack()
        {
            MainWindowViewModel.Instance.PageControl = new HotelPage();
        }

        public async Task SaveChenges()
        {
            if (FillingVerification())
            {
                NewHotel.CountryCode = Countries[SelectedIndexCountry].Code;

                if (NewHotel.Id == 0)
                {
                    MainWindowViewModel.ApiClient.AddHotel(NewHotel);
                }
                else
                {
                    MainWindowViewModel.ApiClient.UpdateHotel(NewHotel);
                }

                GoToBack();
            }
            else
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Ошибка", $"Не правильно заполнены, либо отсутсвуют данные!", ButtonEnum.Ok);

                await box.ShowAsync();
            }
        }

        public bool FillingVerification()
        {
            if (string.IsNullOrEmpty(NewHotel.Name)) return false;
            if (string.IsNullOrEmpty(NewHotel.Description)) return false;
            if (NewHotel.CountOfStars > 5 && NewHotel.CountOfStars < 0) return false;

            return true;
        }
    }
}
