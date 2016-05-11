using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Microsoft.Rest;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using RestaurantClient.Common;
using RestaurantClient.Models;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RestaurantClient
{
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

        public MainPage()
        {
            this.InitializeComponent();
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

        private async void RestaurantDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatusTextBlock.Text = "GET Request Made, waiting for response...";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.White);
                StatusBorder.Background = new SolidColorBrush(Colors.Blue);
                // Let the user know something happening
                progressBar.IsIndeterminate = true;
                
                // Make the call asynchronously using GET verb
                var resultJson = await App.MobileServiceDotNet.InvokeApiAsync("GetCurrentRestaurant", HttpMethod.Get, null);

                var restaurantId = resultJson.Value<string>("restaurantId");

                //new REST API Client  object
                RestaurantWaitTime clientSdk = new RestaurantWaitTime();

                Task<HttpOperationResponse<Restaurant>> resultTask =
                    clientSdk.Restaurants.GetRestaurantByRestaurantidWithOperationResponseAsync(restaurantId);
                resultTask.Wait();
                if (resultTask.Result.Response.IsSuccessStatusCode)
                {
                    var myRestaurant = new Restaurant()
                    {
                        Name = resultTask.Result.Body.Name,
                        Address = resultTask.Result.Body.Address,
                        City = resultTask.Result.Body.City,
                        State = resultTask.Result.Body.State,
                        Zip = resultTask.Result.Body.Zip,
                        Phone = resultTask.Result.Body.Phone,
                        WebSite = resultTask.Result.Body.WebSite,
                        Email = resultTask.Result.Body.Email,
                        Hours = resultTask.Result.Body.Hours,
                        Cuisine = resultTask.Result.Body.Cuisine,
                        Capacity = resultTask.Result.Body.Capacity,
                        PropertyID = resultTask.Result.Body.PropertyID,
                        Location = resultTask.Result.Body.Location
                    };
                    Restaurant.DataContext = myRestaurant;
                }
            }

            catch (MobileServiceInvalidOperationException ex)
            {
                // Display the exception message for the demo

                string responseMsg = await ex.Response.Content.ReadAsStringAsync();

                JObject o = JObject.Parse(responseMsg);
                string messageResult = o.Value<string>("message");
                //OutTextBlock.Text = "";
                StatusTextBlock.Text = ex.Message;
                StatusBorder.Background = new SolidColorBrush(Colors.Red);

            }
            finally
            {
                // Let the user know something happening
                progressBar.IsIndeterminate = false;
            }
        }

        private void WaitTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
