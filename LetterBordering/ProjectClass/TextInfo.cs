using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatHut;
using static LetterBordering.TextInfo;

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

        public enum BACK_COLOR
        {
            WHITE,
            BLACK,
            OTHER
        }

        public enum RESOLUTION_INDEX
        {
            NONE,       //なし
            MANUAL,         //手動
            VGA,            //VGA	    640× 480
            SDTB,           //SDTV	    720× 480
            HDTV,           //HDTV	    1280×720
            FHD_2K,         //2K/FHD	1920×1080
            WQHD,           //WQHD  	2560×1440
            UHD_4K,         //4K/UHD	3840×2160
        }

        //表示サンプル設定
        public BACK_COLOR SelectedBackColor;
        public SerializableColor BackColor;

        //画像補正情報
        public RESOLUTION_INDEX ResolutionIndex;
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
        public bool DirectionVirtical;
        public SerializableColor BaseColor;
        public bool Centering;
        public string Text;


        public SerializableSortedDictionary<int, DecorationInfo> DecorationDic;

        public TextInfo() {
            SelectedBackColor = BACK_COLOR.WHITE;
            BackColor = new SerializableColor(System.Drawing.Color.White);

            ResolutionIndex = RESOLUTION_INDEX.NONE;
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
            DirectionVirtical = false;

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
