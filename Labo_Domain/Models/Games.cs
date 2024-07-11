using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_Domain.Models
{
    public class Games
    {
        public int GameID { get; set; }
        public DateTime DateGame { get; set; }
        public int UserNumber { get; set; }
        public bool IsPlay {  get; set; }
        public int UserID {  get; set; }


    }
}
