using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tour_api.DTO;

namespace tour_client.ViewModels
{
    internal class HotelPageViewModel : ViewModelBase
    {
        private List<HotelFullDTO> _fullDataHotel;
        private int _countItems = 10;
        private int _position = 0;
        private int _allPositions;
        private int _countHotels;

        public int CountItems
        {
            get => _countItems;
            set
            {
                this.RaiseAndSetIfChanged(ref _countItems, value);
                ChangeCountItems();
                ChangePosition();
            }
        }

        public int Position
        {
            get => _position;
            set => this.RaiseAndSetIfChanged(ref _position, value);
        }

        public int AllPositions
        {
            get => _allPositions;
            set => this.RaiseAndSetIfChanged(ref _allPositions, value);
        }

        public int CountHotels
        {
            get => _countHotels;
            set => this.RaiseAndSetIfChanged(ref _countHotels, value);
        }

        public List<HotelFullDTO> FullDataHotel
        {
            get => _fullDataHotel;
            set => this.RaiseAndSetIfChanged(ref _fullDataHotel, value);
        }

        public HotelPageViewModel()
        {
            ChangeCountItems();
            ToStart();
        }

        private async Task GetHotels()
        {
            string result = await MainWindowViewModel.ApiClient.GetHotels();
            FullDataHotel =
                JsonConvert.DeserializeObject<List<HotelFullDTO>>(result);
        }

        public async Task ToStart()
        {
            Position = 1;
            await ChangePosition();
        }

        public async Task ToEnd()
        {
            Position = AllPositions;
            await ChangePosition();
        }

        public async Task StepNext()
        {
            if (Position < AllPositions)
            {
                Position++;
            }
            await ChangePosition();
        }

        public async Task StepBack()
        {
            if (Position > 1)
            {
                Position--;
            }
            await ChangePosition();
        }

        private async Task ChangePosition()
        {
            await GetHotels();

            if (FullDataHotel != null)
            {
                FullDataHotel = FullDataHotel.Skip((Position - 1) * CountItems).Take(CountItems).ToList();
            }
        }

        private async Task ChangeCountItems()
        {
            await GetHotels();

            CountHotels = FullDataHotel.Count;

            if (CountItems > FullDataHotel.Count)
            {
                CountItems = FullDataHotel.Count;
            }

            if (CountItems < 0)
            {
                CountItems = 0;
            }

            AllPositions = CountHotels % _countItems == 0 ? CountHotels / _countItems : CountHotels / _countItems + 1;
        }

        public async Task DeleteHotel(HotelFullDTO hotel)
        {
            if (hotel != null)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Удаление", $"Вы действительно хотите удалить отель {hotel.Name}?", ButtonEnum.YesNo);

                var result = await box.ShowAsync();

                switch (result)
                {
                    case ButtonResult.Yes:
                        await MainWindowViewModel.ApiClient.DeleteHotel(hotel.Id);
                        await ChangePosition();
                        break;
                    case ButtonResult.No:
                        return;
                    default:
                        return;
                }

            }
        }
    }
}
