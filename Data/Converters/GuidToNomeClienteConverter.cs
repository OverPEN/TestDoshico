using Data.Services;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Data.Converters
{
    public class GuidToNomeClienteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Guid id = value != null ? Guid.Parse(value.ToString()) : Guid.Empty;
            return DataManager.GetClienteByID(id).NomeCognome;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
