using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_BLL.Interfaces
{
    public interface IUserService
    {
        List<User_DB> GetAll();
        User_DB GetById(int id);
        User_DB Login(string email, string password);
        void Register(string name, string firstname, string email, string password, string pseudo);
        void Update(User_DB user);
        void UpdateIsAdmin(int id);
    }
}
