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
        private List<TourTypesDTO> _toursTypes = new List<TourTypesDTO>() { };
        private int _selectIndexToursType;
        private string _search = string.Empty;
        private int _sumCostViewTours = 0;
        private bool _isActula = false;

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
            get => _selectIndexToursType;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectIndexToursType, value);
                ApplyFilters();
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                this.RaiseAndSetIfChanged(ref _search, value);
                ApplyFilters();
            }
        }

        public bool IsActual
        {
            get => _isActula;
            set
            {
                this.RaiseAndSetIfChanged(ref _isActula, value);
                ApplyFilters();
            }
        }

        public int SumCostViewTours
        {
            get => _sumCostViewTours;
            set => this.RaiseAndSetIfChanged(ref _sumCostViewTours, value);
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
            //спросить как пофиксить костыль
            SelectItemToursType = 1;
            SelectItemToursType = 0;
        }

        private async Task ApplyFilters()
        {
            await GetTours();

            if (!string.IsNullOrEmpty(Search))
            {
                Tours = Tours.Where(x => ($"{x.Name}{x.Description}").Contains(Search, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            if (SelectItemToursType != 0)
            {
                Tours = Tours.Where(x => x.Type.Contains(ToursTypes[SelectItemToursType].Id)).ToList();
            }

            if (IsActual)
            {
                Tours = Tours.Where(x=> x.IsActual == 1).ToList();
            }
        }
    }
}
