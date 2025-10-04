using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp
{
    public partial class StartForm : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=LibraryDataBase";

        public StartForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDB();
        }

        private void ConnectToDB()
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            Console.WriteLine("���������� �������!");
            label1.Text = "���������� �������!";
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id, name, age FROM users"; // ������ �������
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }*/
    }
}
