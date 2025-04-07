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
                MessageBox.Show("������� ������ ����� �����, ����������� ��������",
                               "������ �����",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}",
                               "������",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        // ���������� �������
        private void save_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    var arrayData = CreateArrayDataFromInputs();

                    if (arraysDB.GetAllArrays().Any(a => a.Name == arrayData.Name))
                    {
                        if (AskUserConfirmation("������ � ����� ������ ��� ����������.\n������������ ���?"))
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
                    ShowError("������ ����������", ex);
                }
            }
        }

        // �������� �������� �� �� � DataGridView
        private void LoadArraysToDataGridView()
        {
            try
            {
                // �������� ��� ������� �� ���� ������
                var allArrays = arraysDB.GetAllArrays().ToList();

                // ������� ������� ������
                arrays.Rows.Clear();

                // ��������� ������ � DataGridView
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
                MessageBox.Show($"������ �������� ������: {ex.Message}", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �������� ������� �� ��
        private void delete_Click(object sender, EventArgs e)
        {
            if (arrays.SelectedRows.Count == 0)
            {
                MessageBox.Show("�������� ������ ��� ��������", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string arrayName = GetSelectedArrayName();

                arraysDB.DeleteArray(arrayName);
                LoadArraysToDataGridView();
                MessageBox.Show("������ ������", "�����",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("������ ��������", ex);
            }
        }

        // �������� ������� �� ��
        private void unload_Click(object sender, EventArgs e)
        {
            // ���������, ��� ������� ������ (���������� ���������)
            if (arrays.SelectedRows.Count == 0 || arrays.SelectedRows[0].Index < 0)
            {
                MessageBox.Show("�������� ������ ��� ��������", "����������",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // �������� ��� ���������� �������
                string selectedArrayName = arrays.SelectedRows[0].Cells["arrayName"].Value.ToString()!;

                // ���� ������ � ���� ������ �� �����
                var arrayToLoad = arraysDB.GetAllArrays()
                    .FirstOrDefault(a => a.Name == selectedArrayName);

                if (arrayToLoad != null)
                {
                    // ��������� ���� ����� ������� �� ����
                    name.Text = arrayToLoad.Name;
                    input.Text = string.Join(", ", arrayToLoad.Array);
                }
                else
                {
                    MessageBox.Show("��������� ������ �� ������ � ���� ������", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� �������: {ex.Message}", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ������� �� ������ � ���������� ������� (��������� ��������� ������)
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
                    ShowError("������ ��������", ex);
                }
            }
        }



        // ��������������� ������:

        // ��������� ������������ ����� �����
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(input.Text))
            {
                MessageBox.Show("������� �������� � �������� �������", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ���������� ������ �� ���� ��� �����
        private ArrayData CreateArrayDataFromInputs()
        {
            int[] numbers = input.Text.Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => int.Parse(x))
                .ToArray();

            return new ArrayData(name.Text, numbers);
        }

        // ���������� ��� �������, ������� ������ � DataGridView arrays
        private string GetSelectedArrayName()
        {
            return arrays.SelectedRows[0].Cells["arrayName"].Value.ToString()!;
        }

        // ������� ���� ��� �����
        private void ClearInputs()
        {
            name.Clear();
            input.Clear();
        }

        // ������� ����� ������
        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show($"{title}: {ex.Message}", "������",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ������� ����, ������� ���������� ������������ �� ��� ���
        private bool AskUserConfirmation(string question, string caption = "�������������")
        {
            DialogResult result = MessageBox.Show(
                question,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question); // �� ��������� �������� ������ "���"

            return result == DialogResult.Yes;
        }
    }
}
