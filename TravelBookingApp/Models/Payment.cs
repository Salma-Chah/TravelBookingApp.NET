using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Models
{
    public enum PaymentMethod
    {
        [Display(Name = "Carte bancaire")]
        CarteBancaire,
        [Display(Name = "Virement")]
        Virement,
        [Display(Name = "Espèces")]
        Especes
    }

    public enum PaymentStatus
    {
        [Display(Name = "En attente")]
        EnAttente,
        [Display(Name = "Validé")]
        Valide,
        [Display(Name = "Échoué")]
        Echoue
    }

    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Réservation")]
        public int BookingId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Montant (MAD)")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Méthode de paiement")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [Display(Name = "Date de paiement")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        [Display(Name = "ID de transaction")]
        public string? TransactionId { get; set; }

        [Required]
        [Display(Name = "Statut du paiement")]
        public PaymentStatus Status { get; set; } = PaymentStatus.EnAttente;

        // Navigation property
        [ForeignKey("BookingId")]
        public virtual Booking? Booking { get; set; }
    }
}