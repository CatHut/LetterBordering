using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using CatHut;

namespace LetterBordering
{
    public class ProjectClass
    {
        public string Id;
        public string Name;
        public DateTime LastSave;
        public int SelectedTextIndex;
        public SerializableSortedDictionary<int, TextInfo> TextInfoDic;

        public ProjectClass() 
        {
            Id = Guid.NewGuid().ToString();
            Name = "New Project";
            LastSave = DateTime.Now;
            SelectedTextIndex = 0;

            TextInfoDic = new SerializableSortedDictionary<int, TextInfo>();

        }

        public ProjectClass(string id, string name, DateTime lastSave)
        {
            Id = id;
            Name = name;
            LastSave = lastSave;
        }

    }
}
