using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace LetterBordering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_InputText_TextChanged(object sender, EventArgs e)
        {

            UpdateImage();

        }

        private void numericUpDown_Size01_ValueChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void numericUpDown_Size02_ValueChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void UpdateImage()
        {
            //インプット
            string text = textBox_InputText.Text; //テキスト
            Font font = new Font("Arial", 50); //フォント
            Color outline1Color = Color.Red; //縁取り１色
            float outline1Width = (float)numericUpDown_Size01.Value; //縁取り１太さ
            Color outline2Color = Color.Blue; //縁取り２色
            float outline2Width = (float)numericUpDown_Size02.Value; //縁取り１太さ

            // テキストのサイズを計算する
            SizeF textSize = MeasureString(text, font);

            // 画像のサイズを決める（余白を含む）
            int margin = 10;
            int width = (int)Math.Ceiling(textSize.Width) + margin * 2;
            int height = (int)Math.Ceiling(textSize.Height) + margin * 2;

            // 画像を作成する
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Graphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(image);

            // アンチエイリアスを有効にする
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // 文字列の描画位置を決める
            PointF point = new PointF(margin, margin);

            // GraphicsPathオブジェクトを作成する
            GraphicsPath path = new GraphicsPath();
            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2;



            //パスを作成する
            // テキストの輪郭を追加する
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, point, StringFormat.GenericDefault);
            path1.AddString(text, font.FontFamily, (int)font.Style, font.Size, point, StringFormat.GenericDefault);

            //ペンを作成する
            // 縁取り２ペンを作成する
            Pen pen2 = new Pen(outline2Color, outline2Width);
            pen2.LineJoin = LineJoin.Round;

            // 縁取り１ペンを作成する
            Pen pen1 = new Pen(outline1Color, outline1Width);
            pen1.LineJoin = LineJoin.Round;

            //パスを補正
            path1.Widen(pen1);

            path2 = (GraphicsPath)path1.Clone();
            path2.Widen(pen2);

            pen1.Dispose();
            pen2.Dispose();
            pen1 = new Pen(outline1Color, 1);
            pen2 = new Pen(outline2Color, 1);

            //描画する
            Brush brush2 = new SolidBrush(Color.Blue);
            g.FillPath(brush2, path2);

            Brush brush1 = new SolidBrush(Color.Red);
            g.FillPath(brush1, path1);


            // テキストを塗りつぶす
            Brush brush = new SolidBrush(Color.White);
            g.FillPath(brush, path);

            //ピクチャボックスに設定
            pictureBox_Preview.Image = image;

            // オブジェクトを破棄する
            brush.Dispose();
            brush1.Dispose();
            brush2.Dispose();
            pen1.Dispose();
            pen2.Dispose();
            path.Dispose();
            path1.Dispose();
            path2.Dispose();
            g.Dispose();

        }

        public static SizeF MeasureString(string text, Font font)
        {

            Bitmap image = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(image);
            StringFormat sf = StringFormat.GenericTypographic;
            SizeF size = g.MeasureString(text, font, int.MaxValue, sf);
            g.Dispose();
            image.Dispose();
            return size;

        }

    }
}