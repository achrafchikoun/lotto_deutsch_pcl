﻿using App2.AdMob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KenoPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public KenoPage()
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
            });
        }
    }
}
