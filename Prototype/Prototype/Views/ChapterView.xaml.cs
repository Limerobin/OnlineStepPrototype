using System;
using Prototype.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterView : ContentPage
    {
        public ChapterView(String id)
        {
            InitializeComponent();
            Navigation navigation = new Navigation(ChapterPageLayout);
            navigation.ShowChapters(id);
        }
      
    }
}