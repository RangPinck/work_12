using Avalonia.Controls;
using tour_api.DTO;
using tour_client.ViewModels;

namespace tour_client;

public partial class AUHotelPage : UserControl
{
    public AUHotelPage()
    {
        InitializeComponent();
        DataContext = new AUHotelPageViewModel();
    }

    public AUHotelPage(HotelShortDTO newHotel)
    {
        InitializeComponent();
        DataContext = new AUHotelPageViewModel(newHotel);
    }
}