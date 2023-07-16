using LetterBordering.Setting;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CatHut;

namespace LetterBordering
{
    public partial class Form1 : Form
    {
        HashSet<IDisposable> DisposablesList;
        Dictionary<string, FontFamily> FontFamilyDic;

        ProjectManager PM;

        bool EventEnable = true;



        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {

            FontFamilyDic = GetFontFamiles();

            comboBox_Font.Items.AddRange(FontFamilyDic.Keys.ToArray());

            PM = new ProjectManager();

            EventEnable = false;
            {
                UpdateUiValues();
            }
            EventEnable = true;
            CommonUpdate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {

            }
            EventEnable = true;

        }



        private void textBox_InputText_TextChanged(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ReadUiValues();
                UpdateImage();

            }
            EventEnable = true;

        }

        private void numericUpDown_Size01_ValueChanged(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ReadUiValues();
                UpdateImage();

            }
            EventEnable = true;
        }

        private void numericUpDown_Size02_ValueChanged(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ReadUiValues();
                UpdateImage();

            }
            EventEnable = true;

        }

        private Bitmap CreateImage()
        {

            var idx = PM.AsProject.Settings.SelectedTextIndex;
            var textInfo = PM.AsProject.Settings.TextInfoDic[idx];

            var text = textInfo.Text;
            var font = CreateFont(textInfo);

            var outline1Width = textInfo.DecorationDic[0].Thick;
            var outline2Width = textInfo.DecorationDic[1].Thick;

            var outline1Color = textInfo.DecorationDic[0].Color;
            var outline2Color = textInfo.DecorationDic[1].Color;


            // �e�L�X�g�̃T�C�Y���v�Z����
            Size textSize = ImageCommon.MeasureString(text, font);

            // �摜�̃T�C�Y�����߂�i�]�����܂ށj
            int margin = 0 + outline1Width + outline2Width;
            int width = Math.Max(1, textSize.Width + margin * 2);
            int height = Math.Max(1, textSize.Height + margin * 2);


            // �摜���쐬����
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            PushDisporsable(image);

            // Graphics�I�u�W�F�N�g���쐬����
            Graphics g = Graphics.FromImage(image);
            PushDisporsable(g);

            // �A���`�G�C���A�X��L���ɂ���
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // ������̕`��ʒu�����߂�
            PointF point = new PointF(margin, margin);

            // GraphicsPath�I�u�W�F�N�g���쐬����
            GraphicsPath path = new GraphicsPath();
            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2;
            PushDisporsable(path);
            PushDisporsable(path1);

            //�p�X���쐬����
            // �e�L�X�g�̗֊s��ǉ�����
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, point, StringFormat.GenericDefault);
            path1.AddString(text, font.FontFamily, (int)font.Style, font.Size, point, StringFormat.GenericDefault);

            //�y�����쐬����
            // �����Q�y�����쐬����
            Pen pen2 = new Pen(outline2Color, outline2Width);
            PushDisporsable(pen2);
            pen2.LineJoin = LineJoin.Round;

            // �����P�y�����쐬����
            Pen pen1 = new Pen(outline1Color, outline1Width);
            PushDisporsable(pen1);
            pen1.LineJoin = LineJoin.Round;

            //�p�X��␳
            path1.Widen(pen1);

            path2 = (GraphicsPath)path1.Clone();
            PushDisporsable(path2);
            path2.Widen(pen2);

            //�`�悷��
            if (outline2Width > 0)
            {
                Brush brush2 = new SolidBrush(Color.Blue);
                g.FillPath(brush2, path2);
                brush2.Dispose();
            }

            if (outline1Width > 0)
            {
                Brush brush1 = new SolidBrush(Color.Red);
                g.FillPath(brush1, path1);
                brush1.Dispose();
            }


            // �e�L�X�g��h��Ԃ�
            Brush brush = new SolidBrush(Color.White);
            PushDisporsable(brush);
            g.FillPath(brush, path);

            //�}�[�W���폜
            Bitmap noMargin = ImageCommon.MarginRemove(image, 0);

            //�I�u�W�F�N�g��j������
            ReleaseDisposable();

            //return textSize;
            return noMargin;
        }


        private void UpdateImage()
        {

            var bmp = CreateImage();
            Rectangle? destRect = null;

            //�T�C�Y�\���X�V
            label_StringImageSize.Text = bmp.Width.ToString().PadLeft(4) + "�~" + bmp.Height.ToString().PadLeft(4);


            //�摜�T�C�Y����
            var idx = PM.AsProject.Settings.SelectedTextIndex;
            var textInfo = PM.AsProject.Settings.TextInfoDic[idx];
            if (textInfo.ImageSizeX != 0 && textInfo.ImageSizeY != 0)
            {
                Bitmap resizeBmp = new Bitmap(textInfo.ImageSizeX, textInfo.ImageSizeY, PixelFormat.Format32bppPArgb);

                using (Graphics tempG = Graphics.FromImage(resizeBmp))
                {
                    var xy = CalcOffset(bmp, resizeBmp);
                    var src_x = 0;
                    var src_y = 0;
                    var src_w = bmp.Width;
                    var src_h = bmp.Height;

                    var dest_x = xy.Width;
                    var dest_y = xy.Height;

                    if (xy.Width < 0)
                    {
                        src_x = Math.Abs(xy.Width);
                        src_w = src_w - src_x;
                        dest_x = 0;
                    }

                    if (xy.Height < 0)
                    {
                        src_y = Math.Abs(xy.Height);
                        src_h = src_h - src_y;
                        dest_y = 0;
                    }
                    Rectangle srcRect = new Rectangle(src_x, src_y, src_w, src_h);
                    destRect = new Rectangle(dest_x, dest_y, src_w, src_h);
                    tempG.DrawImage(bmp, (Rectangle)destRect, srcRect, GraphicsUnit.Pixel);
                }

                bmp.Dispose();
                bmp = resizeBmp;
            }

            //�T�C�Y�\���X�V
            label_ImageSize.Text = bmp.Width.ToString().PadLeft(4) + "�~" + bmp.Height.ToString().PadLeft(4);


            //�ۑ��͂����ł���B



            //�\���p�̒���
            Graphics g = Graphics.FromImage(bmp);
            PushDisporsable(g);

            // ���F�̃y�����쐬����
            Pen pen = new Pen(Color.Black);
            PushDisporsable(pen);

            if (destRect == null)
            {
                // �摜�̒[����1�s�N�Z�������ɋ�`��`�悷��
                g.DrawRectangle(pen, 0, 0, bmp.Width - 1, bmp.Height - 1);
            }
            else
            {
                // �摜�̒[����1�s�N�Z�������ɋ�`��`�悷��
                g.DrawRectangle(pen, (Rectangle)destRect);
            }



            //�O���Bitmap�I�u�W�F�N�g��Dispose����
            if (pictureBox_Preview.Image != null)
            {
                pictureBox_Preview.Image.Dispose();
            }

            //�s�N�`���{�b�N�X�ɐݒ�
            pictureBox_Preview.Image = bmp;

            ReleaseDisposable();

        }

        private Size CalcOffset(Bitmap str, Bitmap bmp)
        {

            var idx = PM.AsProject.Settings.SelectedTextIndex;
            var textInfo = PM.AsProject.Settings.TextInfoDic[idx];

            var tempX = textInfo.OffsetX;
            var tempY = textInfo.OffsetY;

            if (textInfo.CenterBaseX)
            {
                tempX = textInfo.OffsetX - str.Width / 2;
            }
            if (textInfo.CenterBaseY)
            {
                tempY = textInfo.OffsetY - str.Height / 2;
            }

            if (textInfo.AutoCenterX)
            {
                tempX = bmp.Width / 2 - str.Width / 2;
            }
            if (textInfo.AutoCenterY)
            {
                tempY = bmp.Height / 2 - str.Height / 2;
            }

            return new Size(tempX, tempY);

        }



        private Font CreateFont(TextInfo ti)
        {
            var fontName = ti.FontName;
            var fontSize = ti.FontSize;


            // �t�H���g�X�^�C����������
            FontStyle style = FontStyle.Regular;

            // ������checkbox���`�F�b�N����Ă���΁Astyle��FontStyle.Bold��ǉ�
            if (ti.Bold)
            {
                style |= FontStyle.Bold;
            }

            // �Α̂�checkbox���`�F�b�N����Ă���΁Astyle��FontStyle.Italic��ǉ�
            if (ti.Italic)
            {
                style |= FontStyle.Italic;
            }

            // �t�H���g�X�^�C����K�p
            return new Font(FontFamilyDic[fontName], fontSize, style);

        }


        public void ReadUiValues()
        {

            var idx = PM.AsProject.Settings.SelectedTextIndex;

            PM.AsProject.Settings.TextInfoDic[idx] = new TextInfo();
            PM.AsProject.Settings.TextInfoDic[idx].Text = textBox_InputText.Text;
            PM.AsProject.Settings.TextInfoDic[idx].FontName = comboBox_Font.Text;
            PM.AsProject.Settings.TextInfoDic[idx].FontSize = (int)numericUpDown_FontSize.Value;
            PM.AsProject.Settings.TextInfoDic[idx].Bold = checkBox_Bold.Checked;
            PM.AsProject.Settings.TextInfoDic[idx].Italic = checkBox_Italic.Checked;

            PM.AsProject.Settings.TextInfoDic[idx].ImageSizeX = (int)numericUpDown_ImageWidth.Value;
            PM.AsProject.Settings.TextInfoDic[idx].ImageSizeY = (int)numericUpDown_ImageHeight.Value;
            PM.AsProject.Settings.TextInfoDic[idx].OffsetX = (int)numericUpDown_OffsetX.Value;
            PM.AsProject.Settings.TextInfoDic[idx].OffsetY = (int)numericUpDown_OffsetY.Value;

            PM.AsProject.Settings.TextInfoDic[idx].CenterBaseX = checkBox_CenterBaseX.Checked;
            PM.AsProject.Settings.TextInfoDic[idx].CenterBaseY = checkBox_CenterBaseY.Checked;
            PM.AsProject.Settings.TextInfoDic[idx].AutoCenterX = checkBox_AutoCenterX.Checked;
            PM.AsProject.Settings.TextInfoDic[idx].AutoCenterY = checkBox_AutoCenterY.Checked;

            PM.AsProject.Settings.TextInfoDic[idx].DecorationDic[0] = new DecorationInfo();
            PM.AsProject.Settings.TextInfoDic[idx].DecorationDic[0].Thick = (int)numericUpDown_Size01.Value; //�����P����
            PM.AsProject.Settings.TextInfoDic[idx].DecorationDic[0].Color = Color.Red; //�����P�F;

            PM.AsProject.Settings.TextInfoDic[idx].DecorationDic[1] = new DecorationInfo();
            PM.AsProject.Settings.TextInfoDic[idx].DecorationDic[1].Thick = (int)numericUpDown_Size02.Value; //�����Q����
            PM.AsProject.Settings.TextInfoDic[idx].DecorationDic[1].Color = Color.Blue; //�����Q�F;
            PM.AsProject.SaveData();
        }


        public void UpdateUiValues()
        {
            comboBox_Project.Items.Clear();
            comboBox_Project.Text = PM.AsProject.Settings.Name;
            comboBox_Project.Items.AddRange(PM.GetProjectList().ToArray());
            SetTextSetListViewItems();

            var idx = PM.AsProject.Settings.SelectedTextIndex;
            listView_TextSet.SelectedIndices.Add(idx);

            //�摜�␳
            numericUpDown_ImageWidth.Value = PM.AsProject.Settings.TextInfoDic[idx].ImageSizeX;
            numericUpDown_ImageHeight.Value = PM.AsProject.Settings.TextInfoDic[idx].ImageSizeY;
            numericUpDown_OffsetX.Value = PM.AsProject.Settings.TextInfoDic[idx].OffsetX;
            numericUpDown_OffsetY.Value = PM.AsProject.Settings.TextInfoDic[idx].OffsetY;

            checkBox_CenterBaseX.Checked = PM.AsProject.Settings.TextInfoDic[idx].CenterBaseX;
            checkBox_CenterBaseY.Checked = PM.AsProject.Settings.TextInfoDic[idx].CenterBaseY;
            checkBox_AutoCenterX.Checked = PM.AsProject.Settings.TextInfoDic[idx].AutoCenterX;
            checkBox_AutoCenterY.Checked = PM.AsProject.Settings.TextInfoDic[idx].AutoCenterY;

            comboBox_Font.Text = PM.AsProject.Settings.TextInfoDic[idx].FontName;
            numericUpDown_FontSize.Value = PM.AsProject.Settings.TextInfoDic[idx].FontSize;
            checkBox_Bold.Checked = PM.AsProject.Settings.TextInfoDic[idx].Bold;
            checkBox_Italic.Checked = PM.AsProject.Settings.TextInfoDic[idx].Italic;

            textBox_InputText.Text = PM.AsProject.Settings.TextInfoDic[idx].Text.Replace("\n", Environment.NewLine);

            //����
            numericUpDown_Size01.Value = PM.AsProject.Settings.TextInfoDic[idx].DecorationDic[0].Thick;
            numericUpDown_Size02.Value = PM.AsProject.Settings.TextInfoDic[idx].DecorationDic[1].Thick;

        }

        public void SetTextSetListViewItems()
        {
            var idx = PM.AsProject.Settings.SelectedTextIndex;

            listView_TextSet.Items.Clear();
            foreach (var temp in PM.AsProject.Settings.TextInfoDic)
            {
                ListViewItem item = new ListViewItem();
                item.Text = temp.Key.ToString("D4");
                item.SubItems.Add(temp.Value.Text);
                listView_TextSet.Items.Add(item);
            }
        }



        public void PushDisporsable(IDisposable disposable)
        {
            DisposablesList = DisposablesList ?? new HashSet<IDisposable>();

            DisposablesList.Add(disposable);
        }

        public void ReleaseDisposable()
        {
            foreach (var temp in DisposablesList)
            {
                temp.Dispose();
            }

            DisposablesList.Clear();
        }

        public Dictionary<string, FontFamily> GetFontFamiles()
        {
            FontFamilyDic = FontFamilyDic ?? new Dictionary<string, FontFamily>();

            //�t�H���_�Ɋi�[����Ă���t�H���g��ǉ�
            var pfc = GetFontsFromFolder();
            foreach (var temp in pfc.Families)
            {
                FontFamilyDic[temp.Name] = temp;
            }

            //�C���X�g�[������Ă���t�H���g��ǉ�
            foreach (var temp in FontFamily.Families)
            {
                FontFamilyDic[temp.Name] = temp;
            }

            return FontFamilyDic;

        }

        /// <summary>
        /// Fonts�t�H���_�����ċA�T�����A�t�H���g�t�@�~���Ƃ��Ď擾�\��TTF�AOTF�ACFF�AEOT�t�@�C���� 
        /// PrivateFontCollection �Ƃ��Ď擾����֐�
        /// </summary>
        /// <returns>PrivateFontCollection</returns>
        private PrivateFontCollection GetFontsFromFolder()
        {
            // PrivateFontCollection�I�u�W�F�N�g���쐬
            PrivateFontCollection collection = new PrivateFontCollection();

            var folder = @".\Font";

            // �t�H���_���̂��ׂĂ�TTF�AOTF�ACFF�AEOT�t�@�C�����擾
            string[] files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);

            // �e�t�@�C���ɑ΂���
            foreach (string file in files)
            {
                // �t�@�C���̊g���q���擾�i�������ɕϊ��j
                string extension = Path.GetExtension(file).ToLower();

                // �g���q��TTF�AOTF�ACFF�AEOT�̂����ꂩ�ł����
                if (extension == ".ttf" || extension == ".otf" || extension == ".cff" || extension == ".eot")
                {
                    // �t�@�C������t�H���g��ǉ�
                    collection.AddFontFile(file);
                }
            }

            // PrivateFontCollection�I�u�W�F�N�g��Ԃ�
            return collection;
        }

        private void button_Up_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {

            }
            EventEnable = true;

        }

        private void button_Down_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {

            }
            EventEnable = true;

        }

        private void button_CreateProject_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                PM.CreateProject(comboBox_Project.Text);
                UpdateUiValues();
            }
            EventEnable = true;
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                PM.AddText();
                UpdateUiValues();
            }
            EventEnable = true;
        }

        private void numericUpDown_ImageWidth_ValueChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void comboBox_Font_SelectedValueChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void numericUpDown_ImageHeight_ValueChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void checkBox_Bold_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void checkBox_Italic_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void numericUpDown_FontSize_ValueChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }


        private void CommonUpdate()
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ReadUiValues();
                UpdateImage();
            }
            EventEnable = true;
        }

        private void button_ImageSizeClear_Click(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void numericUpDown_OffsetX_ValueChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void numericUpDown_OffsetY_ValueChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void checkBox_CenterBaseX_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void checkBox_CenterBaseY_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void checkBox_AutoCenterX_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void checkBox_AutoCenterY_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void button_Color00_Click(object sender, EventArgs e)
        {

            CommonUpdate();
        }

        private void button_Color01_Click(object sender, EventArgs e)
        {

            CommonUpdate();
        }

        private void button_Color02_Click(object sender, EventArgs e)
        {

            CommonUpdate();
        }
    }
}