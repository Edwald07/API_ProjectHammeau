using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_Domain.Models
{
    public class Roles
    {
        public int RoleID { get; set; }
        public string Role_Name { get; set; }
        public string Description { get; set; }
        public string Pictures { get; set; }
        public int CategorieRoleID { get; set; }
        public bool IsAlive { get; set; }

    }
}
