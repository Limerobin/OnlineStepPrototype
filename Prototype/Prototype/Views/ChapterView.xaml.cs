using System;
using System.Collections.Generic;
using Prototype.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.Models;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterView : ContentPage
    {

        private readonly NavigationController Controller;
        private List<Chapter> Chapters;

        public ChapterView(List<Chapter> chapterList)
        {
            InitializeComponent();
            this.Chapters = chapterList;
            Controller = new NavigationController();
            ShowChapters();
        }

        public void ShowChapters()
        {
            foreach (var i in Chapters)
            {
                Button btn = new Button { Text = i.Name };
                ChapterPageLayout.Children.Add(btn);
                btn.Clicked += ChapterBtnAction;
            }
        }

        public void ChapterBtnAction(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = string.Empty;
            foreach (var i in Chapters)
            {
                if (i.Name.Equals(btn.Text))
                {
                    id = i._id;
                    break;
                }
            }
            Controller.ShowPageContent(btn, id);
        }
    }
}