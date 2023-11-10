/*
 * ITSE 1430 
 * Fall 2023
 */
namespace MovieLibrary;

/// <summary>Represents a database of movies.</summary>
public abstract class MovieDatabase : IMovieDatabase
{        
    /// <inheritdoc />
    public virtual Movie Add ( Movie movie )
    {
        //Validate: null, invalid movie
        if (movie == null)
            throw new ArgumentNullException(nameof(movie));

        ObjectValidator.Validate(movie);

        //Title must be unique
        var existing = FindByTitle(movie.Title);
        if (existing != null)
            throw new InvalidOperationException("Movie title must be unique");
        
        //TODO: Could also fail
        return AddCore(movie);        
    }

    /// <inheritdoc />
    public virtual void Delete ( int id )
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

        DeleteCore(id);
    }

    /// <inheritdoc />
    public virtual Movie Get ( int id )
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

        return GetCore(id);
    }

    /// <inheritdoc />
    //public virtual IEnumerable<Movie> GetAll ()
    //{
    //    return GetAllCore() ?? Enumerable.Empty<Movie>(); // new Movie[0];
    //}
    //Expression body ::= member who uses lambda syntax
    public virtual IEnumerable<Movie> GetAll () => GetAllCore() ?? Enumerable.Empty<Movie>();

    /// <inheritdoc />
    public virtual void Update ( int id, Movie movie )
    {
        //Validate: null, invalid movie
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

        if (movie == null)
            throw new ArgumentNullException(nameof(movie));

        ObjectValidator.Validate(movie);

        //Title must be unique (and not self)
        var existing = FindByTitle(movie.Title);
        if (existing != null && existing.Id != id)
            throw new InvalidOperationException("Movie title must be unique");

        //Movie must exist
        existing = FindById(id);
        if (existing == null)
            throw new ArgumentException("Movie not found", nameof(id));

        //TODO: Could still fails
        UpdateCore(id, movie);
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
