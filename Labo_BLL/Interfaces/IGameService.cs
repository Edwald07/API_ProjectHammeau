using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_BLL.Interfaces
{
    public interface IGameService
    {
        int Create(Games gm);
        void ValidGame(int GameID);
        bool CheckIsPlayed(int GameID);
        void EndGame(int GameID);
        void ReloadGame(int GameID);
        void QuitGame(int GameID);
    }
}
