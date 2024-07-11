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
    public class GamesServices : IGamesRepo
    {
        private SqlConnection _connection;
        public GamesServices(SqlConnection conn)
        {
            _connection = conn;
        }
        private Games Converter
            (SqlDataReader reader)
        {
            return new Games
            {
                GameID = (int)reader["GameID"],
                DateGame = (DateTime)reader["DateGame"],
                UserNumber = (int)reader["UserNumber"],
                UserID = (int)reader["UserID"]
            };
        }
        public void Create(Games gm)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Games (GameID, DateGame, UserNumber, UserID) output inserted.GameID " +"VALUES (@DtGm, @UN)";

                cmd.Parameters.AddWithValue("DtGm", gm.DateGame);
                cmd.Parameters.AddWithValue("UN", gm.UserNumber);

                _connection.Open();
                int ID = (int)cmd.ExecuteScalar();
                _connection.Close();
            }
        }
        public void ValidGame(int GameID)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Games SET IsPlay = 1 WHERE GameID = @GameID";
                cmd.Parameters.AddWithValue("GameID", GameID);
                _connection.Open ();
                cmd.ExecuteNonQuery();
                _connection.Close ();
            }
        }
        public bool CheckIsPlayed (int GameID)
        {
            using (SqlCommand cmd = _connection.CreateCommand ())
            {
                cmd.CommandText = "SELECT IsPlay FROM Games WHERE GameID = @GameID";
                cmd.Parameters.AddWithValue("GameID", GameID);
                _connection.Open();
                bool check = (bool)cmd.ExecuteScalar();
                _connection.Close () ;
                return check;
            }
        }
        public void EndGame (int GameID)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Games SET IsPlay = 0 WHERE GameID = @GameID";
                cmd.Parameters.AddWithValue("GameID", GameID);
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
        public void ReloadGame (int GameID)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Games SET IsPlay = 0 WHERE GameID = @GameID";
                cmd.Parameters.AddWithValue("GameID", GameID);
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
        public void QuitGame (int GameID)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "DELETE Games SET IsPlay = 0 WHERE GameID = @GameID";
                cmd.Parameters.AddWithValue("GameID", GameID);
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
        public List<Games> GetAll()
        {
            List<Games> list = new List<Games>();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Games]";
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
        public Games GetById(int GameID)
        {
            Games r = new Games();

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Games] WHERE GameID = @id";
                command.Parameters.AddWithValue("id", GameID);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        r = Converter(reader);
                    }
                }
                _connection.Close();
            }

            return r;
        }

        int IGamesRepo.Create(Games gm)
        {
            throw new NotImplementedException();
        }
    }
}
