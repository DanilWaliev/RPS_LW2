namespace LW3
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
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
    }
}
