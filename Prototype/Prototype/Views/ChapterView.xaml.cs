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
        }

        public void ShowChapters(string ChapterId)
        {
            string URL = "https://online-step.herokuapp.com/courses/chapters/" + ChapterId + "";
            Chapters = JsonConvert.DeserializeObject<List<Chapter>>(GetJSON(URL));
            foreach (var i in Chapters)
            {
                Button btn = new Button { Text = i.Name };
                MyLayout.Children.Add(btn);
                btn.Clicked += ChapterBtnAction;
            }
        }

        private void ChapterBtnAction(object sender, EventArgs e)
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
            Console.WriteLine(id);
            MyLayout.Navigation.PushModalAsync(new PageView(id));
        }

    }
}