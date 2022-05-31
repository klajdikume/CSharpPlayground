using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock
{
    public class ValidateObjectWithAll
    {
        public static void Main1()
        {
            //var movie = new Movie1("Toy Story", Certification.G, Genre.Comedy);

            //var rules = new Func<Movie1, bool>[]
            //{
            //    (m) => m.Certification == Certification.G || m.Certification == Certification.PG,
            //    (m) => m.Genre != Genre.War
            //};

            //var isSuitableForChildren = rules.All(rule => rule(movie));

            //if (movie.Certification != Certification.G && movie.Certification != Certification.PG)
            //    isSuitableForChildren = false;
            //if (movie.Genre == Genre.War)
            //    isSuitableForChildren = false;

            //if (isSuitableForChildren)
            //    Console.WriteLine($"You can watch {movie.Name} with your kids.");
            //else
            //    Console.WriteLine($"Don't watch {movie.Name} with your kids.");

            var movies = new List<Movie1>
            {
                new Movie1("Dark Knight", 2008, 9.0f)
                {
                    Director = "Christopher Nolan",
                    Genre = Genre.Action,
                    Reviews = new List<Review1>
                    {
                        new Review1(4, "Good soundtrack")
                    }
                },
                new Movie1("Saving Private Ryan", 1998, 8.6f)
                {
                    Director = "Steven Spielberg",
                    Genre = Genre.War,
                    Reviews = new List<Review1>
                    {
                        new Review1(5, "The most realistic war movie")
                    }
                },
                new Movie1("My Neighbor Totoro", 1988, 8.1f)
                {
                    Director = "Hayao Miyazaki",
                    Genre = Genre.Animation,
                    Reviews = new List<Review1>
                    {
                        new Review1(5, "Awesome. I cried the first time I watched it")
                    }
                }
            };


            // TODO: Refactor the AcceptMovieRecommendation method to better use LINQ
            //
            // We ask our friends for movie recommendations. And we want to filter
            // them out. These are our requirements to accept a recommendation
            //
            // If a movie is from one of our favorite directors, accept it
            // If it's from the '60s or '70s, accept it
            // If it's from our favorite sagas, definitively accept it
            // If it's a horror film from John Carpenter, definitively accept it
            // If it has at least one bad review, drop it
            foreach (var movie in movies)
            {
                var goodMovieToWatch = AcceptMovieRecommendation(movie);
                if (goodMovieToWatch)
                {
                    PrintMovie(movie);
                }
            }
            // Output:
            // Saving Private Ryan: [8.6]

        }

        private static bool AcceptMovieRecommendation(Movie1 movie)
        {
            if (DirectedByFavoriteDirectors(movie))
            {
                return true;
            }
            if (ReleasedOn60sAnd70s(movie))
            {
                return true;
            }
            if (IsStarWarsOrLordOfTheRings(movie))
            {
                return true;
            }
            if (HorrorFromJohnCarpenter(movie))
            {
                return true;
            }
            if (DoesNotHaveBadReviews(movie))
            {
                return true;
            }

            return false;
        }

        private static bool DirectedByFavoriteDirectors(Movie1 movie)
        {
            var favoriteDirectors = new[]
            {
                "Martin Scorsese",
                "Steven Spielberg",
                "Quentin Tarantino",
                "Stanley Kubrick"
            };

            return favoriteDirectors.Any(director => movie.Director == director);
        }

        private static bool ReleasedOn60sAnd70s(Movie1 movie)
        {
            return movie.ReleaseYear >= 1960 && movie.ReleaseYear < 1980;
        }

        private static bool IsStarWarsOrLordOfTheRings(Movie1 movie)
        {
            return movie.Name.StartsWith("Star Wars", StringComparison.OrdinalIgnoreCase)
                || movie.Name.StartsWith("Lord of the Rings", StringComparison.OrdinalIgnoreCase);
        }

        private static bool HorrorFromJohnCarpenter(Movie1 movie)
        {
            return movie.Genre == Genre.Horror && movie.Director == "John Carpenter";
        }

        private static bool DoesNotHaveBadReviews(Movie1 movie)
        {
            return !movie.Reviews.Any(review => review.Score < 3.0);
        }

        private static void PrintMovie(Movie1 movie)
        {
            Console.WriteLine($"{movie.Name}: [{movie.Rating}]");
        }
    }

    internal class Movie1
    {
        public Movie1(string name, int releaseYear, float rating)
        {
            Name = name;
            ReleaseYear = releaseYear;
            Rating = rating;
        }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        public int ReleaseYear { get; set; }

        public float Rating { get; set; }

        public string Director { get; set; }

        public IEnumerable<Review1> Reviews { get; set; }

    }

    internal class Review1
    {
        public Review1(int score, string comment)
        {
            Score = score;
            Comment = comment;
        }

        public int Score { get; set; }

        public string Comment { get; set; }
    }

    internal enum Certification
    {
        G,
        PG,
        PG_13,
        R
    }

    internal enum Genre
    {
        Comedy,
        Action,
        Drama,
        War,
        Fantasy,
        Animation,
        Horror
    }
}
