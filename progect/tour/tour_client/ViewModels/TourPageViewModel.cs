using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReactiveUI;
using tour_api.DTO;

namespace tour_client.ViewModels
{
    internal class TourPageViewModel : ViewModelBase
    {
        private List<TourDTO> _tours = new List<TourDTO>();
        private List<TourTypesDTO> _toursTypes = new List<TourTypesDTO>();
        private int _selectItemToursType = 0;

        public List<TourDTO> Tours
        {
            get => _tours;
            set => this.RaiseAndSetIfChanged(ref _tours, value);
        }

        public List<TourTypesDTO> ToursTypes
        {
            get => _toursTypes;
            set => this.RaiseAndSetIfChanged(ref _toursTypes, value);
        }

        public int SelectItemToursType
        {
            get => _selectItemToursType;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectItemToursType, value);
                ApplyFilters();
            }
        }

        public TourPageViewModel()
        {
            GetToursTypes();
            ApplyFilters();
        }

        private async Task GetTours()
        {
            string result = await MainWindowViewModel.ApiClient.GetTours();
            Tours =
                JsonConvert.DeserializeObject<List<TourDTO>>(result);
        }

        private async Task GetToursTypes()
        {
            string result = await MainWindowViewModel.ApiClient.GetToursTypes();
            ToursTypes = [new TourTypesDTO() { Id = 0, Type = "Не выбрано" }, .. JsonConvert.DeserializeObject<List<TourTypesDTO>>(result)];
        }

        private void ApplyFilters()
        {
            GetTours();

            if (SelectItemToursType != 0)
            {
                Tours = Tours.Where(x => x.Type.Contains(ToursTypes[SelectItemToursType].Id)).ToList();
            }
        }
    }
}
