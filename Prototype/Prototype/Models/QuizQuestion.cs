using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    class QuizQuestion
    {
        public string Question { get; set; }     
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }
        public QuizQuestion() { }
     
    }
}
