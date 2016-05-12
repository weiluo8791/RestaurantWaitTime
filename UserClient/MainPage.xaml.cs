using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using UserClient.Common;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UserClient
{

    public class UserRestaurant
    {
        public string RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string Hours { get; set; }
        public string Cuisine { get; set; }
        public string Capacity { get; set; }
        public string PropertyID { get; set; }
        public string Location { get; set; }

        public UserRestaurant(string id, string name, string address, string city, string state, string zip, string phone, string website, string email, string hours, string cuisine, string capacity, string propertyid, string location)
        {
            RestaurantId = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            Phone = phone;
            WebSite = website;
            Email = email;
            Hours = hours;
            Cuisine = cuisine;
            Capacity = capacity;
            PropertyID = propertyid;
            Location = location;
        }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        private MiniViewModel _miniViewModel = new MiniViewModel();

        List<UserRestaurant> ListUserRestaurants { get; set; }


        public MainPage()
        {
            InitializeComponent();
        }

        private void TitleHeader_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void AllRestaurantListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = AllRestaurantListBox.SelectedIndex;
            string id = ListUserRestaurants[index].RestaurantId;
            Frame.Navigate(typeof(RestaurantPage), id);

        }

        private async void LoginLogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.MobileServiceDotNet.CurrentUser == null || App.MobileServiceDotNet.CurrentUser.UserId == null)
            {
                await App.AuthenticateUserAsync(_miniViewModel.ProviderType);

                LoginLogoutButton.Content = "Logout";
                LoginLogoutButton.Background = new SolidColorBrush(Colors.Green);
                TwitterRadioButton.IsEnabled = false;
                GoogleRadioButton.IsEnabled = false;
            }
            else
            {
                await App.MobileServiceDotNet.LogoutAsync();

                LoginLogoutButton.Background = new SolidColorBrush(Colors.DarkRed);
                LoginLogoutButton.Content = "Login";
                TwitterRadioButton.IsEnabled = true;
                GoogleRadioButton.IsEnabled = true;
            }
        }
    }
}
