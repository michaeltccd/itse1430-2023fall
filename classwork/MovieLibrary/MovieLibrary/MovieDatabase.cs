namespace MovieLibrary;

/// <summary>Represents a database of movies.</summary>
public class MovieDatabase
{
    public MovieDatabase ()
    {
        //Object initializer
        //var movie = new Movie();
        //movie.Id = _id++;
        //movie.Title = "Jaws";
        //movie.ReleaseYear = 1977;
        //movie.Rating = Rating.PG;
        //movie.RunLength = 120;
        //_movies[0] = movie;
        _movies[0] = new Movie() {
                Id = _id++,
                Title = "Jaws",
                ReleaseYear = 1977,
                Rating = Rating.PG,
                RunLength = 120,
            };

        //TODO: Fix this
        var movie = new Movie();
        movie.Id = _id++;
        movie.Title = "Dune";
        movie.ReleaseYear = 1983;
        movie.Rating = Rating.PG13;
        movie.RunLength = 210;
        _movies[1] = movie;

        movie = new Movie();
        movie.Id = _id++;
        movie.Title = "Star Wars";
        movie.ReleaseYear = 1977;
        movie.Rating = Rating.PG;
        movie.RunLength = 150;
        _movies[2] = movie;
    }

    public string Add ( Movie movie )
    {
        //Validate: null, invalid movie
        if (movie == null)
            return "Movie is null";
        if (!movie.TryValidate(out var error))
            return error;

        //Title must be unique
        var existing = FindByTitle(movie.Title);
        if (existing != null)
            return "Movie title must be unique";

        //Find an empty slot
        for (var index = 0; index < _movies.Length; ++index)
        {
            if (_movies[index] == null)
            {
                movie.Id = _id++;
                _movies[index] = Clone(movie);
                return "";
            };
        };

        return "Array is full";
    }

    public void Update ( Movie movie )
    {
    }

    public void Delete ( int id )
    {
        //TODO:Id > 0

        var index = FindById(id);
        if (index >= 0)
            _movies[index] = null;
    }

    public Movie[] GetAll ()
    {
        //How many are not null
        var count = 0;
        for (var index = 0; index < _movies.Length; ++index)
            if (_movies[index] != null)
                ++count;

        //Clone array
        var items = new Movie[count];
        var itemIndex = 0;
        for (var index = 0; index < _movies.Length; ++index)
            if (_movies[index] != null)
                items[itemIndex++] = Clone(_movies[index]);

        return items;
    }

    private Movie Clone ( Movie movie )
    {
        var item = new Movie();
        item.Id = movie.Id;
        item.Title = movie.Title;
        item.Description = movie.Description;
        item.Rating = movie.Rating;
        item.ReleaseYear = movie.ReleaseYear;
        item.RunLength = movie.RunLength;
        item.IsBlackAndWhite = movie.IsBlackAndWhite;
        item.Genre = movie.Genre;

        return item;
    }

    private int FindById ( int id )
    {
        for (var index = 0; index < _movies.Length; ++index)
            if (_movies[index]?.Id == id)
                return index;

        return -1;
    }

    private Movie FindByTitle ( string title )
    {
        for (var index = 0; index < _movies.Length; ++index)
            if (String.Equals(title, _movies[index]?.Title, StringComparison.OrdinalIgnoreCase))
                return _movies[index];

        return null;
    }

    private readonly Movie[] _movies = new Movie[100];
    private int _id = 1;
}
