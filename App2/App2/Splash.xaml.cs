using AdvancedTimer.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Splash : ContentPage
    {
        IAdvancedTimer timer;
        public Splash()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            timer = DependencyService.Get<IAdvancedTimer>();
            timer.initTimer(3000, timerElapsed, true);
            timer.startTimer();

            /*Task startupWork = new Task(() =>
            {
                Task.Delay(2000);
            });

            startupWork.ContinueWith(t =>
            {
                Navigation.PushAsync(new MainPage());
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();*/


        }

        private void timerElapsed(object sender, EventArgs e)
        {
            timer.stopTimer();
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new HomePage())
                    {
                        BarBackgroundColor = Color.FromHex("#e3bd00"),
                        BarTextColor = Color.White,
                    };
                    Navigation.PushAsync(new HomePage());
                });
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
}
