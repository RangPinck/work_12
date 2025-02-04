using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Threading.Tasks;
using tour_client.Models;
using static tour_client.Models.ApiConnect;

namespace tour_client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ConnectionState _checkConnection;
        private int _countSecondsMessage = 10;
        private bool _messageVisible = false;
        private string _title = String.Empty;
        private string _message = String.Empty;
        private UserControl _pageControl = new TourPage();

        public static ApiConnect ApiClient = new ApiConnect("http://localhost:5120/tour_api/");
        public static MainWindowViewModel Instance;

        public enum MessageStyle
        {
            Add,
            Error,
            Message
        }

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public bool MessageVisible
        {
            get => _messageVisible;
            set => this.RaiseAndSetIfChanged(ref _messageVisible, value);
        }

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public UserControl PageControl
        {
            get => _pageControl;
            set => this.RaiseAndSetIfChanged(ref _pageControl, value);
        }

        public MainWindowViewModel()
        {
            CheckConnection();
            Instance = this;
        }

        private async Task CheckConnection()
        {
            _checkConnection = await ApiClient.CheckConnection();

            switch (_checkConnection)
            {
                case ConnectionState.Connected:
                    break;
                case ConnectionState.DisconnectedDataBase:
                    break;
                case ConnectionState.DisconnectedInternet:
                    break;
            }
        }
    }
}
