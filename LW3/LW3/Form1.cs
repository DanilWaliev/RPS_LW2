namespace LW3
{
    public partial class mainForm : Form
    {

        private readonly ArrayRepository arraysDB;
        public mainForm()
        {
            InitializeComponent();

            arraysDB = new ArrayRepository("MyArrays.db");
        }

        private void DBHeader_Click(object sender, EventArgs e)
        {

        }

        private void line_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            int[] numbers = input.Text.Split(',')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => int.Parse(x))
                    .ToArray();

            string arrayName = name.Text;

            arraysDB.AddArray(new ArrayData(arrayName, numbers));
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
