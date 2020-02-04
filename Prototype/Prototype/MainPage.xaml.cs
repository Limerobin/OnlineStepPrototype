﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prototype
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void QuizProcedure(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Views.QuizPage());
        }

        private void DragnDropProcedure(object sender, EventArgs e)
        {

        }

        private void ClozeTestProcedure(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Views.ClozeTestPage());
        }
    }
}