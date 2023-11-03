/*
 * ITSE 1430 
 * Fall 2023
 */

namespace MovieLibrary.Memory;

/// <summary>Represents a database of movies.</summary>
public class MemoryMovieDatabase : MovieDatabase
{
    protected override Movie AddCore ( Movie movie )
    {
        movie.Id = _id++;
        _movies.Add(Clone(movie));

        return movie;
    }

    protected override void DeleteCore ( int id )
    {
        var movie = FindById(id);
        if (movie != null)
            _movies.Remove(movie);  //Reference equality applies
    }

    protected override Movie GetCore ( int id )
    {
        var movie = FindById(id);
        if (movie == null)
            return null;

        return Clone(movie);
    }

    /// <summary>Gets all the movies in the database.</summary>
    /// <returns>The list of movies.</returns>
    protected override IEnumerable<Movie> GetAllCore ()
    {
        foreach (var movie in _movies)
            yield return Clone(movie);
    }
    
    protected override void UpdateCore ( int id, Movie movie )
    {        
        var existing = FindById(id);

        Copy(existing, movie);
    }

    #region Private Members

    private Movie Clone ( Movie movie )
    {
        var item = new Movie() { Id = movie.Id };
        Copy(item, movie);

        return item;
    }

    private void Copy ( Movie target, Movie source )
    {
        //Don't copy Id
        target.Title = source.Title;
        target.Description = source.Description;
        target.Rating = source.Rating;
        target.ReleaseYear = source.ReleaseYear;
        target.RunLength = source.RunLength;
        target.IsBlackAndWhite = source.IsBlackAndWhite;
        target.Genre = source.Genre;
    }

    protected override Movie FindById ( int id )
    {
        foreach (var movie in _movies)
            if (movie.Id == id)
                return movie;

        return null;
    }

    protected override Movie FindByTitle ( string title )
    {
        foreach (var movie in _movies)
            if (String.Equals(title, movie.Title, StringComparison.OrdinalIgnoreCase))
                return movie;

        return null;
    }
    
    private readonly List<Movie> _movies = new List<Movie>();
    private int _id = 1;
    #endregion
}
