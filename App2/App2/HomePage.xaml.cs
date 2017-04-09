using Acr.UserDialogs;
using App2.AdMob;
using App2.Detail;
using App2.Historisch;
using Newtonsoft.Json;
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
                    lotto_n1.Text = lotto_deutsh[0]["n1"];
                    lotto_n2.Text = lotto_deutsh[0]["n2"];
                    lotto_n3.Text = lotto_deutsh[0]["n3"];
                    lotto_n4.Text = lotto_deutsh[0]["n4"];
                    lotto_n5.Text = lotto_deutsh[0]["n5"];
                    lotto_n6.Text = lotto_deutsh[0]["n6"];
                    lotto_n7.Text = lotto_deutsh[0]["n7"];
                    lotto_spiel.Text = lotto_deutsh[0]["spiel77"];
                    lotto_super.Text = lotto_deutsh[0]["super6"];
                    lotto_tirage_du.Text = lotto_deutsh[0]["tirage_du"];
                    lotto_prochain_tirage.Text = lotto_deutsh[0]["prochain_tirage"];

                    //eurojackpot_deutsh
                    dynamic eurojackpot_deutsh = output["eurojackpot_deutsh"];
                    eurojackpot_n1.Text = eurojackpot_deutsh[0]["n1"];
                    eurojackpot_n2.Text = eurojackpot_deutsh[0]["n2"];
                    eurojackpot_n3.Text = eurojackpot_deutsh[0]["n3"];
                    eurojackpot_n4.Text = eurojackpot_deutsh[0]["n4"];
                    eurojackpot_n5.Text = eurojackpot_deutsh[0]["n5"];
                    eurojackpot_n6.Text = eurojackpot_deutsh[0]["n6"];
                    eurojackpot_n7.Text = eurojackpot_deutsh[0]["n7"];
                    eurojackpot_n8.Text = eurojackpot_deutsh[0]["n8"];
                    eurojackpot_n9.Text = eurojackpot_deutsh[0]["n9"];
                    eurojackpot_prochain_tirage.Text = eurojackpot_deutsh[0]["date_limite"];

                    //gluecksspirale_deutsh
                    dynamic gluecksspirale_deutsh = output["gluecksspirale_deutsh"];
                    gluecksspirale_n1.Text = gluecksspirale_deutsh[0]["n1"];
                    gluecksspirale_n2.Text = gluecksspirale_deutsh[0]["n2"];
                    gluecksspirale_n3.Text = gluecksspirale_deutsh[0]["n3"];
                    gluecksspirale_n4.Text = gluecksspirale_deutsh[0]["n4"];
                    gluecksspirale_n5.Text = gluecksspirale_deutsh[0]["n5"];
                    gluecksspirale_n6.Text = gluecksspirale_deutsh[0]["n6"];
                    gluecksspirale_n7.Text = gluecksspirale_deutsh[0]["n7"];
                    gluecksspirale_n8.Text = gluecksspirale_deutsh[0]["n8"];
                    gluecksspirale_n9.Text = gluecksspirale_deutsh[0]["n9"];
                    gluecksspirale_n10.Text = gluecksspirale_deutsh[0]["n10"];
                    gluecksspirale_n11.Text = gluecksspirale_deutsh[0]["n11"];
                    gluecksspirale_n12.Text = gluecksspirale_deutsh[0]["n12"];
                    gluecksspirale_n13.Text = gluecksspirale_deutsh[0]["n13"];
                    gluecksspirale_n14.Text = gluecksspirale_deutsh[0]["n14"];
                    gluecksspirale_spiel.Text = gluecksspirale_deutsh[0]["spiel77"];
                    gluecksspirale_super.Text = gluecksspirale_deutsh[0]["super6"];
                    gluecksspirale_prochain_tirage.Text = gluecksspirale_deutsh[0]["prochain_tirage"];

                    //keno_deutsh
                    dynamic keno_deutsh = output["keno_deutsh"];
                    keno_n1.Text = keno_deutsh[0]["n1"];
                    keno_n2.Text = keno_deutsh[0]["n2"];
                    keno_n3.Text = keno_deutsh[0]["n3"];
                    keno_n4.Text = keno_deutsh[0]["n4"];
                    keno_n5.Text = keno_deutsh[0]["n5"];
                    keno_n6.Text = keno_deutsh[0]["n6"];
                    keno_n7.Text = keno_deutsh[0]["n7"];
                    keno_n8.Text = keno_deutsh[0]["n8"];
                    keno_n9.Text = keno_deutsh[0]["n9"];
                    keno_n10.Text = keno_deutsh[0]["n10"];
                    keno_n11.Text = keno_deutsh[0]["n11"];
                    keno_n12.Text = keno_deutsh[0]["n12"];
                    keno_n13.Text = keno_deutsh[0]["n13"];
                    keno_n14.Text = keno_deutsh[0]["n14"];
                    keno_n15.Text = keno_deutsh[0]["n15"];
                    keno_n16.Text = keno_deutsh[0]["n16"];
                    keno_n17.Text = keno_deutsh[0]["n17"];
                    keno_n18.Text = keno_deutsh[0]["n18"];
                    keno_n19.Text = keno_deutsh[0]["n19"];
                    keno_n20.Text = keno_deutsh[0]["n20"];
                    keno_plus5.Text = keno_deutsh[0]["plus5"];
                    keno_prochain_tirage.Text = keno_deutsh[0]["prochain_tirage"];

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

        }
    }
}
