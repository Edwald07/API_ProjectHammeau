using Labo_DAL.Repositories;
using Labo_Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_DAL.Services
{
    public class UserService : IUserRepo
    {
        private SqlConnection _connection;
        public UserService(SqlConnection conn)
        {
            _connection = conn;
        }
        public void Register(string name, string firstname, string email, string password, string pseudo)
        {
            
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    string sql = "INSERT INTO  [User_DB] (Name, Firstname, Email, Password, Pseudo)"
                +
                        "VALUES (@name, @firstname, @email,  @password, @pseudo)";
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("firstname", firstname);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("password", password);
                    cmd.Parameters.AddWithValue("pseudo", pseudo);
                _connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                _connection.Close();
                }
            
        }
        public User_DB Login(string email, string password)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT UserID, Email, IsAdmin"
             + " FROM [User_DB] WHERE Email = @email AND Password = @pwd";
                cmd.Parameters.AddWithValue ("email", email);
                cmd.Parameters.AddWithValue("pwd", password);
             _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User_DB
                        {
                            UserID = (int)reader["UserID"],
                            Email = (string)reader["Email"],
                            IsAdmin = (bool)reader["IsAdmin"]

                        };
                    }
                    else throw new InvalidOperationException("Tu n'existes pas");
                }
            }
        }
        public string GetHashPwd(string email)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT Password FROM [User_DB] WHERE Email = @email";
                _connection.Open ();
                cmd.Parameters.AddWithValue ("email", email);
                string pwd = (string)cmd.ExecuteScalar();
                _connection.Close();
                return pwd;
            }
        }
        private User_DB Converter(SqlDataReader reader)
        {
            return new User_DB
            {
                UserID = (int)reader["UserID"],
                Name = (string)reader["Name"],
                FirstName = (string)reader["FirstName"],
                Email = (string)reader["Email"],
                IsAdmin = (bool)reader["IsAdmin"],
                Pseudo = (string)reader["Pseudo"]
            };
        }
        public List<User_DB> GetAll()
        {
            List<User_DB> list = new List<User_DB>();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [User_DB]";
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Converter(reader));
                    }
                }
                _connection.Close();
            }
            return list;
        }
        public User_DB GetById(int UserID)
        {
            User_DB u = new User_DB();
            
                using (SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [User_DB] WHERE UserID = @id";
                    command.Parameters.AddWithValue("id", UserID);
                _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            u = Converter(reader);
                        }
                    }
                _connection.Close();
                }
            
            return u;
        }
        public void Update(User_DB user)
        {
            
                using(SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [User_DB] SET Pseudo = @pseudo WHERE UserId = @id";

                    command.Parameters.AddWithValue("id", user.UserID);
                    command.Parameters.AddWithValue("pseudo", user.Pseudo);
                _connection.Open();
                    command.ExecuteNonQuery();
                _connection.Close();
                }
            
        }
        public void UpdateIsAdmin(int id)
        {

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE [User_DB] SET IsAdmin = 1 WHERE UserId = @id";

                command.Parameters.AddWithValue("id", id);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

        }

    }
}
