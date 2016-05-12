using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Rest;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using RestaurantClient.Common;
using RestaurantClient.Models;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RestaurantClient
{

    public class MyRestaurant : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Id { get; set; }
        public string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != null && _Name != value)
                {
                    JToken json = JObject.FromObject(new { Name = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string _Address;
        public string Address
        {
            get { return _Address; }
            set
            {
                if (_Address != null && _Address != value)
                {
                    JToken json = JObject.FromObject(new { Address = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if (_City != null && _City != value)
                {
                    JToken json = JObject.FromObject(new { City = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _City = value;
                OnPropertyChanged(nameof(City));
            }
        }
        public string _State;
        public string State
        {
            get { return _State; }
            set
            {
                if (_State != null && _State != value)
                {
                    JToken json = JObject.FromObject(new { State = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _State = value;
                OnPropertyChanged(nameof(State));
            }
        }
        public string _Zip;
        public string Zip
        {
            get { return _Zip; }
            set
            {
                if (_Zip != null && _Zip != value)
                {
                    JToken json = JObject.FromObject(new { Zip = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _Zip = value;
                OnPropertyChanged(nameof(Zip));
            }
        }
        public string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if (_Phone != null && _Phone != value)
                {
                    JToken json = JObject.FromObject(new { Phone = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public string _WebSite;
        public string WebSite
        {
            get { return _WebSite; }
            set
            {
                if (_WebSite != null && _WebSite != value)
                {
                    JToken json = JObject.FromObject(new { WebSite = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _WebSite = value;
                OnPropertyChanged(nameof(WebSite));
            }
        }
        public string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != null && _Email != value)
                {
                    JToken json = JObject.FromObject(new { Email = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _Email = value;
                OnPropertyChanged(nameof(_Email));
            }
        }
        public string _Hours;
        public string Hours
        {
            get { return _Hours; }
            set
            {
                if (_Hours != null && _Hours != value)
                {
                    JToken json = JObject.FromObject(new { Hours = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _Hours = value;
                OnPropertyChanged(nameof(Hours));
            }
        }
        public string _Cuisine;
        public string Cuisine
        {
            get { return _Cuisine; }
            set
            {
                if (_Cuisine != null && _Cuisine != value)
                {
                    JToken json = JObject.FromObject(new { Cuisine = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _Cuisine = value;
                OnPropertyChanged(nameof(Cuisine));
            }
        }
        public string _Capacity;
        public string Capacity
        {
            get { return _Capacity; }
            set
            {
                if (_Capacity != null && _Capacity != value)
                {
                    JToken json = JObject.FromObject(new { Capacity = value });
                    App.MobileServiceDotNet.InvokeApiAsync("UpdateRestaurant/" + Id, json);
                }
                _Capacity = value;
                OnPropertyChanged(nameof(Capacity));
            }
        }
        public string PropertyID { get; set; }
        public string Location { get; set; }

        public MyRestaurant(string id,string name, string address, string city, string state, string zip, string phone,string website,string email,string hours,string cuisine,string capacity,string propertyid,string location)
        {
            Id = id;
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
    }


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly RestaurantWaitTime _clientSdk = new RestaurantWaitTime();
        private string _currentRestaurantName = "";

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel { get; } = new ObservableDictionary();

        private readonly MiniViewModel _miniViewModel = new MiniViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _miniViewModel;
            NavigationCacheMode = NavigationCacheMode.Enabled;
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
                //load restaurant after log in
                RestaurantDetail_load();

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

        private async void RestaurantDetail_load()
        {
            try
            {
                StatusTextBlock.Text = "GET Request Made, waiting for response...";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.White);
                StatusBorder.Background = new SolidColorBrush(Colors.Blue);
                // Let the user know something happening
                progressBar.IsIndeterminate = true;

                // get restaurantId by making the call asynchronously using GET verb
                var resultJson = await App.MobileServiceDotNet.InvokeApiAsync("GetCurrentRestaurant", HttpMethod.Get, null);
                string restaurantId = resultJson.Value<string>("restaurantId");

                // get restaurant data by making the call to the SDK
                Task<HttpOperationResponse<Restaurant>> resultTask =
                    _clientSdk.Restaurants.GetRestaurantByRestaurantidWithOperationResponseAsync(restaurantId);
                resultTask.Wait();
                if (resultTask.Result.Response.IsSuccessStatusCode)
                {

                    string name = resultTask.Result.Body.Name;
                    string address = resultTask.Result.Body.Address;
                    string city = resultTask.Result.Body.City;
                    string state = resultTask.Result.Body.State;
                    string zip = resultTask.Result.Body.Zip;
                    string phone = resultTask.Result.Body.Phone;
                    string website = resultTask.Result.Body.WebSite;
                    string email = resultTask.Result.Body.Email;
                    string hours = resultTask.Result.Body.Hours;
                    string cuisine = resultTask.Result.Body.Cuisine;
                    string capacity = resultTask.Result.Body.Capacity;
                    string propertyid = resultTask.Result.Body.PropertyID;
                    string location = resultTask.Result.Body.Location;
                    _currentRestaurantName = resultTask.Result.Body.Name;

                    var myRestaurant = new MyRestaurant(restaurantId, name, address, city, state, zip, phone, website,
                        email, hours, cuisine, capacity, propertyid, location);
                    Restaurant.DataContext = myRestaurant;

                    StatusBorder.Background = new SolidColorBrush(Colors.Green);
                    StatusTextBlock.Text = "Request completed!";
                }
            }

            catch (MobileServiceInvalidOperationException ex)
            {
                // Display the exception message for the demo

                string responseMsg = await ex.Response.Content.ReadAsStringAsync();

                JObject o = JObject.Parse(responseMsg);
                string messageResult = o.Value<string>("message");
                StatusTextBlock.Text = ex.Message;
                StatusBorder.Background = new SolidColorBrush(Colors.Red);

            }
            finally
            {
                // Let the user know something happening
                progressBar.IsIndeterminate = false;
            }
        }

        private async void RestaurantDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatusTextBlock.Text = "GET Request Made, waiting for response...";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.White);
                StatusBorder.Background = new SolidColorBrush(Colors.Blue);
                // Let the user know something happening
                progressBar.IsIndeterminate = true;

                // get restaurantId by making the call asynchronously using GET verb
                var resultJson = await App.MobileServiceDotNet.InvokeApiAsync("GetCurrentRestaurant", HttpMethod.Get, null);
                string restaurantId = resultJson.Value<string>("restaurantId");

                // get restaurant data by making the call to the SDK
                Task<HttpOperationResponse<Restaurant>> resultTask =
                    _clientSdk.Restaurants.GetRestaurantByRestaurantidWithOperationResponseAsync(restaurantId);
                resultTask.Wait();
                if (resultTask.Result.Response.IsSuccessStatusCode)
                {

                    string name = resultTask.Result.Body.Name;
                    string address = resultTask.Result.Body.Address;
                    string city = resultTask.Result.Body.City;
                    string state = resultTask.Result.Body.State;
                    string zip = resultTask.Result.Body.Zip;
                    string phone = resultTask.Result.Body.Phone;
                    string website = resultTask.Result.Body.WebSite;
                    string email = resultTask.Result.Body.Email;
                    string hours = resultTask.Result.Body.Hours;
                    string cuisine = resultTask.Result.Body.Cuisine;
                    string capacity = resultTask.Result.Body.Capacity;
                    string propertyid = resultTask.Result.Body.PropertyID;
                    string location = resultTask.Result.Body.Location;
                    _currentRestaurantName = resultTask.Result.Body.Name;

                    var myRestaurant = new MyRestaurant(restaurantId, name, address, city, state, zip, phone, website,
                        email, hours, cuisine, capacity, propertyid, location);
                    Restaurant.DataContext = myRestaurant;

                    StatusBorder.Background = new SolidColorBrush(Colors.Green);
                    StatusTextBlock.Text = "Request completed!";
                }
            }

            catch (MobileServiceInvalidOperationException ex)
            {
                // Display the exception message for the demo

                string responseMsg = await ex.Response.Content.ReadAsStringAsync();

                JObject o = JObject.Parse(responseMsg);
                string messageResult = o.Value<string>("message");
                StatusTextBlock.Text = ex.Message;
                StatusBorder.Background = new SolidColorBrush(Colors.Red);

            }
            finally
            {
                // Let the user know something happening
                progressBar.IsIndeterminate = false;
            }
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Switch page to temperature lookup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaitTime_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WaitTimePage), _currentRestaurantName);
        }
    }
}
