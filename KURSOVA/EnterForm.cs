using Kursova.utils;

namespace Kursova
{
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        private async void EnterButton_Click(object sender, EventArgs e)
        {
            string connectionString = $"Server=localhost;Port=5432;Database=carshop;User Id={textBox1.Text};Password={textBox2.Text}";

            try
            {
                var conn = await DatabaseConnector.OpenConnectionAsync(connectionString);
                if (conn != null)
                {
                    MainForm mainForm = new MainForm(conn, connectionString);
                    this.Hide();
                    mainForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Не вдалося підключитися до бази даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при вході у систему: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
