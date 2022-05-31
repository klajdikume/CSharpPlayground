using System;
using System.Collections.Generic;
using System.Linq;

namespace mock
{

    // x,y cordinate plane
    //  . . .
    //  . . . 


    internal class Movie
    {
        public Movie(string name, int releaseYear, float rating)
        {
            Name = name;
            ReleaseYear = releaseYear;
            Rating = rating;
        }

        public string Name { get; set; }

        public int ReleaseYear { get; set; }

        public float Rating { get; set; }
        
        public IEnumerable<Review> Reviews { get; set; }
    }

    internal class Review
    {
        public Review(int score, string comment)
        {
            Score = score;
            Comment = comment;
        }

        public int Score { get; set; }

        public string Comment { get; set; }
    }

    internal class RatingCount
    {
        public float Rating { get; set; }

        public int Count { get; set; }
    }

    class Program
    {
        private static void PrettyPrint(Movie movie, Func<Movie, string> printeRating)
        {
            var rating = printeRating(movie);

            var prettyPrint = $"Name: { movie.Name }, Rating: [{ rating }]";

            Console.WriteLine(prettyPrint);
        }

        private static string PrintRating(Movie movie)
        {
            return new string('*', (int)movie.Rating);
        }

        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie("Titanic", 1998, 4.5f),
                new Movie("The Fifth Element", 1997, 4.6f),
                new Movie("Terminator 2", 1991, 4.7f),
                new Movie("Avatar", 2009, 5),
                new Movie("Platoon", 1986, 4),
                new Movie("My Neighbor Totoro", 1988, 5)
            };

            PrettyPrint(movies[0], PrintRating);

            PrettyPrint(movies[0], (movie) => new string('*', (int)movie.Rating));

            using (var enumerator = movies.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    do
                    {
                        var movie = enumerator.Current;
                        Console.WriteLine(movie.Name);
                    } while (enumerator.MoveNext());
                }
            }

            var favorites = movies.Where(movie => movie.Rating > 4.5f)
                                  .Select(movie => movie.Name);

            // groups elements based on a grouping key
            var countByRating = movies.GroupBy(movie => movie.Rating,
                                    (rating, groupedMovies) => new RatingCount { Rating = rating, Count = groupedMovies.Count() });

            var groupByReleasedYearAndRating = movies.GroupBy(movie => new { movie.ReleaseYear, movie.Rating });

            foreach (var group in groupByReleasedYearAndRating)
            {
                var groupingKey = group.Key;
                Console.WriteLine($"Release Year/Rating: {groupingKey.ReleaseYear} - {groupingKey.Rating} ");

                foreach (var movie in group)
                {
                    Console.WriteLine($"{movie.Name}");
                }
                Console.WriteLine();
            }

            var firstThree = movies.Take(3);

            var lastFour = movies.Skip(2);

            /// -> Transform collection of collections

            var moviess = new List<Movie>
            {
                new Movie("Titanic", 1998, 4.5f)
                {
                    Reviews = new List<Review>
                    {
                        new Review(3, "Cameron's mixing of romance with real-life disaster is still impressive and occasionally brilliant")
                    }
                },
                new Movie("The Fifth Element", 1997, 4.6f)
                {
                    Reviews = new List<Review>
                    {
                        new Review(4, "One of those rare films you can watch over and over")
                    }
                },
                new Movie("Terminator 2", 1991, 4.7f)
                {
                    Reviews = new List<Review>
                    {
                        new Review(4, "One sequel that out does the original")
                    }
                },
                new Movie("Avatar", 2009, 5)
                {
                    Reviews = new List<Review>
                    {
                        new Review(4, "Technically outstanding. Originality: oh well....")
                    }
                },
                new Movie("Platoon", 1986, 4)
                {
                    Reviews = new List<Review>
                    {
                        new Review(5, "Still packs a punch 30 years on")
                    }
                },
                new Movie("My Neighbor Totoro", 1988, 5)
                {
                    Reviews = new List<Review>
                    {
                        new Review(5, "This is a great film!")
                    }
                }
            };

            var reviews = moviess.Where(movie => movie.Rating > 4.5)
                .SelectMany(movie => movie.Reviews);

            foreach (var review in reviews)
            {
                Console.WriteLine($"[{review.Score}]: '{review.Comment}'");
            }

            var maxRating = movies.Aggregate(0f, (acc, movie) => acc = MaxBetween(acc, movie.Rating));

        }


        private static float MaxBetween(float accumulator, float rating)
        {
            Console.WriteLine($"Comparing {accumulator} and {rating}");
            return rating > accumulator ? rating : accumulator;
        }

        static bool isAnagram(String text1, String text2)
        {
            if (text1.Length != text2.Length)
                return false;



            return true;
        }
    }
}
