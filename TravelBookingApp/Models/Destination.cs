using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        [Display(Name = "Nom de la destination")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le pays est obligatoire")]
        [StringLength(100, ErrorMessage = "Le pays ne peut pas dépasser 100 caractères")]
        [Display(Name = "Pays")]
        public string Country { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [StringLength(200)]
        [Display(Name = "URL de l'image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public virtual ICollection<TravelPackage> TravelPackages { get; set; } = new List<TravelPackage>();
    }
}