using API_ProjectHammeau.Moddels;
using Labo_Domain.Models;

namespace API_ProjectHammeau.Tools
{
    public static class Mappers
    {
        public static User_DB ToDOMAIN(this UserRegisterForm form)
        {
            return new User_DB
            {
                Name = form.Name,
                FirstName = form.FirstName,
                Email = form.Email,
                Password = form.Password,
                Pseudo = form.Pseudo,
            };
        }
        public static User_DB ToDOMAIN(this UserUpdateForm form)
        {
            return new User_DB
            {
                Pseudo = form.Pseudo,
            };
        }
        public static Games ToDOMAIN(this GamesCreateForm form)
        {
            return new Games
            {
                GameID = form.GameID,
                DateGame = form.DateGame,
                UserNumber = form.Users.Count,
                IsPlay = form.IsPlay,
                
            };
        }
    }
}
