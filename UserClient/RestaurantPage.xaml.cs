using System;
using System.Collections.Generic;
using System.Net.Http;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UserClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RestaurantPage : Page
    {
        public RestaurantPage()
        {
            InitializeComponent();
        }

        private async void LoadCurrentRestaurantWaitTime(string id)
        {

            try
            {
                StatusTextBlock.Text = "GET Request Made, waiting for response...";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.White);
                StatusBorder.Background = new SolidColorBrush(Colors.Blue);
                // Let the user know something happening
                progressBar.IsIndeterminate = true;

                var arg2 = new Dictionary<string, string>
                {
                    {"id", id},
                    {"group", "2"}
                };

                var resultJson =
                    await
                        App.MobileServiceDotNet.InvokeApiAsync(
                            "GetLatestRestaurantWaitTimeByGroup/" + (App.Current as App).CurrentRestaurantId + "/" + 2,
                            HttpMethod.Get, arg2);
                party2.DataContext = resultJson.Value<string>("Wait") + " mintues";
                date2.DataContext = resultJson.Value<string>("WaitDateTime");

                var arg4 = new Dictionary<string, string>
                {
                    {"id", id},
                    {"group", "4"}
                };

                resultJson =
                    await
                        App.MobileServiceDotNet.InvokeApiAsync(
                            "GetLatestRestaurantWaitTimeByGroup/" + (App.Current as App).CurrentRestaurantId + "/" + 4,
                            HttpMethod.Get, arg4);
                party4.DataContext = resultJson.Value<string>("Wait") + " mintues";
                date4.DataContext = resultJson.Value<string>("WaitDateTime");

                var arg6 = new Dictionary<string, string>
                {
                    {"id", id},
                    {"group", "6"}
                };

                resultJson =
                    await
                        App.MobileServiceDotNet.InvokeApiAsync(
                            "GetLatestRestaurantWaitTimeByGroup/" + (App.Current as App).CurrentRestaurantId + "/" + 6,
                            HttpMethod.Get, arg6);
                party6.DataContext = resultJson.Value<string>("Wait") + " mintues";
                date2.DataContext = resultJson.Value<string>("WaitDateTime");

                var arg99 = new Dictionary<string, string>
                {
                    {"id", id},
                    {"group", "99"}
                };
                resultJson =
                    await
                        App.MobileServiceDotNet.InvokeApiAsync(
                            "GetLatestRestaurantWaitTimeByGroup/" + (App.Current as App).CurrentRestaurantId + "/" + 99,
                            HttpMethod.Get, arg99);
                party99.DataContext = resultJson.Value<string>("Wait") + " mintues";
                date99.DataContext = resultJson.Value<string>("WaitDateTime");

                StatusBorder.Background = new SolidColorBrush(Colors.Green);
                StatusTextBlock.Text = "Request completed!";
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

        /// <summary>
        /// going back to main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackMain_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                PassToPage s = (PassToPage)e.Parameter;
                (App.Current as App).CurrentRestaurantId = s.id;
                (App.Current as App).CurrentRestaurantName = s.name;
                RestaurantPageTitle.DataContext = (App.Current as App).CurrentRestaurantName;
                LoadCurrentRestaurantWaitTime((App.Current as App).CurrentRestaurantId);
            }
        }
    }
}
