using Microsoft.EntityFrameworkCore;
using BerrasBioLab.Models;

namespace BerrasBioLab.Data
{
    public static class SeedData
    {
        public static void Initialize(BerrasBioLabContext db)
        {
            // Look for any movies.
            if (db.Movie.Any())
            {
                return;   // DB has been seeded
            }

            // Adds a range of movies
            db.Movie.AddRange(
                new Movie
                {
                    Title = "Death Parade"
                },
                new Movie
                {
                    Title = "Death Billiard"
                },
                new Movie
                {
                    Title = "Power Rangers"
                }
                );
            db.SaveChanges();

            // Look for any movies.
            if (db.Salon.Any())
            {
                return; // DB has been seeded
            }

            // Adds a single salon
            db.Salon.AddRange(
                new Salon
                {
                    NrOfSeats = 50,
                }
                );
            db.SaveChanges();

            // Look for any movies.
            if (db.Showcase.Any())
            {
                return; // DB has been seeded
            }

            // Adds a range of dates by looking into the Id's of Sovie and Salon
            db.Showcase.AddRange(
                    new Showcase
                    {
                        MovieId = 1,
                        SalonId = 1,
                        AvailableSeats = 50,
                        StartTime = DateTime.Today.AddHours(16)
                    },
                    new Showcase
                    {
                        MovieId = 2,
                        SalonId = 1,
                        AvailableSeats = 50,
                        StartTime = DateTime.Today.AddHours(18)
                    },
                    new Showcase
                    {
                        MovieId = 3,
                        SalonId = 1,
                        AvailableSeats = 50,
                        StartTime = DateTime.Today.AddHours(20)

                    }
                    );

            db.SaveChanges();

        }
    }
}