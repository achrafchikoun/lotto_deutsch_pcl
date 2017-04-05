using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Alert", "You have been alerted", "OK");
            await callAPI();
        }

        private async Task callAPI()
        {
            try
            {
                Debug.WriteLine("debut callAPI");
                HttpClient client = new HttpClient();
                var uri = new Uri("http://www.mobixapp.com/loto_usa_api/Api/getLastTexas");
                var response = await client.GetAsync(uri);
                Debug.WriteLine("code : " + response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
}
