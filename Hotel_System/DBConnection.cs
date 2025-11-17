using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_System
{
    /*
     * Handles MySQL database connection
     */
    class DBConnection
    {
        private readonly MySqlConnection _connection;

        // Constructor: setup connection string
        public DBConnection()
        {
            _connection = new MySqlConnection(
                "datasource=localhost;port=3306;username=root;password=;database=hotel_system"
            );
        }

        // Return the MySQL connection
        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        // Open database connection safely
        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                try
                {
                    _connection.Open();
                }
                catch (MySqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Database connection failed:\n" + ex.Message,
                        "Connection Error",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error
                    );
                }
            }
        }

        // Close the database connection safely
        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
