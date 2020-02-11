using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    class Content
    {       
            public List<string> MissingWords { get; set; }
            public string sentence { get; set; }
            public List<string> Answers { get; set; }
            public string Question { get; set; }
            public string CorrectAnswer { get; set; }
        

        public class RootObject
        {
            public string _id { get; set; }
            public string type { get; set; }
            public string title { get; set; }
            public string author { get; set; }
            public Content content { get; set; }
            public int __v { get; set; }

        }

        public Content()
        {

        }
    }
}
