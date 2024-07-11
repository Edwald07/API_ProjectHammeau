using System.ComponentModel.DataAnnotations;

namespace API_ProjectHammeau.Moddels
{
    public class UserRegisterForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
            ErrorMessage = "Doit contenir 8 caractère minimum, une majuscule et un chiffre")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Les deux mots de passe doivent correspondre")]
        public string PasswordConfirm { get; set; }
        [Required]
        public string Pseudo { get; set; }
    }
}
