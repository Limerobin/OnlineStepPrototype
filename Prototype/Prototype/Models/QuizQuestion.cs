using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    class QuizQuestion
    {
        public string Question { get; set; }     
        public string Alt1 { get; set; }
        public string Alt2 { get; set; }
        public string Alt3 { get; set; }
        public string CorrectAnswer { get; set; }
        public QuizQuestion() { }
     
    }
}
