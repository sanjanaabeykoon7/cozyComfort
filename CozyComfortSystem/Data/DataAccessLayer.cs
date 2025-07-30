using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CozyComfortSystem.Data
{
    public class DataAccessLayer
    {
        public static SqlConnection CreateConnection()
        {
            string connectionString = @"Server=localhost;Database=cozycomfort;Trusted_Connection=True;";
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// A generic method to execute queries that don't return data (INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="command">The SqlCommand to execute.</param>
        public static void ExecuteNonQuery(SqlCommand command)
        {
            using (var connection = CreateConnection())
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// A generic method to execute queries that return a single value (e.g., COUNT, MAX, or an ID).
        /// </summary>
        /// <param name="command">The SqlCommand to execute.</param>
        /// <returns>The single value as an object.</returns>
        public static object ExecuteScalar(SqlCommand command)
        {
            using (var connection = CreateConnection())
            {
                command.Connection = connection;
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        /// A generic method to execute queries that return a set of data.
        /// </summary>
        /// <param name="command">The SqlCommand to execute.</param>
        /// <returns>A DataTable containing the results of the query.</returns>
        public static DataTable ExecuteQuery(SqlCommand command)
        {
            var dataTable = new DataTable();
            using (var connection = CreateConnection())
            {
                command.Connection = connection;
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }


        /// <summary>
        /// A generic method to execute queries that return a SqlDataReader for row-by-row processing.
        /// </summary>
        /// <param name="command">The SqlCommand to execute.</param>
        /// <returns>A SqlDataReader for reading the query results.</returns>
        public static SqlDataReader ExecuteReader(SqlCommand command)
        {
            var connection = CreateConnection();
            command.Connection = connection;
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection); // Closes connection when reader is closed
        }
    }
}