using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace tour_client.Convertors
{
    internal class BoolToColor : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue == 1 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(new Color(255, 227, 30, 36));
            }

            return new SolidColorBrush(new Color(255, 68, 92, 147));
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
