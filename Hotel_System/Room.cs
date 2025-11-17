using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hotel_System
{
    class Room
    {
        DBConnection conn = new DBConnection();

        // Get all room types
        public DataTable RoomTypeList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM rooms_type", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            return table;
        }

        // Get rooms by type and available only
        public DataTable RoomByType(int type)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM rooms WHERE type=@type AND free='YES'", conn.GetConnection());
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            return table;
        }

        // Get room type by room number
        public int GetRoomType(int number)
        {
            MySqlCommand command = new MySqlCommand("SELECT type FROM rooms WHERE number=@number", conn.GetConnection());
            command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return Convert.ToInt32(table.Rows[0][0]);
        }

        // Update room availability YES/NO
        public bool SetRoomFree(int number, string isFree)
        {
            string query = "UPDATE rooms SET free=@isFree WHERE number=@number";
            MySqlCommand command = new MySqlCommand(query, conn.GetConnection());

            command.Parameters.Add("@isFree", MySqlDbType.VarChar).Value = isFree;
            command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;

            conn.OpenConnection();
            bool success = command.ExecuteNonQuery() == 1;
            conn.CloseConnection();

            return success;
        }

        // Insert new room
        public bool InsertRoom(int number, int type, string phone, string free)
        {
            string query = "INSERT INTO rooms(number, type, phone, free) VALUES (@number, @type, @phone, @free)";
            MySqlCommand command = new MySqlCommand(query, conn.GetConnection());

            command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@free", MySqlDbType.VarChar).Value = free;

            conn.OpenConnection();
            bool success = command.ExecuteNonQuery() == 1;
            conn.CloseConnection();

            return success;
        }

        // Get all rooms
        public DataTable GetAllRooms()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM rooms", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            return table;
        }

        // Edit room data
        public bool EditRoom(int number, int type, string phone, string free)
        {
            string query = "UPDATE rooms SET type=@type, phone=@phone, free=@free WHERE number=@number";
            MySqlCommand command = new MySqlCommand(query, conn.GetConnection());

            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@free", MySqlDbType.VarChar).Value = free;
            command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;

            conn.OpenConnection();
            bool success = command.ExecuteNonQuery() == 1;
            conn.CloseConnection();

            return success;
        }

        // Delete room
        public bool RemoveRoom(int number)
        {
            string query = "DELETE FROM rooms WHERE number=@number";
            MySqlCommand command = new MySqlCommand(query, conn.GetConnection());

            command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;

            conn.OpenConnection();
            bool success = command.ExecuteNonQuery() == 1;
            conn.CloseConnection();

            return success;
        }
    }
}
