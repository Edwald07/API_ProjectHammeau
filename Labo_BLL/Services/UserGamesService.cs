using Labo_DAL.Repositories;
using Labo_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labo_BLL.Services
{
    public class UserGamesService //: IUserGamesService
    {
        private readonly IUserGamesRepo _userGamesRepo;
        private readonly IGamesRepo _gamesRepo;
        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _roleRepo;
        public UserGamesService(IUserGamesRepo userGamesRepo, IGamesRepo gamesRepo, IUserRepo userRepo, IRoleRepo roleRepo)
        {
            _userGamesRepo = userGamesRepo;
            _gamesRepo = gamesRepo;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }
        public UserGames GetById(int id)
        {
            return _userGamesRepo.GetById(id);
        }
        public List<UserGames> GetAll()
        {
            return _userGamesRepo.GetAll();
        }
    }
}
