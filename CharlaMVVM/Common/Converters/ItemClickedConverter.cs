using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace CharlaMVVM.Common.Converters
{
    /// <summary>
    /// Clase para obtener el elemento seleccionado desde los argumentos del evento ItemClick.
    /// </summary>
    public class ItemClickedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var args = value as ItemClickEventArgs;
            return args != null ? args.ClickedItem : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            string language)
        {
            throw new NotImplementedException();
        }
    }
}
