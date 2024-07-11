using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labo_DAL.Repositories
{
    public interface IUserRepo
    {
        List<User_DB> GetAll();

        User_DB GetById(int id);
        string GetHashPwd(string Email);
        User_DB Login(string Email, string PassWord);
        void Register(string Name, string FirstName, string Email, string Password, string Pseudo);
        void Update(User_DB user);
        void UpdateIsAdmin(int id);


    }
}
