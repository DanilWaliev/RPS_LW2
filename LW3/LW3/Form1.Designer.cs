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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            inputHeader = new Label();
            input = new TextBox();
            line = new Label();
            DBHeader = new Label();
            save = new Button();
            sort = new Button();
            delete = new Button();
            unload = new Button();
            name = new TextBox();
            nameHeader = new Label();
            arrayDataBindingSource = new BindingSource(components);
            arrays = new DataGridView();
            arrayName = new DataGridViewTextBoxColumn();
            arraySize = new DataGridViewTextBoxColumn();
            arrayElements = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)arrayDataBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)arrays).BeginInit();
            SuspendLayout();
            // 
            // inputHeader
            // 
            inputHeader.AutoSize = true;
            inputHeader.Font = new Font("Segoe UI", 12F);
            inputHeader.Location = new Point(12, 77);
            inputHeader.Margin = new Padding(4, 0, 4, 0);
            inputHeader.Name = "inputHeader";
            inputHeader.Size = new Size(255, 28);
            inputHeader.TabIndex = 0;
            inputHeader.Text = "Ввести / Изменить массив:";
            // 
            // input
            // 
            input.Font = new Font("Segoe UI", 12F);
            input.Location = new Point(12, 103);
            input.Margin = new Padding(4);
            input.Name = "input";
            input.PlaceholderText = "Введите элементы массива через запятую";
            input.Size = new Size(843, 34);
            input.TabIndex = 1;
            // 
            // line
            // 
            line.BorderStyle = BorderStyle.Fixed3D;
            line.Location = new Point(2, 154);
            line.Margin = new Padding(3, 20, 3, 20);
            line.Name = "line";
            line.Size = new Size(1022, 2);
            line.TabIndex = 2;
            // 
            // DBHeader
            // 
            DBHeader.AutoSize = true;
            DBHeader.Location = new Point(16, 176);
            DBHeader.Name = "DBHeader";
            DBHeader.Size = new Size(129, 28);
            DBHeader.TabIndex = 3;
            DBHeader.Text = "База данных:";
            // 
            // save
            // 
            save.Location = new Point(864, 45);
            save.Name = "save";
            save.Size = new Size(171, 35);
            save.TabIndex = 5;
            save.Text = "Сохранить";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // sort
            // 
            sort.Location = new Point(864, 103);
            sort.Name = "sort";
            sort.Size = new Size(171, 34);
            sort.TabIndex = 6;
            sort.Text = "Отсортировать";
            sort.UseVisualStyleBackColor = true;
            sort.Click += sort_Click;
            // 
            // delete
            // 
            delete.Location = new Point(864, 202);
            delete.Name = "delete";
            delete.Size = new Size(171, 39);
            delete.TabIndex = 7;
            delete.Text = "Удалить";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // unload
            // 
            unload.Location = new Point(864, 247);
            unload.Name = "unload";
            unload.Size = new Size(171, 39);
            unload.TabIndex = 8;
            unload.Text = "Выгрузить";
            unload.UseVisualStyleBackColor = true;
            unload.Click += unload_Click;
            // 
            // name
            // 
            name.Location = new Point(12, 45);
            name.Name = "name";
            name.PlaceholderText = "Введите название массива";
            name.Size = new Size(844, 34);
            name.TabIndex = 9;
            // 
            // nameHeader
            // 
            nameHeader.AutoSize = true;
            nameHeader.Location = new Point(12, 9);
            nameHeader.Name = "nameHeader";
            nameHeader.Size = new Size(184, 28);
            nameHeader.TabIndex = 10;
            nameHeader.Text = "Название массива:";
            // 
            // arrayDataBindingSource
            // 
            arrayDataBindingSource.DataSource = typeof(ArrayData);
            // 
            // arrays
            // 
            arrays.AllowUserToAddRows = false;
            arrays.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            arrays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            arrays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            arrays.Columns.AddRange(new DataGridViewColumn[] { arrayName, arraySize, arrayElements });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            arrays.DefaultCellStyle = dataGridViewCellStyle6;
            arrays.Location = new Point(12, 207);
            arrays.MultiSelect = false;
            arrays.Name = "arrays";
            arrays.ReadOnly = true;
            arrays.RowHeadersWidth = 51;
            arrays.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            arrays.Size = new Size(843, 411);
            arrays.TabIndex = 11;
            arrays.CellContentClick += arrays_CellContentClick;
            // 
            // arrayName
            // 
            arrayName.HeaderText = "Название";
            arrayName.MinimumWidth = 6;
            arrayName.Name = "arrayName";
            arrayName.ReadOnly = true;
            arrayName.Width = 125;
            // 
            // arraySize
            // 
            arraySize.HeaderText = "Размер";
            arraySize.MinimumWidth = 6;
            arraySize.Name = "arraySize";
            arraySize.ReadOnly = true;
            arraySize.Width = 125;
            // 
            // arrayElements
            // 
            arrayElements.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            arrayElements.HeaderText = "Элементы массива";
            arrayElements.MinimumWidth = 6;
            arrayElements.Name = "arrayElements";
            arrayElements.ReadOnly = true;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 630);
            Controls.Add(arrays);
            Controls.Add(nameHeader);
            Controls.Add(name);
            Controls.Add(unload);
            Controls.Add(delete);
            Controls.Add(sort);
            Controls.Add(save);
            Controls.Add(DBHeader);
            Controls.Add(line);
            Controls.Add(input);
            Controls.Add(inputHeader);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "mainForm";
            Text = "Сортировка массивов";
            ((System.ComponentModel.ISupportInitialize)arrayDataBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)arrays).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label inputHeader;
        private TextBox input;
        private Label line;
        private Label DBHeader;
        private Button save;
        private Button sort;
        private Button delete;
        private Button unload;
        private TextBox name;
        private Label nameHeader;
        private BindingSource arrayDataBindingSource;
        private DataGridView arrays;
        private DataGridViewTextBoxColumn arrayName;
        private DataGridViewTextBoxColumn arraySize;
        private DataGridViewTextBoxColumn arrayElements;
    }
}
