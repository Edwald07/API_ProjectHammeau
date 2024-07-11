using Labo_BLL.Interfaces;
using Labo_BLL.Moddels;
using Labo_DAL.Repositories;
using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IGamesRepo _gamesRepo;
         public GameService(IGamesRepo gamesRepo)
        {
            _gamesRepo = gamesRepo;
        }

        

        public int Create(Games game)
        {
            return _gamesRepo.Create(game);
        }
        public void ValidGame(int GameID)
        {
            _gamesRepo.ValidGame(GameID);
        }
        public bool CheckIsPlayed(int GameID)
        {
            return _gamesRepo.CheckIsPlayed(GameID);
        }
        public void EndGame(int GameID)
        {
           _gamesRepo.EndGame(GameID);
        }
        public void ReloadGame(int GameID)
        {
            _gamesRepo.ReloadGame(GameID);
        }
        public void QuitGame(int GameID)
        {
            _gamesRepo.QuitGame(GameID);
        }
        //int IGameService.Create(Games gm)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
