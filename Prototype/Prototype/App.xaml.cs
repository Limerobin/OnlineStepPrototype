using Prototype.Views;
using System;
using System.Collections.Generic;
using Prototype.Controllers;
using Prototype.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    public partial class App : Application
    {
        public App()
        {
            NavigationController controller = new NavigationController();
            controller.GetCourses();
            MainPage = controller.InitialApp();
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
