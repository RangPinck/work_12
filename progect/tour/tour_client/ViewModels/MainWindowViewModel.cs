using Avalonia.Controls;
using ReactiveUI;
using tour_client.Models;

namespace tour_client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserControl _pageControl = new TourPage();

        public static ApiConnect ApiClient = new ApiConnect("http://localhost:5120/tour_api/");
        public static MainWindowViewModel Instance;

        public UserControl PageControl
        {
            get => _pageControl;
            set => this.RaiseAndSetIfChanged(ref _pageControl, value);
        }

        public MainWindowViewModel()
        {
            Instance = this;
        }

        public void GoToHotel()
        {
            PageControl = new HotelPage();
        }

        public void GoToTour()
        {
            PageControl = new TourPage();
        }
    }
}
