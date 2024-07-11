using Labo_Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace API_ProjectHammeau.Moddels
{
    public class GamesCreateForm
    {
        [Required]
        public int GameID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<User_DB> Users { get; set; }
        [Required]
        public DateTime DateGame {  get; set; }
        [Required]
        public bool IsPlay {  get; set; }

        ////public string Status { get; set; } = string.Empty;
        //public DateTime Created { get; set; }
        //public DateTime Updated { get; set; } = DateTime.Now;
        //public GamesCreateForm()
        //{
        //    Users = new List<User>();
        //}

    }
}
