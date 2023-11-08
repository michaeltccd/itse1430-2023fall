/*
 * ITSE 1430 
 * Fall 2023
 */
namespace MovieLibrary;

/// <summary>Represents a database of movies.</summary>
public abstract class MovieDatabase : IMovieDatabase
{        
    /// <inheritdoc />
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

    /// <inheritdoc />
    public virtual void Delete ( int id )
    {
        //TODO:Id > 0
        DeleteCore(id);
    }

    /// <inheritdoc />
    public virtual Movie Get ( int id )
    {
        if (id <= 0)
            return null;

        return GetCore(id);
    }

    /// <inheritdoc />
    public virtual IEnumerable<Movie> GetAll ()
    {
        return GetAllCore() ?? Enumerable.Empty<Movie>(); // new Movie[0];
    }

    /// <inheritdoc />
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


    #region Protected Members

    /// <summary>Adds a movie to the database.</summary>
    /// <param name="movie">Movie to add.</param>
    /// <returns>Updated movie.</returns>
    protected abstract Movie AddCore ( Movie movie );
        
    /// <summary>Deletes a movie.</summary>
    /// <param name="id">ID of the movie.</param>
    protected abstract void DeleteCore ( int id );
        
    /// <summary>Gets a movie.</summary>
    /// <param name="id">ID of the movie.</param>
    /// <returns>The movie, if found.</returns>
    protected abstract Movie GetCore ( int id );
    
    /// <summary>Gets the movies in the database.</summary>
    /// <returns>The list of movies.</returns>
    protected abstract IEnumerable<Movie> GetAllCore ();
    
    /// <summary>Updates a movie in the database.</summary>
    /// <param name="id">ID of the movie to update.</param>
    /// <param name="movie">The updated movie information.</param>
    protected abstract void UpdateCore ( int id, Movie movie );

    /// <summary>Finds a movie by its ID.</summary>
    /// <param name="id">ID of the movie.</param>
    /// <returns>The movie, if any.</returns>
    protected abstract Movie FindById ( int id );

    /// <summary>Finds a movie by its title.</summary>
    /// <param name="title">Title of the movie.</param>
    /// <returns>The movie, if any.</returns>
    protected abstract Movie FindByTitle ( string title );
    #endregion
}
