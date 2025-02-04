using Avalonia.Controls;
using tour_client.ViewModels;

namespace tour_client;

public partial class HotelPage : UserControl
{
    public HotelPage()
    {
        InitializeComponent();
        DataContext = new HotelPageViewModel();
    }
}