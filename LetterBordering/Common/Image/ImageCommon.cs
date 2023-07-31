using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LetterBordering.TextInfo;

namespace CatHut
{
    public static class ImageCommon
    {
        public static  Dictionary<RESOLUTION_INDEX, Size> ResolutionDic = new Dictionary<RESOLUTION_INDEX, Size>(){
            {RESOLUTION_INDEX.NONE  , new Size(0   , 0   )},
            {RESOLUTION_INDEX.VGA   , new Size(640 , 480 )},
            {RESOLUTION_INDEX.SDTB  , new Size(720 , 480 )},
            {RESOLUTION_INDEX.HDTV  , new Size(1280, 720 )},
            {RESOLUTION_INDEX.FHD_2K, new Size(1920, 1080)},
            {RESOLUTION_INDEX.WQHD  , new Size(2560, 1440)},
            {RESOLUTION_INDEX.UHD_4K, new Size(3840, 2160)},
        };


        public static Size MeasureString(string text, Font font)
        {
            // 仮のサイズを計測
            Bitmap image = new Bitmap(1, 1);
            Graphics tempG = Graphics.FromImage(image);
            SizeF size = tempG.MeasureString(text, font, int.MaxValue);
            tempG.Dispose();
            image.Dispose();

            Size resultSize = new Size((int)Math.Ceiling(size.Width), (int)Math.Ceiling(size.Height));

            return resultSize;
        }


        public static Bitmap MarginRemoveB(Bitmap img, int alpha)
        {
            // 余白を検出するための最小値
            int minX = img.Width;
            int minY = img.Height;
            int maxX = 0;
            int maxY = 0;

            // 画像をスキャンする
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    // ピクセルを取得する
                    Color pixel = img.GetPixel(x, y);

                    // 透明でないピクセルの場合は、余白の境界を更新する
                    if (pixel.A > alpha)
                    {
                        if (x < minX) minX = x;
                        if (y < minY) minY = y;
                        if (x > maxX) maxX = x;
                        if (y > maxY) maxY = y;
                    }
                }
            }

            // minX, maxX, minY, maxY の値が正しいかチェックする
            // 値が不正な場合は、それぞれ0を設定する
            maxX = Math.Max(0, maxX);
            maxY = Math.Max(0, maxY);
            minX = Math.Min(maxX, minX);
            minY = Math.Min(maxY, minY);

            if (maxY == minY || maxX == minX)
            {
                return CreateErrorImage();
            }


            // 新しいBitmapオブジェクトを作成する
            Bitmap newImg = new Bitmap(maxX - minX + 1, maxY - minY + 1);

            // 余白を削除した画像を作成する
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    // ピクセルを取得する
                    Color pixel = img.GetPixel(x, y);

                    // 新しい画像にピクセルを設定する
                    newImg.SetPixel(x - minX, y - minY, pixel);
                }
            }

            return newImg;
        }

        public static Bitmap MarginRemove(Bitmap img, int alpha)
        {
            // 余白を検出するための最小値
            int minX = img.Width / 2;
            int minY = img.Height / 2;
            int maxX = img.Width / 2;
            int maxY = img.Height / 2;

            // BitmapDataオブジェクトを作成する
            BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // ピクセルデータの先頭アドレスを取得する
            IntPtr ptr = data.Scan0;

            // ピクセルデータをバイト配列にコピーする
            int bytes = Math.Abs(data.Stride) * data.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // 画像をスキャンする
            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                // アルファ値を取得する
                byte a = rgbValues[i + 3];

                // 透明でないピクセルの場合は、余白の境界を更新する
                if (a > alpha)
                {
                    // x座標とy座標を計算する
                    int x = (i / 4) % data.Width;
                    int y = (i / 4) / data.Width;

                    if (x < minX) minX = x;
                    if (y < minY) minY = y;
                    if (x > maxX) maxX = x;
                    if (y > maxY) maxY = y;
                }
            }

            // BitmapDataオブジェクトを解放する
            img.UnlockBits(data);

            // minX, maxX, minY, maxY の値が正しいかチェックする
            // 値が不正な場合は、それぞれ0を設定する
            maxX = Math.Max(0, maxX);
            maxY = Math.Max(0, maxY);
            minX = Math.Min(maxX, minX);
            minY = Math.Min(maxY, minY);

            if (maxY == minY || maxX == minX)
            {
                return CreateErrorImage();
            }

            // 新しいBitmapオブジェクトを作成する
            Bitmap newImg = new Bitmap(maxX - minX + 1, maxY - minY + 1);

            // Cloneメソッドで余白を削除した画像を作成する
            newImg = img.Clone(new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1), PixelFormat.Format32bppArgb);

            return newImg;
        }


        private static Bitmap CreateErrorImage()
        {
            // フォントとフォントスタイルを指定する
            Font font = new Font("Arial", 8, FontStyle.Bold);

            // Imageオブジェクトを作成する
            Bitmap img = new Bitmap(200, 100);

            // usingステートメントを使用してGraphicsオブジェクトを作成する
            using (Graphics g = Graphics.FromImage(img))
            {
                // テキストを描画する
                g.DrawString("出力できる画像がありません。", font, Brushes.Red, 10, 10);
            }

            return img;
        }



    }

}
