using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public enum BookingStatus
    {
        [Display(Name = "En attente")]
        EnAttente,
        [Display(Name = "Confirmée")]
        Confirmee,
        [Display(Name = "Annulée")]
        Annulee
    }

    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Utilisateur")]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le package est obligatoire")]
        [Display(Name = "Package de voyage")]
        public int PackageId { get; set; }

        [Required]
        [Display(Name = "Date de réservation")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La date de début est obligatoire")]
        [Display(Name = "Date de début du voyage")]
        [DataType(DataType.Date)]
        public DateTime TravelStartDate { get; set; }

        [Required(ErrorMessage = "Le nombre de personnes est obligatoire")]
        [Range(1, 50, ErrorMessage = "Le nombre de personnes doit être entre 1 et 50")]
        [Display(Name = "Nombre de personnes")]
        public int NumberOfPersons { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Prix total (MAD)")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Display(Name = "Statut")]
        public BookingStatus Status { get; set; } = BookingStatus.EnAttente;

        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [ForeignKey("PackageId")]
        public virtual TravelPackage? Package { get; set; }

        public virtual Payment? Payment { get; set; }
    }
}