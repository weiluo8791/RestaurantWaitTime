﻿using System;
using Windows.UI.Xaml.Data;

namespace UserClient.Common
{
    /// <summary>
    /// Enum MobileServiceEndpoints
    /// </summary>
    public enum ProviderTypes
    {   
        Twitter,
        Google
    }


    /// <summary>
    /// Class ProviderTypesEnumConverter.
    /// </summary>
    public class ProviderTypesEnumConverter : IValueConverter
    {

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns>System.Object.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null)
            {
                return false;
            }

            string checkValue = value.ToString();

            string targetValue = parameter.ToString();

            return checkValue.Equals(targetValue, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns>System.Object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null)
            {
                return null;
            }

            bool useValue = (bool)value;

            string targetValue = parameter.ToString();

            if (useValue)
            {
                return Enum.Parse(typeof(ProviderTypes), targetValue);
            }

            return null;
        }
    }   
}
