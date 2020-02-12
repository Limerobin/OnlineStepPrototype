﻿using Prototype.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new CourseView();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
