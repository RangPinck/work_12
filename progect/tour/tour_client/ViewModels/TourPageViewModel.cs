using System.Collections.Generic;
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

        public TourPageViewModel()
        {
            GetTours();
            GetToursTypes();
        }

        private async Task GetTours()
        {
            string result = await MainWindowViewModel.ApiClient.GetTours();
            Tours =
                JsonConvert.DeserializeObject<List<TourDTO>>(result);
        }

        private async Task GetToursTypes()
        {
            string result = await MainWindowViewModel.ApiClient.GetTours();
            ToursTypes =
                JsonConvert.DeserializeObject<List<TourTypesDTO>>(result);
        }
    }
}
