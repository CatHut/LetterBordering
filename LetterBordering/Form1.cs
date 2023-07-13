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
            //�C���v�b�g
            string text = textBox_InputText.Text; //�e�L�X�g
            Font font = new Font("Arial", 50); //�t�H���g
            Color outline1Color = Color.Red; //�����P�F
            float outline1Width = (float)numericUpDown_Size01.Value; //�����P����
            Color outline2Color = Color.Blue; //�����Q�F
            float outline2Width = (float)numericUpDown_Size02.Value; //�����P����

            // �e�L�X�g�̃T�C�Y���v�Z����
            SizeF textSize = MeasureString(text, font);

            // �摜�̃T�C�Y�����߂�i�]�����܂ށj
            int margin = 10;
            int width = (int)Math.Ceiling(textSize.Width) + margin * 2;
            int height = (int)Math.Ceiling(textSize.Height) + margin * 2;

            // �摜���쐬����
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Graphics�I�u�W�F�N�g���쐬����
            Graphics g = Graphics.FromImage(image);

            // �A���`�G�C���A�X��L���ɂ���
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // ������̕`��ʒu�����߂�
            PointF point = new PointF(margin, margin);

            // GraphicsPath�I�u�W�F�N�g���쐬����
            GraphicsPath path = new GraphicsPath();
            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2;



            //�p�X���쐬����
            // �e�L�X�g�̗֊s��ǉ�����
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, point, StringFormat.GenericDefault);
            path1.AddString(text, font.FontFamily, (int)font.Style, font.Size, point, StringFormat.GenericDefault);

            //�y�����쐬����
            // �����Q�y�����쐬����
            Pen pen2 = new Pen(outline2Color, outline2Width);
            pen2.LineJoin = LineJoin.Round;

            // �����P�y�����쐬����
            Pen pen1 = new Pen(outline1Color, outline1Width);
            pen1.LineJoin = LineJoin.Round;

            //�p�X��␳
            path1.Widen(pen1);

            path2 = (GraphicsPath)path1.Clone();
            path2.Widen(pen2);

            pen1.Dispose();
            pen2.Dispose();
            pen1 = new Pen(outline1Color, 1);
            pen2 = new Pen(outline2Color, 1);

            //�`�悷��
            Brush brush2 = new SolidBrush(Color.Blue);
            g.FillPath(brush2, path2);

            Brush brush1 = new SolidBrush(Color.Red);
            g.FillPath(brush1, path1);


            // �e�L�X�g��h��Ԃ�
            Brush brush = new SolidBrush(Color.White);
            g.FillPath(brush, path);

            //�s�N�`���{�b�N�X�ɐݒ�
            pictureBox_Preview.Image = image;

            // �I�u�W�F�N�g��j������
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