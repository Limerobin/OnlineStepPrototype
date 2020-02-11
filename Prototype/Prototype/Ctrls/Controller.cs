using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Prototype.Models;
using Newtonsoft.Json;
using Prototype.Views;

namespace Prototype.Ctrls
{
    class Controller
    {
        private const string url = "https://online-step.herokuapp.com/courses/";
        private RestClient.RestClient_Alpha RestClient;
        private StackLayout MyLayout;
        private List<Course> Courses;
        private List<Chapter> Chapters;
        private List<Content.RootObject> Contents;
        

        public Controller(StackLayout layout)
        {
            this.MyLayout = layout;
        }

        public void ShowCourses()
        {
            RestClient = new RestClient.RestClient_Alpha { EndPoint = url };
            string Response = RestClient.DoRequest();
            Console.WriteLine(Response.ToString());
            Courses = JsonConvert.DeserializeObject<List<Course>>(Response);
            foreach(var i in Courses)
            {
                Button btn = new Button { Text = i.Name };
                MyLayout.Children.Add(btn);
                btn.Clicked += CourseBtnAction;
            }
        }

        private void CourseBtnAction(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = string.Empty;                
            foreach(var i in Courses)
            {
                if (i.Name.Equals(btn.Text))
                {
                    id = i._id;
                    break;
                }
            }
            Console.WriteLine(id);
            MyLayout.Navigation.PushModalAsync(new ChapterPage(id));
        }

        public void ShowChapters(string ChapterId)
        {
            string ChapterURL = "https://online-step.herokuapp.com/courses/chapters/"+ChapterId+"";
            RestClient = new RestClient.RestClient_Alpha { EndPoint = ChapterURL };
            string Response = RestClient.DoRequest();
            Console.WriteLine(Response.ToString());
            Chapters = JsonConvert.DeserializeObject<List<Chapter>>(Response);
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
            foreach(var i in Chapters)
            {
                if (i.Name.Equals(btn.Text))
                {
                    id = i._id;
                    break;
                }
            }
            Console.WriteLine(id);
            MyLayout.Navigation.PushModalAsync(new ContView(id));
        }

        public void ShowContent(string id)
        {
            string ContentURL = "https://online-step.herokuapp.com/chapters/pages/" + id + "";
            RestClient = new RestClient.RestClient_Alpha { EndPoint = ContentURL };
            string Response = RestClient.DoRequest();
            Console.WriteLine(Response.ToString());
            Contents = JsonConvert.DeserializeObject<List<Content.RootObject>>(Response);
            ContentController controller = new ContentController(MyLayout, Contents);
            controller.DisplayEachPage();
        }
    }
}
