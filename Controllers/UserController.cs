using System;
using MySqlConnector;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Controllers
{
    public static class UserController
    {
        private const string SelectColumns = "SELECT id, full_name, email, password_hash, is_admin, created_at FROM users ";

        public static User FindByEmail(string email)
        {
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(SelectColumns + "WHERE email = @email", conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    return ReadUser(r);
                }
            }
        }

        public static User Register(string fullName, string email, string password, bool isAdmin)
        {
            User user = new User();
            user.FullName = fullName;
            user.Email = email;
            user.PasswordHash = PasswordHasher.Hash(password);
            user.IsAdmin = isAdmin;
            user.CreatedAt = DateTime.Now;

            try
            {
                using (MySqlConnection conn = Db.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO users (full_name, email, password_hash, is_admin) VALUES (@name, @email, @hash, @admin)", conn))
                {
                    cmd.Parameters.AddWithValue("@name", user.FullName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@hash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@admin", user.IsAdmin ? 1 : 0);
                    cmd.ExecuteNonQuery();
                    user.Id = (int)cmd.LastInsertedId;
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) return null;
                throw;
            }
            return user;
        }

        public static void EnsureDefaultAdmin()
        {
            if (FindByEmail("admin@stadium.com") != null) return;
            Register("Administrator", "admin@stadium.com", "admin123", true);
        }

        private static User ReadUser(MySqlDataReader r)
        {
            User u = new User();
            u.Id = r.GetInt32(0);
            u.FullName = r.GetString(1);
            u.Email = r.GetString(2);
            u.PasswordHash = r.GetString(3);
            u.IsAdmin = r.GetBoolean(4);
            u.CreatedAt = r.GetDateTime(5);
            return u;
        }
    }
}
