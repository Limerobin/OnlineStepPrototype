using Prototype.Models;
using System.Collections.Generic;
using Prototype.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
    {
        private List<Course> Courses;
        private NavigationController Controller;
        public CourseView(List<Course> courseList)
        {
            InitializeComponent();
            this.Courses = courseList;
            Controller = new NavigationController();
            ShowCourses();
        }

        public void ShowCourses()
        {
            foreach (var i in Courses)
            {
                Button btn = new Button { Text = i.Name };
                CourseViewLayout.Children.Add(btn);
                btn.Clicked += Controller.CourseBtnAction;
            }
        }

    }
}