using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterBordering
{
    public class SimpleProjectClass
    {
        public string Name { get; set; }
        public DateTime LastSave { get; set; }
        public string Id { get; set; }
        public SimpleProjectClass()
        {
            Name = "";
            LastSave = DateTime.MinValue;
            Id = "";
        }
    }
}
