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
    public class RoleServices : IRoleRepo
    {
        private SqlConnection _connection;
        public RoleServices(SqlConnection conn)
        {
            _connection = conn;
        }
        private Roles Converter(SqlDataReader reader)
        {
            return new Roles
            {
                RoleID = (int)reader["RoleID"],
                Role_Name = (string)reader["Name"],
                Description = (string)reader["Description"],
                Pictures = (string)reader["Image"],
                CategorieRoleID = (int)reader["CRID"]
            };
        }
        public List<Roles> GetAll()
        {
            List<Roles> list = new List<Roles>();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Roles]";
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
        public Roles GetById(int RoleID)
        {
            Roles r = new Roles();
            
                using (SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Roles] WHERE RoleID = @id";
                    command.Parameters.AddWithValue("id", RoleID);
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
    }
}
