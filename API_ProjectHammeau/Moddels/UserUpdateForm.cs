using System.ComponentModel.DataAnnotations;

namespace API_ProjectHammeau.Moddels
{
    public class UserUpdateForm
    {
        [Required]
        public string Pseudo {  get; set; }
    }
}
