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
        public enum BASE_POINT_X
        {
            LEFT,
            CENTER,
            RIGHT
        }

        public enum BASE_POINT_Y
        {
            TOP,
            CENTER,
            BOTTOM
        }

        //画像補正情報
        public int ImageSizeX;
        public int ImageSizeY;
        public int OffsetX;
        public int OffsetY;
        public BASE_POINT_X BasePointX;
        public BASE_POINT_Y BasePointY;
        public bool AutoCenterX;
        public bool AutoCenterY;

        //
        public string FontName;
        public int FontSize;
        public bool Bold;
        public bool Italic;
        public SerializableColor BaseColor;
        public bool Centering;
        public string Text;


        public SerializableSortedDictionary<int, DecorationInfo> DecorationDic;

        public TextInfo() {

            ImageSizeX = 0;
            ImageSizeY = 0;
            OffsetX = 0;
            OffsetY = 0;

            BasePointX = BASE_POINT_X.CENTER;
            BasePointY = BASE_POINT_Y.TOP;
            AutoCenterX = false;
            AutoCenterY = false;

            FontName = "Arial";
            FontSize = 36;
            Text = "";
            BaseColor = new SerializableColor(System.Drawing.Color.White);
            Bold = false;
            Italic = false;
            Centering = false;

            DecorationDic = new SerializableSortedDictionary<int, DecorationInfo>();
            //DecorationDic[0] = new DecorationInfo();
            //DecorationDic[0].Color = Color.Green;
            //DecorationDic[0].Thick = 10;
            //DecorationDic[1] = new DecorationInfo();
            //DecorationDic[1].Color = Color.Black;
            //DecorationDic[1].Thick = 10;
        }

    }


}
