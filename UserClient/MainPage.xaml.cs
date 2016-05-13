using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;
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
        public string Phone { get; set; }
        public string Hours { get; set; }

        public UserRestaurant(string id, string name, string address, string city, string state, string phone, string hours)
        {
            RestaurantId = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            Phone = phone;
            Hours = hours;

        }
    }

    public class PassToPage
    {
        public string name{get;set;}
        public string id{get;set;}
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
            DataContext = _miniViewModel;
            NavigationCacheMode = NavigationCacheMode.Enabled;
            LoadRestaurant();
        }

        private void TitleHeader_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void AllRestaurantListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = AllRestaurantListBox.SelectedIndex;
            string id = ListUserRestaurants[index].RestaurantId;
            string name = ListUserRestaurants[index].Name;
            Frame.Navigate(typeof(RestaurantPage), new PassToPage() { id = id, name = name});

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
                Subscription.Visibility = Visibility.Visible;
            }
            else
            {
                await App.MobileServiceDotNet.LogoutAsync();

                LoginLogoutButton.Background = new SolidColorBrush(Colors.DarkRed);
                LoginLogoutButton.Content = "Login";
                TwitterRadioButton.IsEnabled = true;
                GoogleRadioButton.IsEnabled = true;
                Subscription.Visibility = Visibility.Collapsed;
            }
        }

        private async void LoadRestaurant()
        {
            try
            {
                StatusTextBlock.Text = "GET Request Made, waiting for response...";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.White);
                StatusBorder.Background = new SolidColorBrush(Colors.Blue);
                // Let the user know something happening
                progressBar.IsIndeterminate = true;

                // get restaurantId by making the call asynchronously using GET verb
                var resultJson = await App.MobileServiceDotNet.InvokeApiAsync("GetAllRestaurants", HttpMethod.Get, null);

                JArray a = (JArray)resultJson;

                ObservableCollection<UserRestaurant> allRestaurant = new ObservableCollection<UserRestaurant>();

                ListUserRestaurants = a.ToObject<List<UserRestaurant>>();

                foreach (var pair in ListUserRestaurants)
                    allRestaurant.Add(new UserRestaurant
                        (pair.RestaurantId, pair.Name, pair.Address, pair.City, pair.State, pair.Phone, pair.Hours));

                AllRestaurantListBox.DataContext = allRestaurant;


                StatusBorder.Background = new SolidColorBrush(Colors.Green);
                StatusTextBlock.Text = "Request completed!";

                // Verify that a result was returned
                if (resultJson.HasValues)
                {

                }
                else
                {
                    StatusBorder.Background = new SolidColorBrush(Colors.Orange);
                    StatusTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                }


            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
                StatusBorder.Background = new SolidColorBrush(Colors.Red);
            }
            finally
            {
                // Let the user know something happening
                progressBar.IsIndeterminate = false;
            }
        }


        private async void Subscription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatusTextBlock.Text = "GET Request Made, waiting for response...";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.White);
                StatusBorder.Background = new SolidColorBrush(Colors.Blue);
                // Let the user know something happening
                progressBar.IsIndeterminate = true;

                // get restaurantId by making the call asynchronously using GET verb
                var resultJson = await App.MobileServiceDotNet.InvokeApiAsync("GetSubscribedRestaurants", HttpMethod.Get, null);

                JArray a = (JArray)resultJson;

                ObservableCollection<UserRestaurant> allRestaurant = new ObservableCollection<UserRestaurant>();

                ListUserRestaurants = a.ToObject<List<UserRestaurant>>();

                foreach (var pair in ListUserRestaurants)
                    allRestaurant.Add(new UserRestaurant
                        (pair.RestaurantId, pair.Name, pair.Address, pair.City, pair.State, pair.Phone, pair.Hours));

                AllRestaurantListBox.DataContext = allRestaurant;


                StatusBorder.Background = new SolidColorBrush(Colors.Green);
                StatusTextBlock.Text = "Request completed!";

                // Verify that a result was returned
                if (resultJson.HasValues)
                {
                    Subscription.Visibility = Visibility.Collapsed;
                    LoadAll.Visibility = Visibility.Visible;
                }
                else
                {
                    StatusBorder.Background = new SolidColorBrush(Colors.Orange);
                    StatusTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                }


            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
                StatusBorder.Background = new SolidColorBrush(Colors.Red);
            }
            finally
            {
                // Let the user know something happening
                progressBar.IsIndeterminate = false;
            }


        }

        private async void LoadAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatusTextBlock.Text = "GET Request Made, waiting for response...";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.White);
                StatusBorder.Background = new SolidColorBrush(Colors.Blue);
                // Let the user know something happening
                progressBar.IsIndeterminate = true;

                // get restaurantId by making the call asynchronously using GET verb
                var resultJson = await App.MobileServiceDotNet.InvokeApiAsync("GetAllRestaurants", HttpMethod.Get, null);

                JArray a = (JArray)resultJson;

                ObservableCollection<UserRestaurant> allRestaurant = new ObservableCollection<UserRestaurant>();

                ListUserRestaurants = a.ToObject<List<UserRestaurant>>();

                foreach (var pair in ListUserRestaurants)
                    allRestaurant.Add(new UserRestaurant
                        (pair.RestaurantId, pair.Name, pair.Address, pair.City, pair.State, pair.Phone, pair.Hours));

                AllRestaurantListBox.DataContext = allRestaurant;


                StatusBorder.Background = new SolidColorBrush(Colors.Green);
                StatusTextBlock.Text = "Request completed!";

                // Verify that a result was returned
                if (resultJson.HasValues)
                {
                    Subscription.Visibility = Visibility.Visible;
                    LoadAll.Visibility = Visibility.Collapsed;
                }
                else
                {
                    StatusBorder.Background = new SolidColorBrush(Colors.Orange);
                    StatusTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                }


            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
                StatusBorder.Background = new SolidColorBrush(Colors.Red);
            }
            finally
            {
                // Let the user know something happening
                progressBar.IsIndeterminate = false;
            }
        }
    }
}
