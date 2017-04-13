using Acr.UserDialogs;
using App2.AdMob;
using App2.Detail;
using App2.Historisch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public HomePage()
        {
            InitializeComponent();

            GlobalVariable.count++;

            adInterstitial = DependencyService.Get<IAdInterstitial>();

            adInterstitial.ShowAd();

            callAPI();

        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Bitte warten ...", MaskType.Black);
            try
            {
                HttpClient client = new HttpClient();
                var uri = new Uri("http://achrafchikoun.com/deutsch/api/getLastDeutsch");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //lotto_deutsh
                    dynamic lotto_deutsh = output["lotto_deutsh"];
                    lotto_n1.Text = lotto_deutsh[0]["n1"].Value;
                    lotto_n2.Text = lotto_deutsh[0]["n2"].Value;
                    lotto_n3.Text = lotto_deutsh[0]["n3"].Value;
                    lotto_n4.Text = lotto_deutsh[0]["n4"].Value;
                    lotto_n5.Text = lotto_deutsh[0]["n5"].Value;
                    lotto_n6.Text = lotto_deutsh[0]["n6"].Value;
                    lotto_n7.Text = lotto_deutsh[0]["n7"].Value;
                    lotto_spiel.Text = lotto_deutsh[0]["spiel77"].Value;
                    lotto_super.Text = lotto_deutsh[0]["super6"].Value;
                    lotto_tirage_du.Text = lotto_deutsh[0]["tirage_du"].Value;
                    lotto_prochain_tirage.Text = lotto_deutsh[0]["prochain_tirage"].Value;

                    //eurojackpot_deutsh
                    dynamic eurojackpot_deutsh = output["eurojackpot_deutsh"];
                    eurojackpot_n1.Text = eurojackpot_deutsh[0]["n1"].Value;
                    eurojackpot_n2.Text = eurojackpot_deutsh[0]["n2"].Value;
                    eurojackpot_n3.Text = eurojackpot_deutsh[0]["n3"].Value;
                    eurojackpot_n4.Text = eurojackpot_deutsh[0]["n4"].Value;
                    eurojackpot_n5.Text = eurojackpot_deutsh[0]["n5"].Value;
                    eurojackpot_n6.Text = eurojackpot_deutsh[0]["n6"].Value;
                    eurojackpot_n7.Text = eurojackpot_deutsh[0]["n7"].Value;
                    eurojackpot_n8.Text = eurojackpot_deutsh[0]["n8"].Value;
                    eurojackpot_n9.Text = eurojackpot_deutsh[0]["n9"].Value;
                    eurojackpot_prochain_tirage.Text = eurojackpot_deutsh[0]["date_limite"].Value;

                    //gluecksspirale_deutsh
                    dynamic gluecksspirale_deutsh = output["gluecksspirale_deutsh"];
                    gluecksspirale_n1.Text = gluecksspirale_deutsh[0]["n1"].Value;
                    gluecksspirale_n2.Text = gluecksspirale_deutsh[0]["n2"].Value;
                    gluecksspirale_n3.Text = gluecksspirale_deutsh[0]["n3"].Value;
                    gluecksspirale_n4.Text = gluecksspirale_deutsh[0]["n4"].Value;
                    gluecksspirale_n5.Text = gluecksspirale_deutsh[0]["n5"].Value;
                    gluecksspirale_n6.Text = gluecksspirale_deutsh[0]["n6"].Value;
                    gluecksspirale_n7.Text = gluecksspirale_deutsh[0]["n7"].Value;
                    gluecksspirale_n8.Text = gluecksspirale_deutsh[0]["n8"].Value;
                    gluecksspirale_n9.Text = gluecksspirale_deutsh[0]["n9"].Value;
                    gluecksspirale_n10.Text = gluecksspirale_deutsh[0]["n10"].Value;
                    gluecksspirale_n11.Text = gluecksspirale_deutsh[0]["n11"].Value;
                    gluecksspirale_n12.Text = gluecksspirale_deutsh[0]["n12"].Value;
                    gluecksspirale_n13.Text = gluecksspirale_deutsh[0]["n13"].Value;
                    gluecksspirale_n14.Text = gluecksspirale_deutsh[0]["n14"].Value;
                    gluecksspirale_spiel.Text = gluecksspirale_deutsh[0]["spiel77"].Value;
                    gluecksspirale_super.Text = gluecksspirale_deutsh[0]["super6"].Value;
                    gluecksspirale_prochain_tirage.Text = gluecksspirale_deutsh[0]["prochain_tirage"].Value;

                    //keno_deutsh
                    dynamic keno_deutsh = output["keno_deutsh"];
                    keno_n1.Text = keno_deutsh[0]["n1"].Value;
                    keno_n2.Text = keno_deutsh[0]["n2"].Value;
                    keno_n3.Text = keno_deutsh[0]["n3"].Value;
                    keno_n4.Text = keno_deutsh[0]["n4"].Value;
                    keno_n5.Text = keno_deutsh[0]["n5"].Value;
                    keno_n6.Text = keno_deutsh[0]["n6"].Value;
                    keno_n7.Text = keno_deutsh[0]["n7"].Value;
                    keno_n8.Text = keno_deutsh[0]["n8"].Value;
                    keno_n9.Text = keno_deutsh[0]["n9"].Value;
                    keno_n10.Text = keno_deutsh[0]["n10"].Value;
                    keno_n11.Text = keno_deutsh[0]["n11"].Value;
                    keno_n12.Text = keno_deutsh[0]["n12"].Value;
                    keno_n13.Text = keno_deutsh[0]["n13"].Value;
                    keno_n14.Text = keno_deutsh[0]["n14"].Value;
                    keno_n15.Text = keno_deutsh[0]["n15"].Value;
                    keno_n16.Text = keno_deutsh[0]["n16"].Value;
                    keno_n17.Text = keno_deutsh[0]["n17"].Value;
                    keno_n18.Text = keno_deutsh[0]["n18"].Value;
                    keno_n19.Text = keno_deutsh[0]["n19"].Value;
                    keno_n20.Text = keno_deutsh[0]["n20"].Value;
                    keno_plus5.Text = keno_deutsh[0]["plus5"].Value;
                    keno_prochain_tirage.Text = keno_deutsh[0]["prochain_tirage"].Value;

                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Fehler", ex.Message.ToString(), "OK");
                //Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        private void btnLottoDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Warnung", "Bitte verbinden Sie mit dem Internet und versuchen Sie es erneut.", "OK");
                return;
            }
            Navigation.PushAsync(new LottoDetailPage());
        }

        private void btnLottoHistorisch_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Warnung", "Bitte verbinden Sie mit dem Internet und versuchen Sie es erneut.", "OK");
                return;
            }
            Navigation.PushAsync(new LottoHistorischPage());
        }

        private void btnEurojackpotDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Warnung", "Bitte verbinden Sie mit dem Internet und versuchen Sie es erneut.", "OK");
                return;
            }
            Navigation.PushAsync(new EurojackpotPage());
        }

        private void btnEurojackpotHistorisch_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Warnung", "Bitte verbinden Sie mit dem Internet und versuchen Sie es erneut.", "OK");
                return;
            }
            Navigation.PushAsync(new EurojackpotHistorischPage());
        }

        private void btnGluecksspiraleDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Warnung", "Bitte verbinden Sie mit dem Internet und versuchen Sie es erneut.", "OK");
                return;
            }
            Navigation.PushAsync(new GluecksspiralePage());
        }

        private void btnGluecksspiraleHistorisch_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Warnung", "Bitte verbinden Sie mit dem Internet und versuchen Sie es erneut.", "OK");
                return;
            }
            Navigation.PushAsync(new GluecksspiraleHistorischPage());
        }

        private void btnKenoDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Warnung", "Bitte verbinden Sie mit dem Internet und versuchen Sie es erneut.", "OK");
                return;
            }
            Navigation.PushAsync(new KenoPage());
        }

        private void btnKenoHistorisch_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Warnung", "Bitte verbinden Sie mit dem Internet und versuchen Sie es erneut.", "OK");
                return;
            }
            Navigation.PushAsync(new KenoHistorischPage());
        }
    }
}
