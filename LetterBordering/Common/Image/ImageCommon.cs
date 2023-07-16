using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHut
{
    public class ImageCommon
    {
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

        public static Image MarginRemove(Bitmap img, int alpha)
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

        private static Image CreateErrorImage()
        {
            // フォントとフォントスタイルを指定する
            Font font = new Font("Arial", 8, FontStyle.Bold);

            // Imageオブジェクトを作成する
            Image img = new Bitmap(200, 100);

            // usingステートメントを使用してGraphicsオブジェクトを作成する
            using (Graphics g = Graphics.FromImage(img))
            {
                // テキストを描画する
                g.DrawString("出力できる画像がありません。", font, Brushes.Red, 10, 10);
            }

            return img;
        }


        //    public static Size MeasureString(string text, Font font)
        //    {
        //        // 仮のサイズを計測
        //        Bitmap image = new Bitmap(1, 1);
        //        Graphics tempG = Graphics.FromImage(image);
        //        SizeF size = tempG.MeasureString(text, font, int.MaxValue);
        //        tempG.Dispose();
        //        image.Dispose();

        //        // 仮のサイズのベースの画像を作成
        //        Bitmap baseImage = new Bitmap((int)Math.Ceiling(size.Width), (int)Math.Ceiling(size.Height), PixelFormat.Format32bppArgb);
        //        Graphics g = Graphics.FromImage(baseImage);
        //        g.SmoothingMode = SmoothingMode.AntiAlias;
        //        g.TextRenderingHint = TextRenderingHint.AntiAlias;

        //        // 文字列を実際に描画
        //        g.DrawString(text, font, Brushes.Black, 0, 0);

        //        // 上下左右の探索を行うための変数を初期化
        //        int minX = baseImage.Width;
        //        int maxX = 0;
        //        int minY = baseImage.Height;
        //        int maxY = 0;

        //        // 上方向から探索
        //        minY = BinarySearchY(baseImage, true);

        //        // 下方向から探索
        //        maxY = BinarySearchY(baseImage, false);

        //        // 左方向から探索
        //        minX = BinarySearchX(baseImage, true);

        //        // 右方向から探索
        //        maxX = BinarySearchX(baseImage, false);

        //        // 範囲を計算して返す
        //        int width = Math.Max(1, maxX - minX);
        //        int height = Math.Max(1, maxY - minY);
        //        Size resultSize = new Size(width, height);

        //        // リソースを解放
        //        g.Dispose();
        //        baseImage.Dispose();

        //        return resultSize;
        //    }




        //    private static int BinarySearchY(Bitmap image, bool searchUp)
        //    {
        //        int top = 0;
        //        int bottom = image.Height - 1;
        //        while (top <= bottom)
        //        {
        //            int mid = (top + bottom) / 2;
        //            bool found = false;
        //            for (int x = 0; x < image.Width; x++)
        //            {
        //                Color pixel = image.GetPixel(x, mid);
        //                if (pixel.A != 0)
        //                {
        //                    found = true;
        //                    break;
        //                }
        //            }
        //            if (found == searchUp)
        //            {
        //                bottom = mid - 1;
        //            }
        //            else
        //            {
        //                top = mid + 1;
        //            }
        //        }
        //        return searchUp ? top : bottom;
        //    }

        //    private static int BinarySearchX(Bitmap image, bool searchLeft)
        //    {
        //        int left = 0;
        //        int right = image.Width - 1;
        //        while (left <= right)
        //        {
        //            int mid = (left + right) / 2;
        //            bool found = false;
        //            for (int y = 0; y < image.Height; y++)
        //            {
        //                Color pixel = image.GetPixel(mid, y);
        //                if (pixel.A != 0)
        //                {
        //                    found = true;
        //                    break;
        //                }
        //            }
        //            if (found == searchLeft)
        //            {
        //                right = mid - 1;
        //            }
        //            else
        //            {
        //                left = mid + 1;
        //            }
        //        }
        //        return searchLeft ? left : right;
        //    }


        //}

    }

}
