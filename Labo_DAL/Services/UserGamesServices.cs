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
    public class UserGamesServices : IUserGamesRepo
    {
        private SqlConnection _connection;
        public UserGamesServices(SqlConnection conn)
        {
            _connection = conn;
        }
        private UserGames Converter(SqlDataReader reader)
        {
            return new UserGames
            {
                GameUserID = (int)reader["GamesUserID"],
                UserID = (int)reader["UserID"],
                GameID = (int)reader["GameID"],
                RoleID = (int)reader["RoleID"],
            };
        }
        public List<UserGames> GetAll()
        {
            List<UserGames> list = new List<UserGames>();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [UserGames]";
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
        public UserGames GetById(int GameUserID)
        {
            UserGames ug = new UserGames();
            using (SqlConnection connection = _connection)
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [User] WHERE GameUserID = @id";
                    command.Parameters.AddWithValue("id", GameUserID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ug = Converter(reader);
                        }
                    }
                    connection.Close();
                }
            }
            return ug;
        }
    }
}
