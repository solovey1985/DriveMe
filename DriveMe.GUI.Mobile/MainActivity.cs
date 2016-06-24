﻿using System;
using Android.App;
using Android.Content;
using Android.Hardware;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;

namespace DriveMe.GUI.Mobile
{
    [Activity(Label = "DriveMe.GUI.Mobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            var geoUri = Android.Net.Uri.Parse("geo:42.374260,-71.120824");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);

        }
    }
}

