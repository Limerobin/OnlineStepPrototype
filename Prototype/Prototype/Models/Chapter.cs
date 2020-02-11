using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    class Chapter
    {
        public List<string> Pages { get; set; }
        public string _id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Subjects { get; set; }
        public int __v { get; set; }
        public string Subject { get; set; }
    }
}
