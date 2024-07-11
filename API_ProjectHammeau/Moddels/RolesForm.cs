using System.ComponentModel.DataAnnotations;

namespace API_ProjectHammeau.Moddels
{
    public class RolesForm
    {
        [Required]
        public string Role_Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public int CategorieID { get; set; }
        [Required]
        public bool IsAlive { get; set; }
    }
}
