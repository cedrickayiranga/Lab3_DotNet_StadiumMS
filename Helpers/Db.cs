using System;
using MySqlConnector;

namespace StadiumMS.Helpers
{
    public static class Db
    {
        private const string ConnectionString =
            "Server=localhost;Port=3306;Database=stadium_db;User ID=root;Password=;SslMode=None;";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static bool TestConnection(out string error)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    error = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
