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
        //画像補正情報
        public int ImageSizeX;
        public int ImageSizeY;
        public int OffsetX;
        public int OffsetY;
        public bool CenterBaseX;
        public bool CenterBaseY;
        public bool AutoCenterX;
        public bool AutoCenterY;

        //
        public string FontName;
        public int FontSize;
        public bool Bold;
        public bool Italic;
        Color BaseColor;
        public string Text;


        public SerializableSortedDictionary<int, DecorationInfo> DecorationDic;

        public TextInfo() {

            ImageSizeX = 0;
            ImageSizeY = 0;
            OffsetX = 0;
            OffsetY = 0;

            CenterBaseX = false;
            CenterBaseY = false;
            AutoCenterX = false;
            AutoCenterY = false;

            FontName = "Arial";
            FontSize = 36;
            Text = "";
            Bold = false;
            Italic = false;

            DecorationDic = new SerializableSortedDictionary<int, DecorationInfo>();
        }

    }


}
