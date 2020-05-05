using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XamarinValidatios.Validations
{
    public class IsValidEmailConverter : IValueConverter
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        private object obj;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            obj = value;

            if (value == null)
                return false;

            return (Regex.IsMatch(value.ToString(), emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return obj;
        }
    }
}
