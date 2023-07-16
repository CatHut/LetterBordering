namespace LetterBordering
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox_Preview = new PictureBox();
            textBox_InputText = new TextBox();
            listView_TextSet = new ListView();
            columnHeader_No = new ColumnHeader();
            columnHeader_Text = new ColumnHeader();
            button_Create = new Button();
            button_Delete = new Button();
            comboBox_Project = new ComboBox();
            splitContainer1 = new SplitContainer();
            button_CreateProject = new Button();
            splitContainer2 = new SplitContainer();
            button_OpenFolder = new Button();
            button_Output = new Button();
            button_OutputAll = new Button();
            button_Up = new Button();
            button_Down = new Button();
            splitContainer3 = new SplitContainer();
            checkBox_Centering = new CheckBox();
            groupBox_ImageSize = new GroupBox();
            groupBox_Offset = new GroupBox();
            checkBox_CenterBaseY = new CheckBox();
            checkBox_CenterBaseX = new CheckBox();
            checkBox_AutoCenterY = new CheckBox();
            checkBox_AutoCenterX = new CheckBox();
            label_OffsetY = new Label();
            label_OffsetX = new Label();
            numericUpDown_OffsetX = new NumericUpDown();
            numericUpDown_OffsetY = new NumericUpDown();
            button_ImageSizeClear = new Button();
            numericUpDown_ImageWidth = new NumericUpDown();
            numericUpDown_ImageHeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            button_Color00 = new Button();
            comboBox_Font = new ComboBox();
            checkBox_Bold = new CheckBox();
            checkBox_Italic = new CheckBox();
            button_Color01 = new Button();
            button_Color02 = new Button();
            numericUpDown_FontSize = new NumericUpDown();
            numericUpDown_Size01 = new NumericUpDown();
            numericUpDown_Size02 = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            label_StringImageSize = new Label();
            label_ImageSize = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Preview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            groupBox_ImageSize.SuspendLayout();
            groupBox_Offset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_OffsetX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_OffsetY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ImageWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ImageHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_FontSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Size01).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Size02).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_Preview
            // 
            pictureBox_Preview.BorderStyle = BorderStyle.FixedSingle;
            pictureBox_Preview.Location = new Point(10, 75);
            pictureBox_Preview.Name = "pictureBox_Preview";
            pictureBox_Preview.Size = new Size(480, 270);
            pictureBox_Preview.TabIndex = 1;
            pictureBox_Preview.TabStop = false;
            // 
            // textBox_InputText
            // 
            textBox_InputText.AcceptsReturn = true;
            textBox_InputText.Location = new Point(13, 237);
            textBox_InputText.Multiline = true;
            textBox_InputText.Name = "textBox_InputText";
            textBox_InputText.Size = new Size(452, 110);
            textBox_InputText.TabIndex = 2;
            textBox_InputText.Text = "テスト文字\r\nabcdefghijklmn\r\n漢字\r\nひらがな\r\nカタカナ\r\nﾊﾝｶｸﾓｼﾞ";
            textBox_InputText.TextChanged += textBox_InputText_TextChanged;
            // 
            // listView_TextSet
            // 
            listView_TextSet.Columns.AddRange(new ColumnHeader[] { columnHeader_No, columnHeader_Text });
            listView_TextSet.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView_TextSet.Location = new Point(13, 49);
            listView_TextSet.Name = "listView_TextSet";
            listView_TextSet.Size = new Size(149, 396);
            listView_TextSet.TabIndex = 3;
            listView_TextSet.UseCompatibleStateImageBehavior = false;
            listView_TextSet.View = View.Details;
            listView_TextSet.SelectedIndexChanged += listView_TextSet_SelectedIndexChanged;
            listView_TextSet.Click += listView_TextSet_Click;
            // 
            // columnHeader_No
            // 
            columnHeader_No.Text = "No";
            // 
            // columnHeader_Text
            // 
            columnHeader_Text.Text = "Text";
            columnHeader_Text.Width = 120;
            // 
            // button_Create
            // 
            button_Create.Location = new Point(13, 20);
            button_Create.Name = "button_Create";
            button_Create.Size = new Size(67, 23);
            button_Create.TabIndex = 4;
            button_Create.Text = "作成";
            button_Create.UseVisualStyleBackColor = true;
            button_Create.Click += button_Create_Click;
            // 
            // button_Delete
            // 
            button_Delete.Location = new Point(94, 20);
            button_Delete.Name = "button_Delete";
            button_Delete.Size = new Size(68, 23);
            button_Delete.TabIndex = 5;
            button_Delete.Text = "削除";
            button_Delete.UseVisualStyleBackColor = true;
            // 
            // comboBox_Project
            // 
            comboBox_Project.FormattingEnabled = true;
            comboBox_Project.Location = new Point(12, 22);
            comboBox_Project.Name = "comboBox_Project";
            comboBox_Project.Size = new Size(177, 23);
            comboBox_Project.TabIndex = 6;
            comboBox_Project.SelectedValueChanged += comboBox_Project_SelectedValueChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button_CreateProject);
            splitContainer1.Panel1.Controls.Add(comboBox_Project);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1184, 633);
            splitContainer1.SplitterDistance = 64;
            splitContainer1.TabIndex = 7;
            // 
            // button_CreateProject
            // 
            button_CreateProject.Location = new Point(204, 22);
            button_CreateProject.Name = "button_CreateProject";
            button_CreateProject.Size = new Size(75, 23);
            button_CreateProject.TabIndex = 7;
            button_CreateProject.Text = "新規作成";
            button_CreateProject.UseVisualStyleBackColor = true;
            button_CreateProject.Click += button_CreateProject_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(button_OpenFolder);
            splitContainer2.Panel1.Controls.Add(button_Output);
            splitContainer2.Panel1.Controls.Add(button_OutputAll);
            splitContainer2.Panel1.Controls.Add(button_Create);
            splitContainer2.Panel1.Controls.Add(listView_TextSet);
            splitContainer2.Panel1.Controls.Add(button_Delete);
            splitContainer2.Panel1.Controls.Add(button_Up);
            splitContainer2.Panel1.Controls.Add(button_Down);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(1184, 565);
            splitContainer2.SplitterDistance = 200;
            splitContainer2.TabIndex = 30;
            // 
            // button_OpenFolder
            // 
            button_OpenFolder.Location = new Point(13, 490);
            button_OpenFolder.Name = "button_OpenFolder";
            button_OpenFolder.Size = new Size(75, 23);
            button_OpenFolder.TabIndex = 32;
            button_OpenFolder.Text = "出力先開く";
            button_OpenFolder.UseVisualStyleBackColor = true;
            // 
            // button_Output
            // 
            button_Output.Location = new Point(13, 461);
            button_Output.Name = "button_Output";
            button_Output.Size = new Size(75, 23);
            button_Output.TabIndex = 31;
            button_Output.Text = "画像出力";
            button_Output.UseVisualStyleBackColor = true;
            // 
            // button_OutputAll
            // 
            button_OutputAll.Location = new Point(94, 461);
            button_OutputAll.Name = "button_OutputAll";
            button_OutputAll.Size = new Size(75, 23);
            button_OutputAll.TabIndex = 30;
            button_OutputAll.Text = "全画像出力";
            button_OutputAll.UseVisualStyleBackColor = true;
            // 
            // button_Up
            // 
            button_Up.Location = new Point(168, 169);
            button_Up.Name = "button_Up";
            button_Up.Size = new Size(26, 53);
            button_Up.TabIndex = 14;
            button_Up.Text = "▲";
            button_Up.UseVisualStyleBackColor = true;
            button_Up.Click += button_Up_Click;
            // 
            // button_Down
            // 
            button_Down.Location = new Point(168, 238);
            button_Down.Name = "button_Down";
            button_Down.Size = new Size(26, 53);
            button_Down.TabIndex = 15;
            button_Down.Text = "▼";
            button_Down.UseVisualStyleBackColor = true;
            button_Down.Click += button_Down_Click;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(checkBox_Centering);
            splitContainer3.Panel1.Controls.Add(groupBox_ImageSize);
            splitContainer3.Panel1.Controls.Add(button_Color00);
            splitContainer3.Panel1.Controls.Add(textBox_InputText);
            splitContainer3.Panel1.Controls.Add(comboBox_Font);
            splitContainer3.Panel1.Controls.Add(checkBox_Bold);
            splitContainer3.Panel1.Controls.Add(checkBox_Italic);
            splitContainer3.Panel1.Controls.Add(button_Color01);
            splitContainer3.Panel1.Controls.Add(button_Color02);
            splitContainer3.Panel1.Controls.Add(numericUpDown_FontSize);
            splitContainer3.Panel1.Controls.Add(numericUpDown_Size01);
            splitContainer3.Panel1.Controls.Add(numericUpDown_Size02);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(label4);
            splitContainer3.Panel2.Controls.Add(pictureBox_Preview);
            splitContainer3.Panel2.Controls.Add(label3);
            splitContainer3.Panel2.Controls.Add(label_StringImageSize);
            splitContainer3.Panel2.Controls.Add(label_ImageSize);
            splitContainer3.Size = new Size(980, 565);
            splitContainer3.SplitterDistance = 480;
            splitContainer3.TabIndex = 31;
            // 
            // checkBox_Centering
            // 
            checkBox_Centering.AutoSize = true;
            checkBox_Centering.Location = new Point(120, 212);
            checkBox_Centering.Name = "checkBox_Centering";
            checkBox_Centering.Size = new Size(80, 19);
            checkBox_Centering.TabIndex = 30;
            checkBox_Centering.Text = "センタリング";
            checkBox_Centering.UseVisualStyleBackColor = true;
            checkBox_Centering.CheckedChanged += checkBox_Centering_CheckedChanged;
            // 
            // groupBox_ImageSize
            // 
            groupBox_ImageSize.Controls.Add(groupBox_Offset);
            groupBox_ImageSize.Controls.Add(button_ImageSizeClear);
            groupBox_ImageSize.Controls.Add(numericUpDown_ImageWidth);
            groupBox_ImageSize.Controls.Add(numericUpDown_ImageHeight);
            groupBox_ImageSize.Controls.Add(label1);
            groupBox_ImageSize.Controls.Add(label2);
            groupBox_ImageSize.Location = new Point(13, 20);
            groupBox_ImageSize.Name = "groupBox_ImageSize";
            groupBox_ImageSize.Size = new Size(411, 154);
            groupBox_ImageSize.TabIndex = 28;
            groupBox_ImageSize.TabStop = false;
            groupBox_ImageSize.Text = "画像サイズ(0で無効)";
            // 
            // groupBox_Offset
            // 
            groupBox_Offset.Controls.Add(checkBox_CenterBaseY);
            groupBox_Offset.Controls.Add(checkBox_CenterBaseX);
            groupBox_Offset.Controls.Add(checkBox_AutoCenterY);
            groupBox_Offset.Controls.Add(checkBox_AutoCenterX);
            groupBox_Offset.Controls.Add(label_OffsetY);
            groupBox_Offset.Controls.Add(label_OffsetX);
            groupBox_Offset.Controls.Add(numericUpDown_OffsetX);
            groupBox_Offset.Controls.Add(numericUpDown_OffsetY);
            groupBox_Offset.Location = new Point(6, 51);
            groupBox_Offset.Name = "groupBox_Offset";
            groupBox_Offset.Size = new Size(386, 94);
            groupBox_Offset.TabIndex = 29;
            groupBox_Offset.TabStop = false;
            groupBox_Offset.Text = "オフセット";
            // 
            // checkBox_CenterBaseY
            // 
            checkBox_CenterBaseY.AutoSize = true;
            checkBox_CenterBaseY.Location = new Point(146, 58);
            checkBox_CenterBaseY.Name = "checkBox_CenterBaseY";
            checkBox_CenterBaseY.Size = new Size(74, 19);
            checkBox_CenterBaseY.TabIndex = 34;
            checkBox_CenterBaseY.Text = "中央基準";
            checkBox_CenterBaseY.UseVisualStyleBackColor = true;
            checkBox_CenterBaseY.CheckedChanged += checkBox_CenterBaseY_CheckedChanged;
            // 
            // checkBox_CenterBaseX
            // 
            checkBox_CenterBaseX.AutoSize = true;
            checkBox_CenterBaseX.Location = new Point(146, 30);
            checkBox_CenterBaseX.Name = "checkBox_CenterBaseX";
            checkBox_CenterBaseX.Size = new Size(74, 19);
            checkBox_CenterBaseX.TabIndex = 33;
            checkBox_CenterBaseX.Text = "中央基準";
            checkBox_CenterBaseX.UseVisualStyleBackColor = true;
            checkBox_CenterBaseX.CheckedChanged += checkBox_CenterBaseX_CheckedChanged;
            // 
            // checkBox_AutoCenterY
            // 
            checkBox_AutoCenterY.AutoSize = true;
            checkBox_AutoCenterY.Location = new Point(272, 58);
            checkBox_AutoCenterY.Name = "checkBox_AutoCenterY";
            checkBox_AutoCenterY.Size = new Size(74, 19);
            checkBox_AutoCenterY.TabIndex = 32;
            checkBox_AutoCenterY.Text = "自動中央";
            checkBox_AutoCenterY.UseVisualStyleBackColor = true;
            checkBox_AutoCenterY.CheckedChanged += checkBox_AutoCenterY_CheckedChanged;
            // 
            // checkBox_AutoCenterX
            // 
            checkBox_AutoCenterX.AutoSize = true;
            checkBox_AutoCenterX.Location = new Point(272, 30);
            checkBox_AutoCenterX.Name = "checkBox_AutoCenterX";
            checkBox_AutoCenterX.Size = new Size(74, 19);
            checkBox_AutoCenterX.TabIndex = 29;
            checkBox_AutoCenterX.Text = "自動中央";
            checkBox_AutoCenterX.UseVisualStyleBackColor = true;
            checkBox_AutoCenterX.CheckedChanged += checkBox_AutoCenterX_CheckedChanged;
            // 
            // label_OffsetY
            // 
            label_OffsetY.AutoSize = true;
            label_OffsetY.Location = new Point(10, 60);
            label_OffsetY.Name = "label_OffsetY";
            label_OffsetY.Size = new Size(14, 15);
            label_OffsetY.TabIndex = 31;
            label_OffsetY.Text = "Y";
            // 
            // label_OffsetX
            // 
            label_OffsetX.AutoSize = true;
            label_OffsetX.Location = new Point(10, 31);
            label_OffsetX.Name = "label_OffsetX";
            label_OffsetX.Size = new Size(14, 15);
            label_OffsetX.TabIndex = 30;
            label_OffsetX.Text = "X";
            // 
            // numericUpDown_OffsetX
            // 
            numericUpDown_OffsetX.Location = new Point(35, 29);
            numericUpDown_OffsetX.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_OffsetX.Name = "numericUpDown_OffsetX";
            numericUpDown_OffsetX.Size = new Size(75, 23);
            numericUpDown_OffsetX.TabIndex = 26;
            numericUpDown_OffsetX.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            numericUpDown_OffsetX.ValueChanged += numericUpDown_OffsetX_ValueChanged;
            // 
            // numericUpDown_OffsetY
            // 
            numericUpDown_OffsetY.Location = new Point(35, 58);
            numericUpDown_OffsetY.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_OffsetY.Name = "numericUpDown_OffsetY";
            numericUpDown_OffsetY.Size = new Size(75, 23);
            numericUpDown_OffsetY.TabIndex = 27;
            numericUpDown_OffsetY.Value = new decimal(new int[] { 1080, 0, 0, 0 });
            numericUpDown_OffsetY.ValueChanged += numericUpDown_OffsetY_ValueChanged;
            // 
            // button_ImageSizeClear
            // 
            button_ImageSizeClear.Location = new Point(288, 22);
            button_ImageSizeClear.Name = "button_ImageSizeClear";
            button_ImageSizeClear.Size = new Size(68, 23);
            button_ImageSizeClear.TabIndex = 19;
            button_ImageSizeClear.Text = "クリア";
            button_ImageSizeClear.UseVisualStyleBackColor = true;
            button_ImageSizeClear.Click += button_ImageSizeClear_Click;
            // 
            // numericUpDown_ImageWidth
            // 
            numericUpDown_ImageWidth.Location = new Point(31, 22);
            numericUpDown_ImageWidth.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_ImageWidth.Name = "numericUpDown_ImageWidth";
            numericUpDown_ImageWidth.Size = new Size(75, 23);
            numericUpDown_ImageWidth.TabIndex = 17;
            numericUpDown_ImageWidth.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            numericUpDown_ImageWidth.ValueChanged += numericUpDown_ImageWidth_ValueChanged;
            // 
            // numericUpDown_ImageHeight
            // 
            numericUpDown_ImageHeight.Location = new Point(163, 22);
            numericUpDown_ImageHeight.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_ImageHeight.Name = "numericUpDown_ImageHeight";
            numericUpDown_ImageHeight.Size = new Size(75, 23);
            numericUpDown_ImageHeight.TabIndex = 18;
            numericUpDown_ImageHeight.Value = new decimal(new int[] { 1080, 0, 0, 0 });
            numericUpDown_ImageHeight.ValueChanged += numericUpDown_ImageHeight_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 26);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 20;
            label1.Text = "横";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 26);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 21;
            label2.Text = "縦";
            // 
            // button_Color00
            // 
            button_Color00.Location = new Point(258, 185);
            button_Color00.Name = "button_Color00";
            button_Color00.Size = new Size(75, 23);
            button_Color00.TabIndex = 29;
            button_Color00.Text = "色変更";
            button_Color00.UseVisualStyleBackColor = true;
            button_Color00.Click += button_Color00_Click;
            // 
            // comboBox_Font
            // 
            comboBox_Font.FormattingEnabled = true;
            comboBox_Font.Location = new Point(13, 185);
            comboBox_Font.Name = "comboBox_Font";
            comboBox_Font.Size = new Size(177, 23);
            comboBox_Font.TabIndex = 7;
            comboBox_Font.Text = "Arial";
            comboBox_Font.SelectedValueChanged += comboBox_Font_SelectedValueChanged;
            // 
            // checkBox_Bold
            // 
            checkBox_Bold.AutoSize = true;
            checkBox_Bold.Location = new Point(13, 212);
            checkBox_Bold.Name = "checkBox_Bold";
            checkBox_Bold.Size = new Size(50, 19);
            checkBox_Bold.TabIndex = 8;
            checkBox_Bold.Text = "太字";
            checkBox_Bold.UseVisualStyleBackColor = true;
            checkBox_Bold.CheckedChanged += checkBox_Bold_CheckedChanged;
            // 
            // checkBox_Italic
            // 
            checkBox_Italic.AutoSize = true;
            checkBox_Italic.Location = new Point(69, 212);
            checkBox_Italic.Name = "checkBox_Italic";
            checkBox_Italic.Size = new Size(50, 19);
            checkBox_Italic.TabIndex = 9;
            checkBox_Italic.Text = "斜体";
            checkBox_Italic.UseVisualStyleBackColor = true;
            checkBox_Italic.CheckedChanged += checkBox_Italic_CheckedChanged;
            // 
            // button_Color01
            // 
            button_Color01.Location = new Point(98, 368);
            button_Color01.Name = "button_Color01";
            button_Color01.Size = new Size(75, 23);
            button_Color01.TabIndex = 10;
            button_Color01.Text = "色変更";
            button_Color01.UseVisualStyleBackColor = true;
            button_Color01.Click += button_Color01_Click;
            // 
            // button_Color02
            // 
            button_Color02.Location = new Point(98, 410);
            button_Color02.Name = "button_Color02";
            button_Color02.Size = new Size(75, 23);
            button_Color02.TabIndex = 11;
            button_Color02.Text = "色変更";
            button_Color02.UseVisualStyleBackColor = true;
            button_Color02.Click += button_Color02_Click;
            // 
            // numericUpDown_FontSize
            // 
            numericUpDown_FontSize.Location = new Point(196, 185);
            numericUpDown_FontSize.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericUpDown_FontSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_FontSize.Name = "numericUpDown_FontSize";
            numericUpDown_FontSize.Size = new Size(56, 23);
            numericUpDown_FontSize.TabIndex = 16;
            numericUpDown_FontSize.Value = new decimal(new int[] { 36, 0, 0, 0 });
            numericUpDown_FontSize.ValueChanged += numericUpDown_FontSize_ValueChanged;
            // 
            // numericUpDown_Size01
            // 
            numericUpDown_Size01.Location = new Point(13, 370);
            numericUpDown_Size01.Name = "numericUpDown_Size01";
            numericUpDown_Size01.Size = new Size(75, 23);
            numericUpDown_Size01.TabIndex = 12;
            numericUpDown_Size01.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown_Size01.ValueChanged += numericUpDown_Size01_ValueChanged;
            // 
            // numericUpDown_Size02
            // 
            numericUpDown_Size02.Location = new Point(13, 410);
            numericUpDown_Size02.Name = "numericUpDown_Size02";
            numericUpDown_Size02.Size = new Size(75, 23);
            numericUpDown_Size02.TabIndex = 13;
            numericUpDown_Size02.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown_Size02.ValueChanged += numericUpDown_Size02_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 20);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 25;
            label4.Text = "出力画像サイズ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 46);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 24;
            label3.Text = "文字部分サイズ";
            // 
            // label_StringImageSize
            // 
            label_StringImageSize.AutoSize = true;
            label_StringImageSize.Location = new Point(99, 46);
            label_StringImageSize.Name = "label_StringImageSize";
            label_StringImageSize.Size = new Size(69, 15);
            label_StringImageSize.TabIndex = 22;
            label_StringImageSize.Text = "0000 × 0000";
            // 
            // label_ImageSize
            // 
            label_ImageSize.AutoSize = true;
            label_ImageSize.Location = new Point(99, 20);
            label_ImageSize.Name = "label_ImageSize";
            label_ImageSize.Size = new Size(69, 15);
            label_ImageSize.TabIndex = 23;
            label_ImageSize.Text = "0000 × 0000";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 633);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "LetterBordering";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox_Preview).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            groupBox_ImageSize.ResumeLayout(false);
            groupBox_ImageSize.PerformLayout();
            groupBox_Offset.ResumeLayout(false);
            groupBox_Offset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_OffsetX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_OffsetY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ImageWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ImageHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_FontSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Size01).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Size02).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox_Preview;
        private TextBox textBox_InputText;
        private ListView listView_TextSet;
        private ColumnHeader columnHeader_No;
        private ColumnHeader columnHeader_Text;
        private Button button_Create;
        private Button button_Delete;
        private ComboBox comboBox_Project;
        private SplitContainer splitContainer1;
        private Button button_CreateProject;
        private ComboBox comboBox_Font;
        private Button button_Color01;
        private CheckBox checkBox_Italic;
        private CheckBox checkBox_Bold;
        private Button button_Color02;
        private NumericUpDown numericUpDown_Size02;
        private NumericUpDown numericUpDown_Size01;
        private Button button_Up;
        private Button button_Down;
        private NumericUpDown numericUpDown_FontSize;
        private Label label2;
        private Label label1;
        private Button button_ImageSizeClear;
        private NumericUpDown numericUpDown_ImageHeight;
        private NumericUpDown numericUpDown_ImageWidth;
        private Label label_StringImageSize;
        private NumericUpDown numericUpDown_OffsetY;
        private NumericUpDown numericUpDown_OffsetX;
        private Label label4;
        private Label label3;
        private Label label_ImageSize;
        private CheckBox checkBox_AutoCenterX;
        private GroupBox groupBox_ImageSize;
        private GroupBox groupBox_Offset;
        private Label label_OffsetY;
        private Label label_OffsetX;
        private CheckBox checkBox_CenterBaseY;
        private CheckBox checkBox_CenterBaseX;
        private CheckBox checkBox_AutoCenterY;
        private Button button_Color00;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button button_Output;
        private Button button_OutputAll;
        private Button button_OpenFolder;
        private CheckBox checkBox_Centering;
    }
}