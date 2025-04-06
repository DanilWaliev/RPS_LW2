namespace LW3
{
    partial class mainForm
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
            inputHeader = new Label();
            input = new TextBox();
            line = new Label();
            DBHeader = new Label();
            listBox1 = new ListBox();
            save = new Button();
            sort = new Button();
            delete = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // inputHeader
            // 
            inputHeader.AutoSize = true;
            inputHeader.Font = new Font("Segoe UI", 12F);
            inputHeader.Location = new Point(16, 13);
            inputHeader.Margin = new Padding(4, 0, 4, 0);
            inputHeader.Name = "inputHeader";
            inputHeader.Size = new Size(255, 28);
            inputHeader.TabIndex = 0;
            inputHeader.Text = "Ввести / Изменить массив:";
            // 
            // input
            // 
            input.Font = new Font("Segoe UI", 12F);
            input.Location = new Point(13, 45);
            input.Margin = new Padding(4);
            input.Name = "input";
            input.Size = new Size(1021, 34);
            input.TabIndex = 1;
            // 
            // line
            // 
            line.BorderStyle = BorderStyle.Fixed3D;
            line.Location = new Point(12, 149);
            line.Margin = new Padding(3, 20, 3, 20);
            line.Name = "line";
            line.Size = new Size(1022, 2);
            line.TabIndex = 2;
            line.Click += line_Click;
            // 
            // DBHeader
            // 
            DBHeader.AutoSize = true;
            DBHeader.Location = new Point(16, 171);
            DBHeader.Name = "DBHeader";
            DBHeader.Size = new Size(129, 28);
            DBHeader.TabIndex = 3;
            DBHeader.Text = "База данных:";
            DBHeader.Click += DBHeader_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 28;
            listBox1.Location = new Point(16, 202);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(842, 424);
            listBox1.TabIndex = 4;
            // 
            // save
            // 
            save.Location = new Point(12, 86);
            save.Name = "save";
            save.Size = new Size(171, 40);
            save.TabIndex = 5;
            save.Text = "Сохранить";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // sort
            // 
            sort.Location = new Point(189, 86);
            sort.Name = "sort";
            sort.Size = new Size(171, 40);
            sort.TabIndex = 6;
            sort.Text = "Отсортировать";
            sort.UseVisualStyleBackColor = true;
            sort.Click += sort_Click;
            // 
            // delete
            // 
            delete.Location = new Point(864, 202);
            delete.Name = "delete";
            delete.Size = new Size(171, 40);
            delete.TabIndex = 7;
            delete.Text = "Удалить";
            delete.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(864, 248);
            button1.Name = "button1";
            button1.Size = new Size(171, 40);
            button1.TabIndex = 8;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 630);
            Controls.Add(button1);
            Controls.Add(delete);
            Controls.Add(sort);
            Controls.Add(save);
            Controls.Add(listBox1);
            Controls.Add(DBHeader);
            Controls.Add(line);
            Controls.Add(input);
            Controls.Add(inputHeader);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "mainForm";
            Text = "Сортировка массивов";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label inputHeader;
        private TextBox input;
        private Label line;
        private Label DBHeader;
        private ListBox listBox1;
        private Button save;
        private Button sort;
        private Button delete;
        private Button button1;
    }
}
