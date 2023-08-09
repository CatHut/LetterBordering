
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using CatHut;
using System.Diagnostics;
using static LetterBordering.TextInfo;
using System.Windows.Forms;

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


            EventEnable = false;
            {
                comboBox_Resolution.SelectedIndex = 0;
            }
            EventEnable = true;

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

            timer_TextChanged.Stop();
            timer_TextChanged.Start();

        }

        private void timer_TextChanged_Tick(object sender, EventArgs e)
        {

            timer_TextChanged.Stop();
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ReadUiValues();
                UpdateImage();

            }
            EventEnable = true;

        }


        private void textBox_InputText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Debug.WriteLine(e.KeyValue.ToString());
            //Debug.WriteLine(e.KeyData.ToString());
            //Debug.WriteLine(e.KeyCode.ToString());

            //if (EventEnable == false) { return; }
            //EventEnable = false;
            //{


            //}
            //EventEnable = true;
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

        private Bitmap CreateImage(int idx)
        {
            var textInfo = PM.AsProject.Settings.TextInfoDic[idx];

            var text = textInfo.Text;
            var font = CreateFont(textInfo);

            var outline1Width = textInfo.DecorationDic[0].Thick;
            var outline2Width = textInfo.DecorationDic[1].Thick;

            var outline1Color = textInfo.DecorationDic[0].Color;
            var outline2Color = textInfo.DecorationDic[1].Color;


            // テキストのサイズを計算する
            Size textSize = ImageCommon.MeasureString(text, font);

            // 画像のサイズを決める（余白を含む）
            int margin = 10 + outline1Width + outline2Width;
            int width = Math.Max(1, textSize.Width + margin * 2);
            int height = Math.Max(1, textSize.Height + margin * 2);


            // 画像を作成する
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            PushDisporsable(image);

            // Graphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(image);
            PushDisporsable(g);

            // アンチエイリアスを有効にする
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // 文字列の描画位置を決める
            //Rectangle rect = new Rectangle(0, 0, width, height);
            Point point = new Point(margin, margin);

            // GraphicsPathオブジェクトを作成する
            GraphicsPath path = new GraphicsPath();
            PushDisporsable(path);

            //パスを作成する
            // テキストの輪郭を追加する
            var sf = new StringFormat();
            if (textInfo.Centering)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                point = new Point(width / 2, height / 2);
            }

            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, point, sf);

            //Pen pen_test = new Pen(Color.White, 10);
            //PushDisporsable(pen_test);


            //ペンを作成する
            // 縁取り２ペンを作成する
            Pen pen2 = new Pen(outline2Color.ToColor(), (outline2Width + outline1Width) * 2);
            Pen pen2_thin = new Pen(outline2Color.ToColor(), (outline2Width + outline1Width));
            PushDisporsable(pen2);
            PushDisporsable(pen2_thin);
            pen2.LineJoin = LineJoin.Round;
            pen2_thin.LineJoin = LineJoin.Round;

            // 縁取り１ペンを作成する
            Pen pen1 = new Pen(outline1Color.ToColor(), outline1Width * 2);
            Pen pen1_thin = new Pen(outline1Color.ToColor(), outline1Width);
            PushDisporsable(pen1);
            PushDisporsable(pen1_thin);
            pen1.LineJoin = LineJoin.Round;
            pen1_thin.LineJoin = LineJoin.Round;


            //描画する
            if (outline2Width > 0)
            {
                Brush brush2 = new SolidBrush(outline2Color.ToColor());
                g.DrawPath(pen2, path);
                g.DrawPath(pen2_thin, path);
                g.FillPath(brush2, path);
                brush2.Dispose();
            }

            if (outline1Width > 0)
            {
                Brush brush1 = new SolidBrush(outline1Color.ToColor());
                g.DrawPath(pen1, path);
                g.DrawPath(pen1_thin, path);
                //g.DrawPath(pen_test, path);
                g.FillPath(brush1, path);
                brush1.Dispose();
            }

            // テキストを塗りつぶす
            Brush brush = new SolidBrush(textInfo.BaseColor.ToColor());
            PushDisporsable(brush);
            g.FillPath(brush, path);
            //g.DrawPath(pen_test, path);

            //Brush brush_test = new SolidBrush(textInfo.BaseColor.ToColor());
            //g.FillPath(brush_test, path);


            //マージン削除
            Bitmap noMargin = ImageCommon.MarginRemove(image, 0);

            //オブジェクトを破棄する
            ReleaseDisposable();

            //return textSize;
            return noMargin;
        }


        private void DrawBackGround(ref Bitmap bmp, int idx)
        {
            var textInfo = PM.AsProject.Settings.TextInfoDic[idx];

            Color color;

            switch (textInfo.SelectedBackColor)
            {
                case BACK_COLOR.WHITE:
                    color = Color.White;
                    break;
                case BACK_COLOR.BLACK:
                    color = Color.Black;
                    break;
                case BACK_COLOR.OTHER:
                    color = textInfo.BackColor.ToColor();
                    break;
                default:
                    color = Color.White;
                    break;
            }


            Bitmap tempBitmap = new Bitmap(bmp.Width, bmp.Height);

            using (Graphics tempG = Graphics.FromImage(tempBitmap))
            {
                using (Brush brush = new SolidBrush(color))
                {
                    tempG.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
                }
            }

            using (Graphics tempG = Graphics.FromImage(tempBitmap))
            {
                tempG.DrawImage(bmp, 0, 0);
            }
            bmp.Dispose();

            bmp = tempBitmap;

        }


        private void UpdateImage()
        {
            var idx = PM.AsProject.Settings.SelectedTextIndex;

            var bmp = CreateImage(idx);
            Rectangle? destRect = null;

            //サイズ表示更新
            label_StringImageSize.Text = bmp.Width.ToString().PadLeft(4) + "×" + bmp.Height.ToString().PadLeft(4);

            bmp = ResizeImage(ref bmp, idx, out destRect);

            //複数選択されている場合には重複描画を行う
            foreach (var itemIdx in listView_TextSet.SelectedIndices)
            {
                if (itemIdx == null) { continue; }

                var tempIdx = (int)itemIdx;
                if (idx == tempIdx) { continue; }    //自分自身は処理しない

                var textInfo = PM.AsProject.Settings.TextInfoDic[tempIdx];
                var width = textInfo.ImageSizeX;
                var height = textInfo.ImageSizeY;

                if (bmp.Width == width && bmp.Height == height)
                {
                    var tempImage = CreateImage(tempIdx);
                    tempImage = ResizeImage(ref tempImage, tempIdx);

                    using (Graphics tempG = Graphics.FromImage(bmp))
                    {
                        tempG.DrawImage(tempImage, 0, 0);
                    }

                    tempImage.Dispose();
                }

            }

            //背景色描画
            DrawBackGround(ref bmp, idx);

            //サイズ表示更新
            label_ImageSize.Text = bmp.Width.ToString().PadLeft(4) + "×" + bmp.Height.ToString().PadLeft(4);

            //表示用の調整
            Graphics g = Graphics.FromImage(bmp);
            PushDisporsable(g);

            // 黒色のペンを作成する
            Pen pen = new Pen(Color.Black);
            PushDisporsable(pen);

            if (destRect == null)
            {
                // 画像の端から1ピクセル内側に矩形を描画する
                g.DrawRectangle(pen, 0, 0, bmp.Width - 1, bmp.Height - 1);
            }
            else
            {
                //描画先を矩形として表示
                g.DrawRectangle(pen, (Rectangle)destRect);
            }


            //前回のBitmapオブジェクトをDisposeする
            if (pictureBox_Preview.Image != null)
            {
                pictureBox_Preview.Image.Dispose();
            }

            if (bmp.Width <= pictureBox_Preview.Width && bmp.Height <= pictureBox_Preview.Height)
            {
                // B is smaller than or equal to A, show it as is
                pictureBox_Preview.Image = bmp;
            }
            else
            {
                // B is larger than A, resize it to fit within A
                float scale = Math.Min((float)pictureBox_Preview.Width / bmp.Width, (float)pictureBox_Preview.Height / bmp.Height);
                int newWidth = Math.Max(1, (int)(bmp.Width * scale));
                int newHeight = Math.Max(1, (int)(bmp.Height * scale));
                Bitmap resizedB = new Bitmap(bmp, new Size(newWidth, newHeight));
                bmp.Dispose();
                pictureBox_Preview.Image = resizedB;
            }

            ReleaseDisposable();

        }

        private Bitmap ResizeImage(ref Bitmap bmp, int idx)
        {
            Rectangle? temp;
            ResizeImage(ref bmp, idx, out temp);
            return bmp;
        }

        private Bitmap ResizeImage(ref Bitmap bmp, int idx, out Rectangle? rect)
        {
            Rectangle? destRect = null;

            //画像サイズ調整
            var textInfo = PM.AsProject.Settings.TextInfoDic[idx];
            if (textInfo.ImageSizeX != 0 && textInfo.ImageSizeY != 0)
            {
                Bitmap resizeBmp = new Bitmap(textInfo.ImageSizeX, textInfo.ImageSizeY, PixelFormat.Format32bppPArgb);

                using (Graphics tempG = Graphics.FromImage(resizeBmp))
                {
                    var xy = CalcOffset(bmp, resizeBmp, idx);
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
                bmp = null;
                bmp = resizeBmp;
            }

            rect = destRect;

            return bmp;
        }


        private void SaveImage(int idx)
        {

            var bmp = CreateImage(idx);
            bmp = ResizeImage(ref bmp, idx);

            var path = @"Output\" + PM.AsProject.Settings.Name;

            //保存はここでする。
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var file = path + @"\" + idx.ToString("D4") + ".png";
            bmp.Save(file, ImageFormat.Png);
            bmp.Dispose();

        }

        private void SaveImage(int idx, List<int> idxList)
        {
            //基本画像作成
            var bmp = CreateImage(idx);
            bmp = ResizeImage(ref bmp, idx);

            Rectangle? destRect = null;

            //複数選択されている場合には重複描画を行う
            foreach (var tempIdx in idxList)
            {
                if (idx == tempIdx) { continue; }    //自分自身は処理しない

                var textInfo = PM.AsProject.Settings.TextInfoDic[tempIdx];
                var width = textInfo.ImageSizeX;
                var height = textInfo.ImageSizeY;

                //画像サイズが一致しなければ処理しない
                if (bmp.Width == width && bmp.Height == height)
                {
                    var tempImage = CreateImage(tempIdx);
                    tempImage = ResizeImage(ref tempImage, tempIdx);

                    using (Graphics tempG = Graphics.FromImage(bmp))
                    {
                        tempG.DrawImage(tempImage, 0, 0);
                    }

                    tempImage.Dispose();
                }

            }

            var path = @"Output\" + PM.AsProject.Settings.Name;

            //保存はここでする。
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var file = path + @"\" + idx.ToString("D4") + ".png";
            if (idxList.Count > 1)
            {
                file = path + @"\" + idx.ToString("D4") + "_overlay.png";
            }

            bmp.Save(file, ImageFormat.Png);
            bmp.Dispose();

        }



        private Size CalcOffset(Bitmap str, Bitmap bmp, int idx)
        {
            var textInfo = PM.AsProject.Settings.TextInfoDic[idx];

            var tempX = textInfo.OffsetX;
            var tempY = textInfo.OffsetY;


            switch (textInfo.BasePointX)
            {
                case TextInfo.BASE_POINT_X.LEFT:
                    tempX = textInfo.OffsetX;
                    break;
                case TextInfo.BASE_POINT_X.CENTER:
                    tempX = textInfo.OffsetX - str.Width / 2;
                    break;
                case TextInfo.BASE_POINT_X.RIGHT:
                    tempX = textInfo.OffsetX - str.Width;
                    break;
            }

            switch (textInfo.BasePointY)
            {
                case TextInfo.BASE_POINT_Y.TOP:
                    tempY = textInfo.OffsetY;
                    break;
                case TextInfo.BASE_POINT_Y.CENTER:
                    tempY = textInfo.OffsetY - str.Height / 2;
                    break;
                case TextInfo.BASE_POINT_Y.BOTTOM:
                    tempY = textInfo.OffsetY - str.Height;
                    break;
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


            // フォントスタイルを初期化
            FontStyle style = FontStyle.Regular;

            // 太字のcheckboxがチェックされていれば、styleにFontStyle.Boldを追加
            if (ti.Bold)
            {
                style |= FontStyle.Bold;
            }

            // 斜体のcheckboxがチェックされていれば、styleにFontStyle.Italicを追加
            if (ti.Italic)
            {
                style |= FontStyle.Italic;
            }

            // フォントスタイルを適用
            return new Font(FontFamilyDic[fontName], fontSize, style);

        }


        public void ReadUiValues()
        {

            var idx = PM.AsProject.Settings.SelectedTextIndex;

            var textInfo = new TextInfo();
            textInfo.Text = textBox_InputText.Text;
            textInfo.FontName = comboBox_Font.Text;
            textInfo.FontSize = (int)numericUpDown_FontSize.Value;
            textInfo.Bold = checkBox_Bold.Checked;
            textInfo.Italic = checkBox_Italic.Checked;
            textInfo.Centering = checkBox_Centering.Checked;
            textInfo.BaseColor = new SerializableColor(button_Color00.BackColor);

            textInfo.ImageSizeX = (int)numericUpDown_ImageWidth.Value;
            textInfo.ImageSizeY = (int)numericUpDown_ImageHeight.Value;


            textInfo.ResolutionIndex = (RESOLUTION_INDEX)comboBox_Resolution.SelectedIndex;
            textInfo.OffsetX = (int)numericUpDown_OffsetX.Value;
            textInfo.OffsetY = (int)numericUpDown_OffsetY.Value;

            foreach (RadioButton rb in panel_BasePointX.Controls)
            {
                switch (rb.Tag)
                {
                    case "LEFT":
                        if (rb.Checked) { textInfo.BasePointX = TextInfo.BASE_POINT_X.LEFT; }
                        break;
                    case "CENTER":
                        if (rb.Checked) { textInfo.BasePointX = TextInfo.BASE_POINT_X.CENTER; }
                        break;
                    case "RIGHT":
                        if (rb.Checked) { textInfo.BasePointX = TextInfo.BASE_POINT_X.RIGHT; }
                        break;
                    default:
                        textInfo.BasePointX = TextInfo.BASE_POINT_X.CENTER;
                        break;
                }
            }

            foreach (RadioButton rb in panel_BasePointY.Controls)
            {
                switch (rb.Tag)
                {
                    case "TOP":
                        if (rb.Checked) { textInfo.BasePointY = TextInfo.BASE_POINT_Y.TOP; }
                        break;
                    case "CENTER":
                        if (rb.Checked) { textInfo.BasePointY = TextInfo.BASE_POINT_Y.CENTER; }
                        break;
                    case "BOTTOM":
                        if (rb.Checked) { textInfo.BasePointY = TextInfo.BASE_POINT_Y.BOTTOM; }
                        break;
                    default:
                        textInfo.BasePointY = TextInfo.BASE_POINT_Y.TOP;
                        break;
                }
            }

            textInfo.AutoCenterX = checkBox_AutoCenterX.Checked;
            textInfo.AutoCenterY = checkBox_AutoCenterY.Checked;

            textInfo.ResolutionIndex = (RESOLUTION_INDEX)comboBox_Resolution.SelectedIndex;
            switch (textInfo.ResolutionIndex)
            {
                case RESOLUTION_INDEX.NONE:
                    textInfo.ImageSizeX = ImageCommon.ResolutionDic[RESOLUTION_INDEX.NONE].Width;
                    textInfo.ImageSizeY = ImageCommon.ResolutionDic[RESOLUTION_INDEX.NONE].Height;
                    break;
                case RESOLUTION_INDEX.MANUAL:
                    //なにもしない
                    break;
                case RESOLUTION_INDEX.VGA:
                    textInfo.ImageSizeX = ImageCommon.ResolutionDic[RESOLUTION_INDEX.VGA].Width;
                    textInfo.ImageSizeY = ImageCommon.ResolutionDic[RESOLUTION_INDEX.VGA].Height;
                    break;
                case RESOLUTION_INDEX.SDTB:
                    textInfo.ImageSizeX = ImageCommon.ResolutionDic[RESOLUTION_INDEX.SDTB].Width;
                    textInfo.ImageSizeY = ImageCommon.ResolutionDic[RESOLUTION_INDEX.SDTB].Height;
                    break;
                case RESOLUTION_INDEX.HDTV:
                    textInfo.ImageSizeX = ImageCommon.ResolutionDic[RESOLUTION_INDEX.HDTV].Width;
                    textInfo.ImageSizeY = ImageCommon.ResolutionDic[RESOLUTION_INDEX.HDTV].Height;
                    break;
                case RESOLUTION_INDEX.FHD_2K:
                    textInfo.ImageSizeX = ImageCommon.ResolutionDic[RESOLUTION_INDEX.FHD_2K].Width;
                    textInfo.ImageSizeY = ImageCommon.ResolutionDic[RESOLUTION_INDEX.FHD_2K].Height;
                    break;
                case RESOLUTION_INDEX.WQHD:
                    textInfo.ImageSizeX = ImageCommon.ResolutionDic[RESOLUTION_INDEX.WQHD].Width;
                    textInfo.ImageSizeY = ImageCommon.ResolutionDic[RESOLUTION_INDEX.WQHD].Height;
                    break;
                case RESOLUTION_INDEX.UHD_4K:
                    textInfo.ImageSizeX = ImageCommon.ResolutionDic[RESOLUTION_INDEX.UHD_4K].Width;
                    textInfo.ImageSizeY = ImageCommon.ResolutionDic[RESOLUTION_INDEX.UHD_4K].Height;
                    break;
            }


            textInfo.DecorationDic[0] = new DecorationInfo();
            textInfo.DecorationDic[0].Thick = (int)numericUpDown_Size01.Value; //縁取り１太さ
            textInfo.DecorationDic[0].Color = new SerializableColor(button_Color01.BackColor); //縁取り１色

            textInfo.DecorationDic[1] = new DecorationInfo();
            textInfo.DecorationDic[1].Thick = (int)numericUpDown_Size02.Value; //縁取り２太さ
            textInfo.DecorationDic[1].Color = new SerializableColor(button_Color02.BackColor); //縁取り２色

            if (textInfo.ImageSizeX != 0 && textInfo.ImageSizeY != 0)
            {
                EnableOffsetControls(idx, true);
            }
            else
            {
                EnableOffsetControls(idx, false);
            }


            foreach (Control ctrl in groupBox_BackColor.Controls)
            {
                // コントロールがRadioButtonかどうかを判定する
                if (ctrl is RadioButton)
                {
                    // ラジオボタンの場合の処理
                    RadioButton rb = ctrl as RadioButton; // as演算子で型変換する
                    switch (rb.Tag)
                    {
                        case "WHITE":
                            if (rb.Checked) { textInfo.SelectedBackColor = TextInfo.BACK_COLOR.WHITE; }
                            break;
                        case "BLACK":
                            if (rb.Checked) { textInfo.SelectedBackColor = TextInfo.BACK_COLOR.BLACK; }
                            break;
                        case "OTHER":
                            if (rb.Checked) { textInfo.SelectedBackColor = TextInfo.BACK_COLOR.OTHER; }
                            break;
                        default:
                            textInfo.SelectedBackColor = TextInfo.BACK_COLOR.WHITE;
                            break;
                    }

                }
            }

            textInfo.BackColor = new SerializableColor(button_BackColor.BackColor); //サンプル背景色

            PM.AsProject.Settings.TextInfoDic[idx] = textInfo;

            PM.AsProject.SaveData();
        }

        public void EnableOffsetControls(int idx, bool enable)
        {
            if (enable)
            {
                checkBox_AutoCenterX.Enabled = enable;
                checkBox_AutoCenterY.Enabled = enable;

                panel_BasePointX.Enabled = !PM.AsProject.Settings.TextInfoDic[idx].AutoCenterX;
                numericUpDown_OffsetX.Enabled = !PM.AsProject.Settings.TextInfoDic[idx].AutoCenterX;

                panel_BasePointY.Enabled = !PM.AsProject.Settings.TextInfoDic[idx].AutoCenterY;
                numericUpDown_OffsetY.Enabled = !PM.AsProject.Settings.TextInfoDic[idx].AutoCenterY;

            }
            else
            {
                panel_BasePointX.Enabled = enable;
                numericUpDown_OffsetX.Enabled = enable;
                checkBox_AutoCenterX.Enabled = enable;

                panel_BasePointY.Enabled = enable;
                numericUpDown_OffsetY.Enabled = enable;
                checkBox_AutoCenterY.Enabled = enable;

            }

        }


        public void UpdateUiValues()
        {
            comboBox_Project.Items.Clear();
            comboBox_Project.Items.AddRange(PM.GetProjectList().ToArray());
            comboBox_Project.Text = PM.AsProject.Settings.Name;
            SetTextSetListViewItems();

            var idx = PM.AsProject.Settings.SelectedTextIndex;
            var textInfo = PM.AsProject.Settings.TextInfoDic[idx];
            //listView_TextSet.SelectedIndices.Add(idx);

            //画像補正
            numericUpDown_ImageWidth.Value = textInfo.ImageSizeX;
            numericUpDown_ImageHeight.Value = textInfo.ImageSizeY;
            numericUpDown_OffsetX.Value = textInfo.OffsetX;
            numericUpDown_OffsetY.Value = textInfo.OffsetY;

            switch (textInfo.BasePointX)
            {
                case TextInfo.BASE_POINT_X.LEFT:
                    radioButton_LeftBase.Checked = true;
                    break;
                case TextInfo.BASE_POINT_X.CENTER:
                    radioButton_CenterBaseX.Checked = true;
                    break;
                case TextInfo.BASE_POINT_X.RIGHT:
                    radioButton_RightBase.Checked = true;
                    break;
            }

            switch (textInfo.BasePointY)
            {
                case TextInfo.BASE_POINT_Y.TOP:
                    radioButton_TopBase.Checked = true;
                    break;
                case TextInfo.BASE_POINT_Y.CENTER:
                    radioButton_CenterBaseY.Checked = true;
                    break;
                case TextInfo.BASE_POINT_Y.BOTTOM:
                    radioButton_BottomBase.Checked = true;
                    break;
            }

            checkBox_AutoCenterX.Checked = textInfo.AutoCenterX;
            checkBox_AutoCenterY.Checked = textInfo.AutoCenterY;
            comboBox_Resolution.SelectedIndex = (int)textInfo.ResolutionIndex;

            comboBox_Font.Text = textInfo.FontName;
            numericUpDown_FontSize.Value = textInfo.FontSize;
            checkBox_Bold.Checked = textInfo.Bold;
            checkBox_Italic.Checked = textInfo.Italic;
            checkBox_Centering.Checked = textInfo.Centering;

            textBox_InputText.Text = CatHutCommon.NormalizeNewLine(textInfo.Text);

            //装飾
            numericUpDown_Size01.Value = textInfo.DecorationDic[0].Thick;
            numericUpDown_Size02.Value = textInfo.DecorationDic[1].Thick;

            //ボタンカラー設定
            button_Color00.BackColor = textInfo.BaseColor.ToColor();
            button_Color01.BackColor = textInfo.DecorationDic[0].Color.ToColor();
            button_Color02.BackColor = textInfo.DecorationDic[1].Color.ToColor();

            //背景カラー設定
            switch (textInfo.SelectedBackColor)
            {
                case BACK_COLOR.WHITE:
                    radioButton_BackColorWhite.Checked = true;
                    break;
                case BACK_COLOR.BLACK:
                    radioButton_BackColorBlack.Checked = true;
                    break;
                case BACK_COLOR.OTHER:
                    radioButton_BackColorOther.Checked = true;
                    break;
                default:
                    radioButton_BackColorWhite.Checked = true;
                    break;
            }
            button_BackColor.BackColor = textInfo.BackColor.ToColor();

        }

        public void SetTextSetListViewItems()
        {
            var selectedIdxs = listView_TextSet.SelectedIndices.OfType<int>().ToList();
            var preItemCount = listView_TextSet.Items.Count;
            //var forcusedIdx = listView_TextSet.FocusedItem.Index;

            listView_TextSet.Items.Clear();
            var i = 0;
            foreach (var temp in PM.AsProject.Settings.TextInfoDic)
            {
                ListViewItem item = new ListViewItem();
                item.Text = temp.Key.ToString("D4");
                item.SubItems.Add(temp.Value.Text);

                //foreach(var val in selectedIdxs)
                //{
                //    if(i == val) { item.Selected = true; break; }
                //}

                listView_TextSet.Items.Add(item);

                i++;
            }

            if (listView_TextSet.Items.Count == preItemCount)
            {
                foreach (var temp in selectedIdxs)
                {
                    listView_TextSet.SelectedIndices.Add(temp);
                }
            }
            else
            {
                var idx = PM.AsProject.Settings.SelectedTextIndex;
                listView_TextSet.SelectedIndices.Add(idx);
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

            //フォルダに格納されているフォントを追加
            var pfc = GetFontsFromFolder();
            foreach (var temp in pfc.Families)
            {
                FontFamilyDic[temp.Name] = temp;
            }

            //インストールされているフォントを追加
            foreach (var temp in FontFamily.Families)
            {
                FontFamilyDic[temp.Name] = temp;
            }

            return FontFamilyDic;

        }

        /// <summary>
        /// Fontsフォルダ内を再帰探索し、フォントファミリとして取得可能なTTF、OTF、CFF、EOTファイルを 
        /// PrivateFontCollection として取得する関数
        /// </summary>
        /// <returns>PrivateFontCollection</returns>
        private PrivateFontCollection GetFontsFromFolder()
        {
            // PrivateFontCollectionオブジェクトを作成
            PrivateFontCollection collection = new PrivateFontCollection();

            var folder = @".\Font";

            // フォルダ内のすべてのTTF、OTF、CFF、EOTファイルを取得
            string[] files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);

            // 各ファイルに対して
            foreach (string file in files)
            {
                // ファイルの拡張子を取得（小文字に変換）
                string extension = Path.GetExtension(file).ToLower();

                // 拡張子がTTF、OTF、CFF、EOTのいずれかであれば
                if (extension == ".ttf" || extension == ".otf" || extension == ".cff" || extension == ".eot")
                {
                    // ファイルからフォントを追加
                    collection.AddFontFile(file);
                }
            }

            // PrivateFontCollectionオブジェクトを返す
            return collection;
        }

        private void button_Up_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                if (listView_TextSet.SelectedItems.Count > 0)
                {
                    var idx = PM.AsProject.Settings.SelectedTextIndex;
                    var ret = SwapDictionaryIndex(idx, true);

                    if (ret) { 
                        PM.AsProject.Settings.SelectedTextIndex = idx - 1;
                        listView_TextSet.SelectedIndices.Clear();
                        listView_TextSet.SelectedIndices.Add(PM.AsProject.Settings.SelectedTextIndex);
                    }


                    UpdateUiValues();
                }
            }
            EventEnable = true;
        }

        /// <summary>
        /// Dictionaryのスワップ
        /// </summary>
        /// <param name="idx">入れ替え対象のidx</param>
        /// <param name="isUp">true:上と入れ替える、false:下と入れ替える。</param>
        /// <returns>true:処理実施、false:処理実施せず</returns>
        private bool SwapDictionaryIndex(int idx, bool isUp)
        {
            int key1 = idx;
            int key2;
            if (isUp) // isUpがtrueの場合はidx-1と入れ替える
            {
                key2 = idx - 1;
                if (key2 < 0){ return false; } // key2が0未満の場合は処理しない
            }
            else // isUpがfalseの場合はidx+1と入れ替える
            {
                key2 = idx + 1;
                if (!PM.AsProject.Settings.TextInfoDic.ContainsKey(key2)) { return false; }
            }

            var temp = PM.AsProject.Settings.TextInfoDic[key1];
            PM.AsProject.Settings.TextInfoDic[key1] = PM.AsProject.Settings.TextInfoDic[key2];
            PM.AsProject.Settings.TextInfoDic[key2] = temp;

            return true;

        }


        private void button_Down_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                if (listView_TextSet.SelectedItems.Count > 0)
                {
                    var idx = PM.AsProject.Settings.SelectedTextIndex;
                    var ret = SwapDictionaryIndex(idx, false);

                    if (ret) { 
                        PM.AsProject.Settings.SelectedTextIndex = idx + 1; 
                        listView_TextSet.SelectedIndices.Clear();
                        listView_TextSet.SelectedIndices.Add(PM.AsProject.Settings.SelectedTextIndex);
                    }

                    UpdateUiValues();
                }
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
            CommonUpdate();
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
            CommonUpdate();
        }

        private void numericUpDown_ImageWidth_ValueChanged(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                comboBox_Resolution.SelectedIndex = (int)RESOLUTION_INDEX.MANUAL;
            }
            EventEnable = true;

            CommonUpdate();
        }
        private void numericUpDown_ImageHeight_ValueChanged(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                comboBox_Resolution.SelectedIndex = (int)RESOLUTION_INDEX.MANUAL;
            }
            EventEnable = true;
            CommonUpdate();
        }

        private void comboBox_Font_SelectedValueChanged(object sender, EventArgs e)
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
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ColorDialog cd = new ColorDialog();
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    //選択された色の取得
                    var idx = PM.AsProject.Settings.SelectedTextIndex;
                    button_Color00.BackColor = cd.Color;
                }
            }
            EventEnable = true;
            CommonUpdate();
        }

        private void button_Color01_Click(object sender, EventArgs e)
        {

            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ColorDialog cd = new ColorDialog();
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    //選択された色の取得
                    var idx = PM.AsProject.Settings.SelectedTextIndex;
                    button_Color01.BackColor = cd.Color;
                }
            }
            EventEnable = true;

            CommonUpdate();
        }

        private void button_Color02_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ColorDialog cd = new ColorDialog();
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    //選択された色の取得
                    var idx = PM.AsProject.Settings.SelectedTextIndex;
                    button_Color02.BackColor = cd.Color;
                }
            }
            EventEnable = true;
            CommonUpdate();
        }

        private void checkBox_Centering_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();

        }

        private void listView_TextSet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_TextSet_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                if (listView_TextSet.FocusedItem != null)
                {
                    if (listView_TextSet.FocusedItem.Selected == true)
                    {
                        PM.AsProject.Settings.SelectedTextIndex = int.Parse(listView_TextSet.FocusedItem.Text);
                        UpdateUiValues();
                    }
                    else
                    {
                        if (listView_TextSet.SelectedItems.Count > 0)
                        {
                            PM.AsProject.Settings.SelectedTextIndex = int.Parse(listView_TextSet.SelectedItems[0].Text);
                            UpdateUiValues();
                        }
                    }
                }
            }
            EventEnable = true;

            CommonUpdate();
        }

        private void comboBox_Project_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                PM.LoadProjectByName(comboBox_Project.Text);
                UpdateUiValues();
            }
            EventEnable = true;
            CommonUpdate();
        }

        private void button_Output_Click(object sender, EventArgs e)
        {
            var list = listView_TextSet.SelectedIndices.OfType<int>().ToList();
            SaveImage(PM.AsProject.Settings.SelectedTextIndex, list);
        }

        private void button_OpenFolder_Click(object sender, EventArgs e)
        {
            var path = @"Output\" + PM.AsProject.Settings.Name;
            Process.Start("explorer.exe", path);
        }

        private void button_OutputAll_Click(object sender, EventArgs e)
        {
            foreach (var idx in PM.AsProject.Settings.TextInfoDic.Keys)
            {
                SaveImage(idx);
            }
        }

        private void radioButton_LeftBase_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void radioButton_CenterBaseX_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void radioButton_RightBase_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void radioButton_TopBase_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void radioButton_CenterBaseY_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void radioButton_BottomBase_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();
        }

        private void comboBox_Resolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                var idx = PM.AsProject.Settings.SelectedTextIndex;

                PM.AsProject.Settings.TextInfoDic[idx].ResolutionIndex = (RESOLUTION_INDEX)comboBox_Resolution.SelectedIndex;

                switch (PM.AsProject.Settings.TextInfoDic[idx].ResolutionIndex)
                {
                    case RESOLUTION_INDEX.NONE:
                        numericUpDown_ImageWidth.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.NONE].Width;
                        numericUpDown_ImageHeight.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.NONE].Height;
                        break;
                    case RESOLUTION_INDEX.MANUAL:
                        //なにもしない
                        break;
                    case RESOLUTION_INDEX.VGA:
                        numericUpDown_ImageWidth.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.VGA].Width;
                        numericUpDown_ImageHeight.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.VGA].Height;
                        break;
                    case RESOLUTION_INDEX.SDTB:
                        numericUpDown_ImageWidth.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.SDTB].Width;
                        numericUpDown_ImageHeight.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.SDTB].Height;
                        break;
                    case RESOLUTION_INDEX.HDTV:
                        numericUpDown_ImageWidth.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.HDTV].Width;
                        numericUpDown_ImageHeight.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.HDTV].Height;
                        break;
                    case RESOLUTION_INDEX.FHD_2K:
                        numericUpDown_ImageWidth.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.FHD_2K].Width;
                        numericUpDown_ImageHeight.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.FHD_2K].Height;
                        break;
                    case RESOLUTION_INDEX.WQHD:
                        numericUpDown_ImageWidth.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.WQHD].Width;
                        numericUpDown_ImageHeight.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.WQHD].Height;
                        break;
                    case RESOLUTION_INDEX.UHD_4K:
                        numericUpDown_ImageWidth.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.UHD_4K].Width;
                        numericUpDown_ImageHeight.Value = ImageCommon.ResolutionDic[RESOLUTION_INDEX.UHD_4K].Height;
                        break;
                }
                ReadUiValues();
            }
            EventEnable = true;

            CommonUpdate();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                var deleteList = listView_TextSet.SelectedItems;
                var setIndex = 0;
                foreach (ListViewItem item in deleteList)
                {
                    PM.AsProject.Settings.TextInfoDic.Remove(item.Index);
                    setIndex = Math.Max(item.Index, 0);
                }

                var tempDic = new SerializableSortedDictionary<int, TextInfo>();

                //キー振り直し
                var i = 0;
                foreach (var ti in PM.AsProject.Settings.TextInfoDic)
                {
                    tempDic.Add(i++, ti.Value);
                }
                PM.AsProject.Settings.TextInfoDic = tempDic;

                setIndex = Math.Min(tempDic.Count - 1, setIndex);
                PM.AsProject.Settings.SelectedTextIndex = setIndex;

                UpdateUiValues();

            }
            EventEnable = true;

            CommonUpdate();
        }

        private void button_Copy_Click(object sender, EventArgs e)
        {
            if (listView_TextSet.SelectedItems.Count == 0) { return; }

            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                PM.CopyText(listView_TextSet.SelectedItems[0].Index);
                UpdateUiValues();
            }
            EventEnable = true;

            CommonUpdate();

        }

        private void radioButton_BackColorWhite_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();

        }

        private void radioButton_BackColorBlack_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();

        }

        private void radioButton_BackColorOther_CheckedChanged(object sender, EventArgs e)
        {
            CommonUpdate();

        }

        private void button_BackColor_Click(object sender, EventArgs e)
        {
            if (EventEnable == false) { return; }
            EventEnable = false;
            {
                ColorDialog cd = new ColorDialog();
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    //選択された色の取得
                    button_BackColor.BackColor = cd.Color;
                    radioButton_BackColorOther.Select();
                }
            }
            EventEnable = true;
            CommonUpdate();
        }
    }
}