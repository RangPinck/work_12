using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Globalization;

namespace tour_client.Convertors
{
    internal class ImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                return value == null ? new Bitmap(AssetLoader.Open(new Uri("avares://tour_client/Assets/picture.png"))) : new Bitmap(AssetLoader.Open(new Uri($"avares://tour_client/Assets/{value}")));
            }catch 
            {
                return new Bitmap(AssetLoader.Open(new Uri("avares://tour_client/Assets/picture.png")));
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
