using Microsoft.AspNetCore.Identity;
using TravelBookingApp.Models;
using System.Collections.Generic;

namespace TravelBookingApp.Data
{
    public static class DbSeeder
    {
        public static async Task SeedDataAsync(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(roleManager);
            await SeedAdminUserAsync(userManager);
            await SeedDestinationsAsync(context);
            await SeedPackagesAsync(context);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("Client"))
            {
                await roleManager.CreateAsync(new IdentityRole("Client"));
            }
        }

        private static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var adminEmail = "admin@travelbooking.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "System",
                    EmailConfirmed = true,
                    CreatedAt = DateTime.Now
                };

                var result = await userManager.CreateAsync(admin, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }

        private static async Task SeedDestinationsAsync(ApplicationDbContext context)
        {
            if (context.Destinations.Any())
            {
                return;
            }

            var destinations = new List<Destination>
            {
                new Destination
                {
                    Name = "Paris",
                    Country = "France",
                    Description = "La ville lumière, capitale de la France.",
                    ImageUrl = "/images/paris.jpg",
                    CreatedAt = DateTime.Now
                },
                new Destination
                {
                    Name = "Marrakech",
                    Country = "Maroc",
                    Description = "La perle du Sud du Maroc.",
                    ImageUrl = "https://www.edreams.fr/blog/wp-content/uploads/sites/6/2016/09/marrakesh_135809351-min.jpg",
                    CreatedAt = DateTime.Now
                },
                new Destination
                {
                    Name = "Rome",
                    Country = "Italie",
                    Description = "La ville éternelle.",
                    ImageUrl = "/images/rome.jpg",
                    CreatedAt = DateTime.Now
                },
                new Destination
                {
                    Name = "Barcelone",
                    Country = "Espagne",
                    Description = "Ville dynamique de Catalogne.",
                    ImageUrl = "/images/barcelone.jpg",
                    CreatedAt = DateTime.Now
                },
                new Destination
                {
                    Name = "Dubai",
                    Country = "Émirats Arabes Unis",
                    Description = "Ville futuriste du désert.",
                    ImageUrl = "/images/dubai.jpg",
                    CreatedAt = DateTime.Now
                },
                new Destination
                {
                    Name = "Le Caire",
                    Country = "Égypte",
                    Description = "Découvrez les pyramides de Gizeh et le Sphinx.",
                    ImageUrl = "/images/cairo.jpg",
                    CreatedAt = DateTime.Now
                },
                new Destination
                {
                    Name = "Bangkok",
                    Country = "Thaïlande",
                    Description = "Temples sacrés, marchés flottants et vie nocturne.",
                    ImageUrl = "/images/bangkok.jpg",
                    CreatedAt = DateTime.Now
                },
                new Destination
                {
                    Name = "Bali",
                    Country = "Indonésie",
                    Description = "Plages, rizières et temples hindous.",
                    ImageUrl = "/images/bali.jpg",
                    CreatedAt = DateTime.Now
                },
                new Destination
                {
                    Name = "Istanbul",
                    Country = "Turquie",
                    Description = "Pont entre l'Europe et l'Asie.",
                    ImageUrl = "/images/istanbul.jpg",
                    CreatedAt = DateTime.Now
                }
            };

            await context.Destinations.AddRangeAsync(destinations);
            await context.SaveChangesAsync();
        }

        private static async Task SeedPackagesAsync(ApplicationDbContext context)
        {
            if (context.TravelPackages.Any())
            {
                return;
            }

            var paris = context.Destinations.First(d => d.Name == "Paris");
            var marrakech = context.Destinations.First(d => d.Name == "Marrakech");
            var rome = context.Destinations.First(d => d.Name == "Rome");
            var barcelone = context.Destinations.First(d => d.Name == "Barcelone");
            var dubai = context.Destinations.First(d => d.Name == "Dubai");
            var cairo = context.Destinations.First(d => d.Name == "Le Caire");
            var bangkok = context.Destinations.First(d => d.Name == "Bangkok");
            var bali = context.Destinations.First(d => d.Name == "Bali");
            var istanbul = context.Destinations.First(d => d.Name == "Istanbul");

            var packages = new List<TravelPackage>
            {
                new TravelPackage
                {
                    Title = "Week-end romantique à Paris",
                    DestinationId = paris.Id,
                    Description = "3 jours / 2 nuits, hôtel 4*, visite Tour Eiffel.",
                    Price = 5500,
                    Duration = 3,
                    ImageUrl = "https://images.unsplash.com/photo-1511739001486-6bfe10ce785f?w=800",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new TravelPackage
                {
                    Title = "Aventure à Marrakech",
                    DestinationId = marrakech.Id,
                    Description = "5 jours / 4 nuits. Riad, désert, quad, dîner.",
                    Price = 4200,
                    Duration = 5,
                    ImageUrl = "https://www.edreams.fr/blog/wp-content/uploads/sites/6/2016/09/marrakesh_135809351-min.jpg",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new TravelPackage
                {
                    Title = "Rome Antique",
                    DestinationId = rome.Id,
                    Description = "4 jours / 3 nuits. Hôtel 3*, visites historiques.",
                    Price = 4800,
                    Duration = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1552832230-c0197dd311b5?w=800",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new TravelPackage
                {
                    Title = "Barcelone Culturelle",
                    DestinationId = barcelone.Id,
                    Description = "4 jours / 3 nuits. Sagrada Familia, Park Güell.",
                    Price = 3900,
                    Duration = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1562883676-8c7feb83f09b?w=800",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new TravelPackage
                {
                    Title = "Dubai Luxe",
                    DestinationId = dubai.Id,
                    Description = "7 jours / 6 nuits. Hôtel 5*, safari, croisière.",
                    Price = 12000,
                    Duration = 7,
                    ImageUrl = "https://images.unsplash.com/photo-1518684079-3c830dcef090?w=800",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new TravelPackage
                {
                    Title = "Trésors de l'Égypte",
                    DestinationId = cairo.Id,
                    Description = "Croisière sur le Nil, pyramides, hôtel 4*.",
                    Price = 6200,
                    Duration = 8,
                    ImageUrl = "https://images.unsplash.com/photo-1516316331057-6b27e1a0c4d9?w=800",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new TravelPackage
                {
                    Title = "Évasion à Bangkok",
                    DestinationId = bangkok.Id,
                    Description = "Temples, street food, marchés flottants.",
                    Price = 3800,
                    Duration = 6,
                    ImageUrl = "https://images.unsplash.com/photo-1532074205218-bf2aa6de4a85?w=800",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new TravelPackage
                {
                    Title = "Sérénité à Bali",
                    DestinationId = bali.Id,
                    Description = "Villa privée, plongée, plages et rizières.",
                    Price = 5400,
                    Duration = 7,
                    ImageUrl = "https://images.unsplash.com/photo-1529177585454-851718b7d0b9?w=800",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new TravelPackage
                {
                    Title = "Istanbul Impériale",
                    DestinationId = istanbul.Id,
                    Description = "Sainte-Sophie, Grand Bazar, bain turc.",
                    Price = 4100,
                    Duration = 5,
                    ImageUrl = "https://images.unsplash.com/photo-1524231757912-21f4fe3a72df?w=800",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                }
            };

            await context.TravelPackages.AddRangeAsync(packages);
            await context.SaveChangesAsync();
        }
    }
}
