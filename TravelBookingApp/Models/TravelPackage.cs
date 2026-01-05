using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public class TravelPackage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(150, ErrorMessage = "Le titre ne peut pas dépasser 150 caractères")]
        [Display(Name = "Titre du package")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "La destination est obligatoire")]
        [Display(Name = "Destination")]
        public int DestinationId { get; set; }

        [StringLength(1000, ErrorMessage = "La description ne peut pas dépasser 1000 caractères")]
        [Display(Name = "Description détaillée")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0.01, 999999.99, ErrorMessage = "Le prix doit être entre 0.01 et 999999.99")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Prix (MAD)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La durée est obligatoire")]
        [Range(1, 365, ErrorMessage = "La durée doit être entre 1 et 365 jours")]
        [Display(Name = "Durée (jours)")]
        public int Duration { get; set; }

        [StringLength(200)]
        [Display(Name = "URL de l'image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Disponible")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("DestinationId")]
        public virtual Destination? Destination { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}