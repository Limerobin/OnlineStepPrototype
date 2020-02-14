using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Prototype.Models;
using Prototype.Views;
using Xamarin.Forms;

namespace Prototype.Controllers
{
    class NavigationController
    {
        private StackLayout MyLayout;
        private CourseRepository CourseRepository;
        private List<Chapter> Chapters;
        private List<Content.RootObject> Contents;
        

        public NavigationController()
        {
            
        }


        public CourseView InitialApp()
        {
           // GetCourses();
            CourseView courseView = new CourseView(CourseRepository.CourseList);
            return courseView;
        }

        public void GetCourses()
        {
            CourseRepository = new CourseRepository();
            string URL = "https://online-step.herokuapp.com/courses/";
            CourseRepository.CourseList = JsonConvert.DeserializeObject<List<Course>>(GetJSON(URL));
        }


        //helper method
        public void ShowChapters()
        {
            string URL = "https://online-step.herokuapp.com/courses/chapters/"+ChapterId+"";
            Chapters = JsonConvert.DeserializeObject<List<Chapter>>(GetJSON(URL));
            
        }

        public void CourseBtnAction(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            string id = string.Empty;
            foreach (var i in Courses)
            {
                if (i.Name.Equals(btn.Text))
                {
                    id = i._id;
                    break;
                }
            }

            string URL = "https://online-step.herokuapp.com/courses/chapters/" + id + "";
            Chapters = JsonConvert.DeserializeObject<List<Chapter>>(GetJSON(URL));
            ChapterModel chapterModel = new ChapterModel(id);
            
            
        }

        public void ShowPageContent(string id)
        {
            string URL = "https://online-step.herokuapp.com/chapters/pages/" + id + "";
            Contents = JsonConvert.DeserializeObject<List<Content.RootObject>>(GetJSON(URL));
            //PageController PageController = new PageController(MyLayout, Contents);
            //PageController.DisplayEachPage();
        }
        private string GetJSON(string URL)
        {
            RestClient.RestClient restClient = new RestClient.RestClient { EndPoint = URL, HttpMethod = RestClient.RestClient.HttpVerb.GET };
            string response = restClient.DoRequest();
            return response;
        }
    }

}
