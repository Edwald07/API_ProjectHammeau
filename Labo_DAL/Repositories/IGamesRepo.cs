using Labo_Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_DAL.Repositories
{
    public interface IGamesRepo
    {
        int Create(Games gm);
        void ValidGame(int GameID);
        bool CheckIsPlayed(int GameID);
        void EndGame(int GameID);
        void ReloadGame(int GameID);
        void QuitGame(int GameID);
        List<Games> GetAll();
        Games GetById(int id);
    }
}
