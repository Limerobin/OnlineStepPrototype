﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageView : ContentPage
    {
        public PageView(string id)
        {
            InitializeComponent();
            //NavigationController navigation = new NavigationController(PageViewLayout);
            //navigation.ShowPageContent(id);

        }
    }
}