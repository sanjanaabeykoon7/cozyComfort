using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CozyComfortSystem.Models;
using CozyComfortSystem.Data;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace CozyComfortSystem.Controllers
{
    public class AdminController
    {
        // Get all users
        public List<User> GetAllUsers()
        {
            var userList = new List<User>();
            try
            {
                var command = new SqlCommand("SELECT UserID, Username, PasswordHash, Role FROM Users ORDER BY UserID");
                DataTable dt = DataAccessLayer.ExecuteQuery(command);

                foreach (DataRow row in dt.Rows)
                {
                    userList.Add(new User
                    {
                        UserID = Convert.ToInt32(row["UserID"]),
                        Username = row["Username"].ToString(),
                        PasswordHash = row["PasswordHash"].ToString(),
                        Role = row["Role"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllUsers: " + ex.Message);
            }
            return userList;
        }

        // Add a new user
        public string AddUser(User user)
        {
            try
            {
                // Check if username already exists
                var checkCommand = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username");
                checkCommand.Parameters.AddWithValue("@Username", user.Username);
                int existingCount = Convert.ToInt32(DataAccessLayer.ExecuteScalar(checkCommand));

                if (existingCount > 0)
                {
                    return "Error: Username already exists.";
                }

                // Hash the password
                string hashedPassword = HashPassword(user.PasswordHash); // Assuming PasswordHash contains plain password for new users

                // Insert new user
                var command = new SqlCommand("INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)");
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                command.Parameters.AddWithValue("@Role", user.Role);

                DataAccessLayer.ExecuteNonQuery(command);
                return "User added successfully.";
            }
            catch (Exception ex)
            {
                return "Error adding user: " + ex.Message;
            }
        }

        // Update an existing user
        public string UpdateUser(User user)
        {
            try
            {
                // Check if another user has the same username
                var checkCommand = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username AND UserID != @UserID");
                checkCommand.Parameters.AddWithValue("@Username", user.Username);
                checkCommand.Parameters.AddWithValue("@UserID", user.UserID);
                int existingCount = Convert.ToInt32(DataAccessLayer.ExecuteScalar(checkCommand));

                if (existingCount > 0)
                {
                    return "Error: Username already exists.";
                }

                string updateQuery;
                SqlCommand command;

                // Check if password is being updated (if it's not a hash, hash it)
                if (!string.IsNullOrEmpty(user.PasswordHash) && !user.PasswordHash.StartsWith("$"))
                {
                    // New password provided, hash it
                    string hashedPassword = HashPassword(user.PasswordHash);
                    updateQuery = "UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, Role = @Role WHERE UserID = @UserID";
                    command = new SqlCommand(updateQuery);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                }
                else
                {
                    // No password change, update only username and role
                    updateQuery = "UPDATE Users SET Username = @Username, Role = @Role WHERE UserID = @UserID";
                    command = new SqlCommand(updateQuery);
                }

                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@UserID", user.UserID);

                DataAccessLayer.ExecuteNonQuery(command);
                return "User updated successfully.";
            }
            catch (Exception ex)
            {
                return "Error updating user: " + ex.Message;
            }
        }

        // Delete a user
        public string DeleteUser(int userId)
        {
            try
            {
                var command = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID");
                command.Parameters.AddWithValue("@UserID", userId);

                int rowsAffected = DataAccessLayer.ExecuteNonQuery(command);

                if (rowsAffected > 0)
                {
                    return "User deleted successfully.";
                }
                else
                {
                    return "Error: User not found.";
                }
            }
            catch (Exception ex)
            {
                return "Error deleting user: " + ex.Message;
            }
        }

        // Hash password using SHA256 (simple implementation - consider using bcrypt in production)
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}