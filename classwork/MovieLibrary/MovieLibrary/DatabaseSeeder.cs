namespace MovieLibrary;

public static class DatabaseSeeder
{
    public static void Seed ( this IMovieDatabase database )
    {
        //Set up movies
        var movies = new[] {
                    new Movie() {
                        Title = "Jaws",
                        ReleaseYear = 1977,
                        Rating = Rating.PG,
                        RunLength = 120,
                    },
                    new Movie() {
                        Title = "Dune",
                        ReleaseYear = 1983,
                        Rating = Rating.PG13,
                        RunLength = 210,
                    },
                    new Movie() {
                        Title = "Star Wars",
                        ReleaseYear = 1977,
                        Rating = Rating.PG,
                        RunLength = 150,
                    },
                };

        foreach (var movie in movies)
            database.Add(movie);
    }
}
