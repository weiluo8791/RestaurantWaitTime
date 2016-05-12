using System;
using System.ComponentModel;
using Microsoft.WindowsAzure.MobileServices;

namespace UserClient.Common
{
    public class MiniViewModel : INotifyPropertyChanged
    {
        private ProviderTypes _providerTypesChoice = ProviderTypes.Twitter;

        /// <summary>
        /// Gets or sets the mobile service endpoint choice.
        /// </summary>
        /// <value>The mobile service endpoint choice.</value>
        public ProviderTypes ProviderTypesChoice
        {
            get
            {
                return _providerTypesChoice;
            }
            set
            {

                _providerTypesChoice = value;
                OnPropertyChanged("ProviderTypesChoice");
                OnPropertyChanged("LoggedIn");
                OnPropertyChanged("LoggedOut");

            }
        }

        /// <summary>
        /// Gets a value indicating whether [LoggedIn].
        /// </summary>
        /// <value><c>true</c> if [LoggedIn]; otherwise, <c>false</c>.</value>
        public bool LoggedIn
        {
            get
            {
                return App.MobileServiceDotNet.CurrentUser != null &&
                       App.MobileServiceDotNet.CurrentUser.UserId != null;
            }
        }


        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Returns the authentication provider type for the Mobile App Service
        /// </summary>
        public MobileServiceAuthenticationProvider ProviderType
        {
            get
            {
                switch (ProviderTypesChoice)
                {
                    case ProviderTypes.Twitter:
                        return MobileServiceAuthenticationProvider.Twitter;

                    case ProviderTypes.Google:
                        return MobileServiceAuthenticationProvider.Google;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
        }

    }
}
