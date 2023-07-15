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
            label_ImageSize = new Label();
            label2 = new Label();
            label1 = new Label();
            button_ImageSizeClear = new Button();
            numericUpDown_ImageHeight = new NumericUpDown();
            numericUpDown_ImageWidth = new NumericUpDown();
            numericUpDown_FontSize = new NumericUpDown();
            button_Down = new Button();
            button_Up = new Button();
            numericUpDown_Size02 = new NumericUpDown();
            numericUpDown_Size01 = new NumericUpDown();
            button_Color02 = new Button();
            button_Color01 = new Button();
            checkBox_Italic = new CheckBox();
            checkBox_Bold = new CheckBox();
            comboBox_Font = new ComboBox();
            colorDialog = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Preview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ImageHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ImageWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_FontSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Size02).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Size01).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_Preview
            // 
            pictureBox_Preview.Location = new Point(862, 76);
            pictureBox_Preview.Name = "pictureBox_Preview";
            pictureBox_Preview.Size = new Size(470, 485);
            pictureBox_Preview.TabIndex = 1;
            pictureBox_Preview.TabStop = false;
            // 
            // textBox_InputText
            // 
            textBox_InputText.Location = new Point(223, 125);
            textBox_InputText.Multiline = true;
            textBox_InputText.Name = "textBox_InputText";
            textBox_InputText.Size = new Size(566, 110);
            textBox_InputText.TabIndex = 2;
            textBox_InputText.Text = "てすと漢字ｂb";
            textBox_InputText.TextChanged += textBox_InputText_TextChanged;
            // 
            // listView_TextSet
            // 
            listView_TextSet.Columns.AddRange(new ColumnHeader[] { columnHeader_No, columnHeader_Text });
            listView_TextSet.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView_TextSet.Location = new Point(12, 59);
            listView_TextSet.Name = "listView_TextSet";
            listView_TextSet.Size = new Size(149, 502);
            listView_TextSet.TabIndex = 3;
            listView_TextSet.UseCompatibleStateImageBehavior = false;
            listView_TextSet.View = View.Details;
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
            button_Create.Location = new Point(12, 30);
            button_Create.Name = "button_Create";
            button_Create.Size = new Size(67, 23);
            button_Create.TabIndex = 4;
            button_Create.Text = "作成";
            button_Create.UseVisualStyleBackColor = true;
            button_Create.Click += button_Create_Click;
            // 
            // button_Delete
            // 
            button_Delete.Location = new Point(93, 30);
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
            splitContainer1.Panel2.Controls.Add(label_ImageSize);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(button_ImageSizeClear);
            splitContainer1.Panel2.Controls.Add(numericUpDown_ImageHeight);
            splitContainer1.Panel2.Controls.Add(numericUpDown_ImageWidth);
            splitContainer1.Panel2.Controls.Add(numericUpDown_FontSize);
            splitContainer1.Panel2.Controls.Add(button_Down);
            splitContainer1.Panel2.Controls.Add(button_Up);
            splitContainer1.Panel2.Controls.Add(numericUpDown_Size02);
            splitContainer1.Panel2.Controls.Add(numericUpDown_Size01);
            splitContainer1.Panel2.Controls.Add(button_Color02);
            splitContainer1.Panel2.Controls.Add(button_Color01);
            splitContainer1.Panel2.Controls.Add(checkBox_Italic);
            splitContainer1.Panel2.Controls.Add(checkBox_Bold);
            splitContainer1.Panel2.Controls.Add(comboBox_Font);
            splitContainer1.Panel2.Controls.Add(pictureBox_Preview);
            splitContainer1.Panel2.Controls.Add(textBox_InputText);
            splitContainer1.Panel2.Controls.Add(button_Delete);
            splitContainer1.Panel2.Controls.Add(listView_TextSet);
            splitContainer1.Panel2.Controls.Add(button_Create);
            splitContainer1.Size = new Size(1358, 864);
            splitContainer1.SplitterDistance = 65;
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
            // label_ImageSize
            // 
            label_ImageSize.AutoSize = true;
            label_ImageSize.Location = new Point(862, 47);
            label_ImageSize.Name = "label_ImageSize";
            label_ImageSize.Size = new Size(69, 15);
            label_ImageSize.TabIndex = 22;
            label_ImageSize.Text = "0000 × 0000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(355, 43);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 21;
            label2.Text = "縦";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(223, 43);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 20;
            label1.Text = "横";
            // 
            // button_ImageSizeClear
            // 
            button_ImageSizeClear.Location = new Point(488, 39);
            button_ImageSizeClear.Name = "button_ImageSizeClear";
            button_ImageSizeClear.Size = new Size(68, 23);
            button_ImageSizeClear.TabIndex = 19;
            button_ImageSizeClear.Text = "クリア";
            button_ImageSizeClear.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_ImageHeight
            // 
            numericUpDown_ImageHeight.Location = new Point(380, 39);
            numericUpDown_ImageHeight.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_ImageHeight.Name = "numericUpDown_ImageHeight";
            numericUpDown_ImageHeight.Size = new Size(75, 23);
            numericUpDown_ImageHeight.TabIndex = 18;
            numericUpDown_ImageHeight.ValueChanged += numericUpDown_ImageHeight_ValueChanged;
            // 
            // numericUpDown_ImageWidth
            // 
            numericUpDown_ImageWidth.Location = new Point(248, 39);
            numericUpDown_ImageWidth.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_ImageWidth.Name = "numericUpDown_ImageWidth";
            numericUpDown_ImageWidth.Size = new Size(75, 23);
            numericUpDown_ImageWidth.TabIndex = 17;
            numericUpDown_ImageWidth.ValueChanged += numericUpDown_ImageWidth_ValueChanged;
            // 
            // numericUpDown_FontSize
            // 
            numericUpDown_FontSize.Location = new Point(418, 96);
            numericUpDown_FontSize.Name = "numericUpDown_FontSize";
            numericUpDown_FontSize.Size = new Size(56, 23);
            numericUpDown_FontSize.TabIndex = 16;
            numericUpDown_FontSize.Value = new decimal(new int[] { 36, 0, 0, 0 });
            numericUpDown_FontSize.ValueChanged += numericUpDown_FontSize_ValueChanged;
            // 
            // button_Down
            // 
            button_Down.Location = new Point(167, 287);
            button_Down.Name = "button_Down";
            button_Down.Size = new Size(26, 53);
            button_Down.TabIndex = 15;
            button_Down.Text = "▼";
            button_Down.UseVisualStyleBackColor = true;
            button_Down.Click += button_Down_Click;
            // 
            // button_Up
            // 
            button_Up.Location = new Point(167, 218);
            button_Up.Name = "button_Up";
            button_Up.Size = new Size(26, 53);
            button_Up.TabIndex = 14;
            button_Up.Text = "▲";
            button_Up.UseVisualStyleBackColor = true;
            button_Up.Click += button_Up_Click;
            // 
            // numericUpDown_Size02
            // 
            numericUpDown_Size02.Location = new Point(223, 384);
            numericUpDown_Size02.Name = "numericUpDown_Size02";
            numericUpDown_Size02.Size = new Size(75, 23);
            numericUpDown_Size02.TabIndex = 13;
            numericUpDown_Size02.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown_Size02.ValueChanged += numericUpDown_Size02_ValueChanged;
            // 
            // numericUpDown_Size01
            // 
            numericUpDown_Size01.Location = new Point(223, 285);
            numericUpDown_Size01.Name = "numericUpDown_Size01";
            numericUpDown_Size01.Size = new Size(75, 23);
            numericUpDown_Size01.TabIndex = 12;
            numericUpDown_Size01.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown_Size01.ValueChanged += numericUpDown_Size01_ValueChanged;
            // 
            // button_Color02
            // 
            button_Color02.Location = new Point(308, 384);
            button_Color02.Name = "button_Color02";
            button_Color02.Size = new Size(75, 23);
            button_Color02.TabIndex = 11;
            button_Color02.Text = "色変更";
            button_Color02.UseVisualStyleBackColor = true;
            // 
            // button_Color01
            // 
            button_Color01.Location = new Point(308, 283);
            button_Color01.Name = "button_Color01";
            button_Color01.Size = new Size(75, 23);
            button_Color01.TabIndex = 10;
            button_Color01.Text = "色変更";
            button_Color01.UseVisualStyleBackColor = true;
            // 
            // checkBox_Italic
            // 
            checkBox_Italic.AutoSize = true;
            checkBox_Italic.Location = new Point(544, 100);
            checkBox_Italic.Name = "checkBox_Italic";
            checkBox_Italic.Size = new Size(50, 19);
            checkBox_Italic.TabIndex = 9;
            checkBox_Italic.Text = "斜体";
            checkBox_Italic.UseVisualStyleBackColor = true;
            checkBox_Italic.CheckedChanged += checkBox_Italic_CheckedChanged;
            // 
            // checkBox_Bold
            // 
            checkBox_Bold.AutoSize = true;
            checkBox_Bold.Location = new Point(488, 100);
            checkBox_Bold.Name = "checkBox_Bold";
            checkBox_Bold.Size = new Size(50, 19);
            checkBox_Bold.TabIndex = 8;
            checkBox_Bold.Text = "太字";
            checkBox_Bold.UseVisualStyleBackColor = true;
            checkBox_Bold.CheckedChanged += checkBox_Bold_CheckedChanged;
            // 
            // comboBox_Font
            // 
            comboBox_Font.FormattingEnabled = true;
            comboBox_Font.Location = new Point(223, 96);
            comboBox_Font.Name = "comboBox_Font";
            comboBox_Font.Size = new Size(177, 23);
            comboBox_Font.TabIndex = 7;
            comboBox_Font.Text = "Arial";
            comboBox_Font.SelectedValueChanged += comboBox_Font_SelectedValueChanged;
            // 
            // colorDialog
            // 
            colorDialog.FullOpen = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1358, 864);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "LetterBordering";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox_Preview).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ImageHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ImageWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_FontSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Size02).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Size01).EndInit();
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
        private ColorDialog colorDialog;
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
        private Label label_ImageSize;
    }
}