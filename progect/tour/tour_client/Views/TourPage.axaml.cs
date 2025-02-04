using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using tour_client.ViewModels;

namespace tour_client;

public partial class TourPage : UserControl
{
    public TourPage()
    {
        InitializeComponent();
        DataContext = new TourPageViewModel();
    }
}