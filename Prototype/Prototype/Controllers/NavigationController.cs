using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Prototype.Models;
using Prototype.Views;
using Xamarin.Forms;
using Prototype.Helpers;

namespace Prototype.Controllers
{
    class NavigationController
    {
        //Repository iden är fortfarande onödig imo /Najem
       // private CourseRepository CourseRepository;
        private List<Course> Courses;
        public List<Chapter> Chapters;
        private List<Content.RootObject> Contents;
        public DbHelper DbHelper;
        

        public NavigationController()
        {
            DbHelper = new DbHelper();
        }

        public CourseView InitialApp()
        {
            Courses = JsonConvert.DeserializeObject<List<Course>>(DbHelper.GetCourses());
            CourseView courseView = new CourseView(Courses);
            return courseView;
        }

        public void ShowChapters(Button btn, string id)
        {                      
            Chapters = JsonConvert.DeserializeObject<List<Chapter>>(DbHelper.GetChaptersById(id));
            btn.Navigation.PushModalAsync(new ChapterView(Chapters));
        }
      
        public void ShowPageContent(Button btn, string id)
        {
            Contents = JsonConvert.DeserializeObject<List<Content.RootObject>>(DbHelper.GetChaptersById(id));
            btn.Navigation.PushModalAsync(new PageView());
        }

    }
}
