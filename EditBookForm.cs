using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using System;

namespace LibraryTeamWinFormApp
{
    public partial class EditBookForm : Form
    {
        NpgsqlConnection? dbConnection;
        int bookID;
        LibraryForm libraryForm;
        public EditBookForm(NpgsqlConnection? dbConnection, int bookID, LibraryForm libraryForm)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.bookID = bookID;
            this.libraryForm = libraryForm;
        }

        private void EditBookForm_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT title, isbn FROM books WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", bookID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show($"Book with ID {bookID} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        TitleBookTextBox.Text = reader["title"].ToString();
                        ISBNBookTextBox.Text = reader["isbn"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            if(!ValidateInputs())
            {
                MessageBox.Show("Please correct the highlighted fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string sql = "UPDATE books SET title = @title, isbn = @isbn WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("title", TitleBookTextBox.Text);
                    cmd.Parameters.AddWithValue("isbn", ISBNBookTextBox.Text);
                    cmd.Parameters.AddWithValue("id", bookID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            libraryForm.UpdateBooksData();
            this.Close();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            if (!TitleBookTextBox.ValidateTextBox()) isValid = false;
            if (!ISBNBookTextBox.ValidateTextBox()) isValid = false;
            return isValid;
        }
    }
}
