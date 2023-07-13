using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;

namespace TextToSVG
{
    class Program
    {
        static void Main(string[] args)
        {
            // テキストとフォントの設定
            string text = "Hello, world!";
            Font font = new Font("Arial", 72, FontStyle.Bold);

            // テキストのサイズを計測
            SizeF textSize = MeasureTextSize(text, font);

            // テキストを描画するビットマップを作成
            Bitmap bitmap = new Bitmap((int)textSize.Width, (int)textSize.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, Brushes.Black, 0, 0);

            // ビットマップをモノクロに変換
            bitmap = ConvertToMonochrome(bitmap);

            // ビットマップをベクター化する
            GraphicsPath path = VectorizeBitmap(bitmap);

            // ベクター画像をSVG形式で保存する
            SaveAsSVG(path, "text.svg");
        }

        // テキストのサイズを計測するメソッド
        static SizeF MeasureTextSize(string text, Font font)
        {
            using (Bitmap dummy = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(dummy))
            {
                return g.MeasureString(text, font);
            }
        }

        // ビットマップをモノクロに変換するメソッド
        static Bitmap ConvertToMonochrome(Bitmap bitmap)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    int gray = (color.R + color.G + color.B) / 3;
                    if (gray < 128)
                    {
                        result.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.White);
                    }
                }
            }
            return result;
        }

        // ビットマップをベクター化するメソッド
        static GraphicsPath VectorizeBitmap(Bitmap bitmap)
        {
            GraphicsPath path = new GraphicsPath();
            bool inPath = false;
            int startX = 0;
            int startY = 0;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    if (!inPath && color == Color.Black)
                    {
                        // パスの開始点を記録
                        inPath = true;
                        startX = x;
                        startY = y;
                    }
                    else if (inPath && color == Color.White)
                    {
                        // パスの終了点を見つけて線分を追加
                        inPath = false;
                        path.AddLine(startX, startY, x - 1, y - 1);
                    }
                }
                if (inPath)
                {
                    // 行末までパスが続いている場合は線分を追加
                    inPath = false;
                    path.AddLine(startX, startY, bitmap.Width - 1, y - 1);
                }
            }
            return path;
        }

        // ベクター画像をSVG形式で保存するメソッド
        static void SaveAsSVG(GraphicsPath path, string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("svg", "http://www.w3.org/2000/svg");
                writer.WriteAttributeString("width", path.GetBounds().Width.ToString());
                writer.WriteAttributeString("height", path.GetBounds().Height.ToString());
                writer.WriteAttributeString("viewBox", $"0 0 {path.GetBounds().Width} {path.GetBounds().Height}");
                writer.WriteStartElement("path");
                writer.WriteAttributeString("fill", "none");
                writer.WriteAttributeString("stroke", "black");
                writer.WriteAttributeString("stroke-width", "1");
                writer.WriteAttributeString("d", GetPathData(path));
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        // ベクター画像のパスデータを取得するメソッド
        static string GetPathData(GraphicsPath path)
        {
            string data = "";
            bool first = true;
            foreach (PointF point in path.PathPoints)
            {
                if (first)
                {
                    // 最初の点は移動命令
                    data += $"M {point.X} {point.Y} ";
                    first = false;
                }
                else
                {
                    // それ以降の点は直線命令
                    data += $"L {point.X} {point.Y} ";
                }
            }
            return data;
        }
    }
}
