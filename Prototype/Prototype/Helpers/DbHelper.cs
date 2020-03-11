using System;
using System.Collections.Generic;
using System.Text;
using Prototype.Controllers;
using Prototype.RestClient;

namespace Prototype.Helpers
{
    class DbHelper
    {
        private RestClient.RestClient RestClient;
        private string Response;
        private string Courses = "https://online-step.herokuapp.com/courses/";
        private string Chapters = "https://online-step.herokuapp.com/courses/chapters/";
        private string Pages = "https://online-step.herokuapp.com/chapters/pages/";

        public DbHelper()
        {
            
        }

        public string GetCourses()
        {
            RestClient = new RestClient.RestClient { EndPoint = Courses, HttpMethod = Prototype.RestClient.RestClient.HttpVerb.GET };
            return Response = RestClient.DoRequest();           
        }

        public string GetChaptersById(string id)
        {
            RestClient = new RestClient.RestClient { EndPoint = Chapters + id, HttpMethod = Prototype.RestClient.RestClient.HttpVerb.GET };
            return Response = RestClient.DoRequest();
        }

        public string GetPagesById(string id)
        {
            RestClient = new RestClient.RestClient { EndPoint = Pages + id, HttpMethod = Prototype.RestClient.RestClient.HttpVerb.GET };
            return Response = RestClient.DoRequest();
        }
    }
}
