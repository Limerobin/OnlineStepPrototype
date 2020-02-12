﻿using System;
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
        private List<Course> Courses;
        private List<Chapter> Chapters;
        private List<Content.RootObject> Contents;
        

        public NavigationController(StackLayout layout)
        {
            this.MyLayout = layout;
        }
        
        public void ShowCourses()
        {
            string URL = "https://online-step.herokuapp.com/courses/";
            Courses = JsonConvert.DeserializeObject<List<Course>>(GetJSON(URL));
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
            MyLayout.Navigation.PushModalAsync(new ChapterView(id));
        }

        public void ShowChapters(string ChapterId)
        {
            string URL = "https://online-step.herokuapp.com/courses/chapters/"+ChapterId+"";
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
            foreach(var i in Chapters)
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

        public void ShowPageContent(string id)
        {
            string URL = "https://online-step.herokuapp.com/chapters/pages/" + id + "";
            Contents = JsonConvert.DeserializeObject<List<Content.RootObject>>(GetJSON(URL));
            PageController PageController = new PageController(MyLayout, Contents);
            PageController.DisplayEachPage();
        }
        private string GetJSON(string URL)
        {
            RestClient.RestClient restClient = new RestClient.RestClient { EndPoint = URL, HttpMethod = RestClient.RestClient.HttpVerb.GET };
            string response = restClient.DoRequest();
            return response;
        }
    }

}
