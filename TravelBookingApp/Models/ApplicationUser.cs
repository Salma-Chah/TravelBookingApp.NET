using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        [Display(Name = "Nom")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Date d'inscription")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        // Propriété calculée pour le nom complet
        [Display(Name = "Nom complet")]
        public string FullName => $"{FirstName} {LastName}";
    }
}