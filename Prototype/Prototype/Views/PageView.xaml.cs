﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Ctrls;
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
            Controller controller = new Controller(PageViewLayout);
            controller.ShowPageContent(id);

        }
    }
}