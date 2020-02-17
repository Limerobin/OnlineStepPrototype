using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    class Cloze
    {
        public string Sentence { get; set; }
        public List<string> MissingWords { get; set; }
    }
}
