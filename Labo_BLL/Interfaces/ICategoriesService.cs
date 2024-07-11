using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_BLL.Interfaces
{
    public interface ICategoriesService
    {
        IEnumerable<Categories> GetAll();
        Categories GetById(int id);
    }
}
