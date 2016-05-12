using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Rest;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using RestaurantClient.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WaitTimePage : Page
    {
        public WaitTimePage()
        {
            this.InitializeComponent();
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

        private async void CallAPISumbitWaitTimeButton_Click(object sender, RoutedEventArgs e)
        {
            //new REST API Client  object
            RestaurantWaitTime clientSdk = new RestaurantWaitTime();
            DateTime dateTime;
            string date = DateTime.Parse(valueDate.Date.ToString()).ToString("MM/dd/yyyy");
            string time = DateTime.Parse(valueTime.Time.ToString()).ToString("h:mm tt");
            //combine date and time from datepicker and timepicker
            var dateTimeString = date + " " + time;
            dateTime = DateTime.Parse(dateTimeString);

            try
            {
                // Make the call asynchronously using GET verb
                var resultJson =
                    await App.MobileServiceDotNet.InvokeApiAsync("GetCurrentRestaurant", HttpMethod.Get, null);
                string restaurantId = resultJson.Value<string>("restaurantId");

                //party of 2
                if (!string.IsNullOrWhiteSpace(party2?.Text))
                {
                    WaitTime waittime = new WaitTime()
                    {
                        RestaurantId = restaurantId,
                        GroupNumber = 2,
                        WaitDateTime = dateTime,
                        Wait = int.Parse(party2.Text),
                    };
                    try
                    {
                        Task<HttpOperationResponse<WaitTime>> resultTask =
                            clientSdk.WaitTimes.PostWaitTimeByItemWithOperationResponseAsync(waittime);
                        resultTask.Wait();
                        // Wait until task completes
                            try
                            {
                                resultTask.Wait();
                            }
                            catch (AggregateException ex)
                            {
                                StatusTextBlock.Text = ex.Message;
                                StatusBorder.Background = new SolidColorBrush(Colors.Red);
                            }
                            StatusBorder.Background = new SolidColorBrush(Colors.Green);
                            StatusTextBlock.Text = "Request completed!";
                        progressBar.IsIndeterminate = false;
                    }
                    catch (HttpOperationException ex)
                    {
                        // Display the exception message
                        StatusTextBlock.Text = ex.Message;
                        StatusBorder.Background = new SolidColorBrush(Colors.Red);
                    }
                    finally
                    {
                        progressBar.IsIndeterminate = false;
                    }
                }

                //party of 4
                if (!string.IsNullOrWhiteSpace(party4?.Text))
                {
                    WaitTime waittime = new WaitTime()
                    {
                        RestaurantId = restaurantId,
                        GroupNumber = 4,
                        WaitDateTime = dateTime,
                        Wait = int.Parse(party4.Text),
                    };
                    try
                    {
                        Task<HttpOperationResponse<WaitTime>> resultTask =
                            clientSdk.WaitTimes.PostWaitTimeByItemWithOperationResponseAsync(waittime);
                        resultTask.Wait();
                        // Wait until task completes
                        try
                        {
                            resultTask.Wait();
                        }
                        catch (AggregateException ex)
                        {
                            StatusTextBlock.Text = ex.Message;
                            StatusBorder.Background = new SolidColorBrush(Colors.Red);
                        }
                        StatusBorder.Background = new SolidColorBrush(Colors.Green);
                        StatusTextBlock.Text = "Request completed!";
                        progressBar.IsIndeterminate = false;
                    }
                    catch (HttpOperationException ex)
                    {
                        // Display the exception message
                        StatusTextBlock.Text = ex.Message;
                        StatusBorder.Background = new SolidColorBrush(Colors.Red);
                    }
                    finally
                    {
                        progressBar.IsIndeterminate = false;
                    }
                }

                //party of 6
                if (!string.IsNullOrWhiteSpace(party6?.Text))
                {
                    WaitTime waittime = new WaitTime()
                    {
                        RestaurantId = restaurantId,
                        GroupNumber = 6,
                        WaitDateTime = dateTime,
                        Wait = int.Parse(party6.Text),
                    };
                    try
                    {
                        Task<HttpOperationResponse<WaitTime>> resultTask =
                            clientSdk.WaitTimes.PostWaitTimeByItemWithOperationResponseAsync(waittime);
                        resultTask.Wait();
                        // Wait until task completes
                        try
                        {
                            resultTask.Wait();
                        }
                        catch (AggregateException ex)
                        {
                            StatusTextBlock.Text = ex.Message;
                            StatusBorder.Background = new SolidColorBrush(Colors.Red);
                        }
                        StatusBorder.Background = new SolidColorBrush(Colors.Green);
                        StatusTextBlock.Text = "Request completed!";
                        progressBar.IsIndeterminate = false;
                    }
                    catch (HttpOperationException ex)
                    {
                        // Display the exception message
                        StatusTextBlock.Text = ex.Message;
                        StatusBorder.Background = new SolidColorBrush(Colors.Red);
                    }
                    finally
                    {
                        progressBar.IsIndeterminate = false;
                    }
                }

                //party 6 plus
                if (!string.IsNullOrWhiteSpace(party6Plus?.Text))
                {
                    WaitTime waittime = new WaitTime()
                    {
                        RestaurantId = restaurantId,
                        GroupNumber = 99,
                        WaitDateTime = dateTime,
                        Wait = int.Parse(party6Plus.Text),
                    };
                    try
                    {
                        Task<HttpOperationResponse<WaitTime>> resultTask =
                            clientSdk.WaitTimes.PostWaitTimeByItemWithOperationResponseAsync(waittime);
                        resultTask.Wait();
                        // Wait until task completes
                        try
                        {
                            resultTask.Wait();
                        }
                        catch (AggregateException ex)
                        {
                            StatusTextBlock.Text = ex.Message;
                            StatusBorder.Background = new SolidColorBrush(Colors.Red);
                        }
                        StatusBorder.Background = new SolidColorBrush(Colors.Green);
                        StatusTextBlock.Text = "Request completed!";
                        progressBar.IsIndeterminate = false;
                    }
                    catch (HttpOperationException ex)
                    {
                        // Display the exception message
                        StatusTextBlock.Text = ex.Message;
                        StatusBorder.Background = new SolidColorBrush(Colors.Red);
                    }
                    finally
                    {
                        progressBar.IsIndeterminate = false;
                    }
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
    }
}
