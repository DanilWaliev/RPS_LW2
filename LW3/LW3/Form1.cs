namespace LW3
{
    public partial class mainForm : Form
    {

        private readonly ArrayRepository arraysDB;
        public mainForm()
        {
            InitializeComponent();

            arraysDB = new ArrayRepository("MyArrays.db");

            LoadArraysToDataGridView();
        }

        private void sort_Click(object sender, EventArgs e)
        {
            try
            {
                int[] numbers = input.Text.Split(',')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => int.Parse(x))
                    .ToArray();

                TreeSort.Sort(numbers);
                input.Text = string.Join(", ", numbers);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите только целые числа, разделенные запятыми",
                               "Ошибка ввода",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                               "Ошибка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        // сохранение массива
        private void save_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    var arrayData = CreateArrayDataFromInputs();

                    if (arraysDB.GetAllArrays().Any(a => a.Name == arrayData.Name))
                    {
                        if (AskUserConfirmation("Массив с таким именем уже существует.\nПерезаписать его?"))
                        {
                            arraysDB.DeleteArray(name.Text);

                            arraysDB.AddArray(arrayData);
                            LoadArraysToDataGridView();
                            ClearInputs();
                        }
                            

                        return;
                    }

                    arraysDB.AddArray(arrayData);
                    LoadArraysToDataGridView();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    ShowError("Ошибка сохранения", ex);
                }
            }
        }

        // Выгрузка массивов из БД в DataGridView
        private void LoadArraysToDataGridView()
        {
            try
            {
                // Получаем все массивы из базы данных
                var allArrays = arraysDB.GetAllArrays().ToList();

                // Очищаем текущие данные
                arrays.Rows.Clear();

                // Добавляем данные в DataGridView
                foreach (var arrayData in allArrays)
                {
                    string elements = string.Join(", ", arrayData.Array.Take(10));
                    if (arrayData.Array.Length > 10)
                    {
                        elements += "...";
                    }

                    arrays.Rows.Add(
                        arrayData.Name,
                        arrayData.Size,
                        elements
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удаление массива из бд
        private void delete_Click(object sender, EventArgs e)
        {
            if (arrays.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите массив для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string arrayName = GetSelectedArrayName();

                arraysDB.DeleteArray(arrayName);
                LoadArraysToDataGridView();
                MessageBox.Show("Массив удален", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Ошибка удаления", ex);
            }
        }

        // Выгрузка массива из бд
        private void unload_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана строка (игнорируем заголовки)
            if (arrays.SelectedRows.Count == 0 || arrays.SelectedRows[0].Index < 0)
            {
                MessageBox.Show("Выберите массив для выгрузки", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Получаем имя выбранного массива
                string selectedArrayName = arrays.SelectedRows[0].Cells["arrayName"].Value.ToString()!;

                // Ищем массив в базе данных по имени
                var arrayToLoad = arraysDB.GetAllArrays()
                    .FirstOrDefault(a => a.Name == selectedArrayName);

                if (arrayToLoad != null)
                {
                    // Заполняем поля формы данными из базы
                    name.Text = arrayToLoad.Name;
                    input.Text = string.Join(", ", arrayToLoad.Array);
                }
                else
                {
                    MessageBox.Show("Выбранный массив не найден в базе данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выгрузке массива: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Нажатие на ячейку с элементами массива (выгружает выбранный массив)
        private void arrays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string arrayName = GetSelectedArrayName();
                    var array = arraysDB.GetAllArrays()
                        .FirstOrDefault(a => a.Name == arrayName);

                    if (array != null)
                    {
                        name.Text = array.Name;
                        input.Text = string.Join(", ", array.Array);
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Ошибка загрузки", ex);
                }
            }
        }



        // Вспомогательные методы:

        // Проверяет корректность ввода полей
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(input.Text))
            {
                MessageBox.Show("Введите название и элементы массива", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Возвращает массив из поля для ввода
        private ArrayData CreateArrayDataFromInputs()
        {
            int[] numbers = input.Text.Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => int.Parse(x))
                .ToArray();

            return new ArrayData(name.Text, numbers);
        }

        // Возвращает имя массива, который выбран в DataGridView arrays
        private string GetSelectedArrayName()
        {
            return arrays.SelectedRows[0].Cells["arrayName"].Value.ToString()!;
        }

        // Очищает поля для ввода
        private void ClearInputs()
        {
            name.Clear();
            input.Clear();
        }

        // Выводит текст ошибки
        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show($"{title}: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Выводит окно, которое спрашивает пользователя да или нет
        private bool AskUserConfirmation(string question, string caption = "Подтверждение")
        {
            DialogResult result = MessageBox.Show(
                question,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question); // По умолчанию выделена кнопка "Нет"

            return result == DialogResult.Yes;
        }
    }
}
