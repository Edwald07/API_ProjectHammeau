using Labo_BLL.Interfaces;
using Labo_DAL.Repositories;
using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_BLL.Services
{
    public class RolesService : IRolesService
    {
        private readonly IRoleRepo _RoleRepo;
        public RolesService(IRoleRepo roleRepo)
        {
            _RoleRepo = roleRepo;
        }
        public Roles GetById(int id)
        {
            return _RoleRepo.GetById(id);
        }
        public List<Roles> GetAll()
        {
            return _RoleRepo.GetAll();
        }
    }
}
