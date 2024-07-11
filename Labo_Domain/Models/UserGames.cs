using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_Domain.Models
{
    public class UserGames
    {
        public int GameUserID { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
        public int RoleID { get; set; }
    }
}
