﻿using Acr.UserDialogs;
using App2.AdMob;
using App2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Historisch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GluecksspiraleHistorischPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public GluecksspiraleHistorischPage()
        {
            InitializeComponent();

            Device.BeginInvokeOnMainThread(() =>
            {
                GlobalVariable.count++;
                if (GlobalVariable.count == 4)
                {
                    GlobalVariable.count = 0;

                    adInterstitial = DependencyService.Get<IAdInterstitial>();

                    adInterstitial.ShowAd();
                }

                callAPI();
            });
        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Bitte warten ...", MaskType.Black);
            try
            {
                var gluecksspirales = new List<Gluecksspirale>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://achrafchikoun.com/deutsch/Api/getAllgluecksspirale");
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
                        string n8 = output.ElementAt(i)["n8"].ToString();
                        string n9 = output.ElementAt(i)["n9"].ToString();
                        string n10 = output.ElementAt(i)["n10"].ToString();
                        string n11 = output.ElementAt(i)["n11"].ToString();
                        string n12 = output.ElementAt(i)["n12"].ToString();
                        string n13 = output.ElementAt(i)["n13"].ToString();
                        string n14 = output.ElementAt(i)["n14"].ToString();
                        string spiel = output.ElementAt(i)["spiel77"].ToString();
                        string super = output.ElementAt(i)["super6"].ToString();
                        string tirage_du = output.ElementAt(i)["tirage_du"].ToString();
                        gluecksspirales.Add(new Gluecksspirale { n1 = n1, n2 = n2, n3 = n3, n4 = n4, n5 = n5, n6 = n6, n7 = n7, n8 = n8, n9 = n9, n10 = n10, n11 = n11, n12 = n12, n13 = n13, n14 = n14, spiel = spiel, super = super, tirage_du = tirage_du });

                    }
                    listView.ItemsSource = gluecksspirales;

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
