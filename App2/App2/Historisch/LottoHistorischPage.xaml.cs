using Acr.UserDialogs;
using App2.AdMob;
using App2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Historisch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LottoHistorischPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public LottoHistorischPage()
        {
            InitializeComponent();

            GlobalVariable.count++;
            if (GlobalVariable.count == 4)
            {
                GlobalVariable.count = 0;

                adInterstitial = DependencyService.Get<IAdInterstitial>();

                adInterstitial.ShowAd();
            }

            callAPI();
        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Bitte warten ...", MaskType.Black);
            try
            {
                var lottos = new List<Lotto>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://achrafchikoun.com/deutsch/Api/getAllLotto");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonConvert.DeserializeObject(content);
                    JArray output = JArray.Parse(responseJson.ToString());

                    for (int i = 0; i < output.Count; i++)
                    {
                        string n1 = output.ElementAt(i)["n1"].ToString();
                        string n2 = output.ElementAt(i)["n2"].ToString();
                        string n3 = output.ElementAt(i)["n3"].ToString();
                        string n4 = output.ElementAt(i)["n4"].ToString();
                        string n5 = output.ElementAt(i)["n5"].ToString();
                        string n6 = output.ElementAt(i)["n6"].ToString();
                        string n7 = output.ElementAt(i)["n7"].ToString();
                        string spiel = output.ElementAt(i)["spiel77"].ToString();
                        string super = output.ElementAt(i)["super6"].ToString();
                        string tirage_du = output.ElementAt(i)["tirage_du"].ToString();
                        lottos.Add(new Lotto { N_1 = n1, N_2 = n2, N_3 = n3, N_4 = n4, N_5 = n5, N_6 = n6, N_7 = n7, N_spiel = spiel, N_super = super, tirage_du = tirage_du });
                        
                    }
                    listView.ItemsSource = lottos;

                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Fehler", "Ein Fehler ist aufgetreten, bitte versuchen Sie es später noch einmal", "OK");
                //Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
}
