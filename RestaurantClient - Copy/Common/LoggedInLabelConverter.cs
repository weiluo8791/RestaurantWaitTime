using System;
using Windows.UI.Xaml.Data;

namespace RestaurantClient.Common
{
    class LoggedInLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                bool loggedIn = (bool)value;
                if (loggedIn)
                {
                    return "Logout";
                }
                else
                {
                    return "Login";
                }
            }

            return "Login";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
            {
                string loggedIn = (string)value;
                return loggedIn == "Logout";
            }

            return false;
        }
    }
}
