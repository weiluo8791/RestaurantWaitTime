using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using RestaurantClient.Common;


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
                
                // Make the call to the hello resource asynchronously using GET verb
                var resultJson = await App.MobileServiceDotNet.InvokeApiAsync("GetAllRestaurantUsers", HttpMethod.Get, null);

//                string id = resultJson.Value<string>("id");
//                string name = resultJson.Value<string>("name");
//                string pictureurl = resultJson.Value<string>("pictureUrl");
//                string gender = resultJson.Value<string>("gender");
//                int voteBalance = resultJson.Value<int>("voteBalance");
//                string role = resultJson.Value<string>("role");
//                string registrationStatus = resultJson.Value<string>("registrationStatus");

//                var myProfile = new Registration(id, name, pictureurl, gender, voteBalance, role, registrationStatus);
//                Profile.DataContext = myProfile;

                StatusBorder.Background = new SolidColorBrush(Colors.Green);
                StatusTextBlock.Text = "Request completed!";

                // Verfiy that a result was returned
                if (resultJson.HasValues)
                {
                    // Extract the value from the result
                    //string messageResult = resultJson.Value<string>("message");
                    var messageResult = resultJson.ToString();
                    FeatureGrid.Visibility = Visibility.Collapsed;
                    Profile.Visibility = Visibility.Visible;
                    // Set the text block with the result
                    //OutTextBlock.Text = messageResult;
                }
                else
                {
                    StatusBorder.Background = new SolidColorBrush(Colors.Orange);
                    StatusTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                    //OutTextBlock.Text = "Nothing returned!";
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
