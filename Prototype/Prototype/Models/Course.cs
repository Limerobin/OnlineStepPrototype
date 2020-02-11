using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    class Course
    {
        public List<string> Chapters { get; set; }
        public string _id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Subject { get; set; }
        public int __v { get; set; }

        public Course() { }
    }

}
