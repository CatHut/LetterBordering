using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatHut;

namespace LetterBordering
{
    public class TextInfo
    {
        public string Text;
        public string FontName;
        public int FontSize;
        public bool Bold;
        public bool Italic;

        public SerializableSortedDictionary<int, DecorationInfo> DecorationDic;

        public TextInfo() {
            FontName = "Arial";
            FontSize = 36;
            Text = "";
            Bold = false;
            Italic = false;

            DecorationDic = new SerializableSortedDictionary<int, DecorationInfo>();
        }

    }


}
