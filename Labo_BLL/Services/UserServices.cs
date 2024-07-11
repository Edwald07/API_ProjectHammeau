using Labo_BLL.Interfaces;
using Labo_DAL.Repositories;
using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labo_BLL.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserServices(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public User_DB Login(string email, string password)
        {
            string VerifyPWD = _userRepo.GetHashPwd(email);
            if (BCrypt.Net.BCrypt.Verify(password, VerifyPWD))
            {
                try
                {
                    User_DB connectedUser = _userRepo.Login(email, VerifyPWD);
                    return connectedUser;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                throw new InvalidOperationException("Le mot de passe est presque correct");
            }
        }
        public void Register(string name, string firstname, string email, string password, string pseudo)
        {
            string hashPWD = BCrypt.Net.BCrypt.HashPassword(password);
            try
            {
                _userRepo.Register(name, firstname, email, hashPWD, pseudo);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Update(User_DB user)
        {
            _userRepo.Update(user);
        }
        public User_DB GetById(int id)
        {
            return _userRepo.GetById(id);
        }
        public List<User_DB> GetAll()
        {
            return _userRepo.GetAll();
        }
       public void UpdateIsAdmin(int id)
        {
            _userRepo.UpdateIsAdmin(id);
        }
    }
}
