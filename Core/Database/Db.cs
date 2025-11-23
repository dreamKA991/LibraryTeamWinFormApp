using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp.Core.Database
{
    public static class Db
    {
        public static NpgsqlConnection? Connection { get; private set; }

        // Сделайте ConnectionString публичной
        public static string ConnectionString { get; } = "Host=localhost;Port=5432;Username=postgres;Password=1;Database=test;Encoding=UTF8";

        public static void Init()
        {
            if (Connection != null)
                return;

            Connection = new NpgsqlConnection(ConnectionString);

            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                ShowError($"Помилка підключення до БД: {ex.Message}");
            }
        }

        public static bool ValidateConnection()
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                ShowError("Немає підключення до бази даних!");
                return false;
            }

            return true;
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}