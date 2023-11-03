/*
 * ITSE 1430 
 * Fall 2023
 */
namespace MovieLibrary;

/// <summary>Represents a database of movies.</summary>
public abstract class MovieDatabase : IMovieDatabase
{    
    /// <summary>Adds a movie to the database.</summary>
    /// <param name="movie">The movie to add.</param>
    /// <returns>Empty string if successful or an error message otherwise.</returns>
    /// <remarks>
    /// Movie cannot be null.
    /// Movie must be valid.
    /// Movie title must be unique.
    /// </remarks>
    public virtual string Add ( Movie movie )
    {
        //Validate: null, invalid movie
        if (movie == null)
            return "Movie is null";
        if (!ObjectValidator.TryValidate(movie, out var error))
            return error.First().ErrorMessage;

        //Title must be unique
        var existing = FindByTitle(movie.Title);
        if (existing != null)
            return "Movie title must be unique";

        //HACK: This is a hack for now
        var newMovie = AddCore(movie);
        movie.Id = newMovie.Id;
        return "";
    }

    protected abstract Movie AddCore ( Movie movie );

    /// <summary>Deletes a movie from the database.</summary>
    /// <param name="id">ID of the movie to delete.</param>
    /// <remarks>
    /// Id must be > 0.
    /// If the movie does not exist then nothing happens.
    /// </remarks>
    public virtual void Delete ( int id )
    {
        //TODO:Id > 0

        DeleteCore(id);
    }

    protected abstract void DeleteCore ( int id );

    public virtual Movie Get ( int id )
    {
        if (id <= 0)
            return null;

        return GetCore(id);
    }

    protected abstract Movie GetCore ( int id );

    /// <summary>Gets all the movies in the database.</summary>
    /// <returns>The list of movies.</returns>
    public virtual IEnumerable<Movie> GetAll ()
    {
        return GetAllCore() ?? Enumerable.Empty<Movie>(); // new Movie[0];
    }

    protected abstract IEnumerable<Movie> GetAllCore ();

    /// <summary>Updates a movie in the database.</summary>
    /// <param name="id">ID of the movie to update.</param>
    /// <param name="movie">The updated movie information.</param>
    /// <returns>Empty string if successful or an error message otherwise.</returns>
    /// <remarks>
    /// Id must be > 0.
    /// Movie cannot be null.
    /// Movie must be valid.
    /// Movie must exist.
    /// Movie title must be unique.
    /// </remarks>
    public virtual string Update ( int id, Movie movie )
    {
        //Validate: null, invalid movie
        if (id <= 0)
            return "ID is invalid";

        //var whatever = new ObjectValidator();
        
        if (movie == null)
            return "Movie is null";
        if (!ObjectValidator.TryValidate(movie, out var error))
            return error.First().ErrorMessage;

        //Title must be unique (and not self)
        var existing = FindByTitle(movie.Title);
        if (existing != null && existing.Id != id)
            return "Movie title must be unique";

        //Movie must exist
        existing = FindById(id);
        if (existing == null)
            return "Movie not found";

        UpdateCore(id, movie);
        return "";
    }

    protected abstract void UpdateCore ( int id, Movie movie );

    protected abstract Movie FindById ( int id );

    protected abstract Movie FindByTitle ( string title );
}
