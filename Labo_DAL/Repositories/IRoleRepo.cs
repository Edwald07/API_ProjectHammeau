using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_DAL.Repositories
{
    public interface IRoleRepo
    {
        List<Roles> GetAll();
        Roles GetById(int id);
    }
}
