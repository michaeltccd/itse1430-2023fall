/*
 * ITSE 1430 
 * Fall 2023
 */
namespace MovieLibrary;

/// <summary>Represents a database of movies.</summary>
public interface IMovieDatabase
{
    /// <summary>Adds a movie to the database.</summary>
    /// <param name="movie">The movie to add.</param>
    /// <returns>Empty string if successful or an error message otherwise.</returns>
    /// <remarks>
    /// Movie cannot be null.
    /// Movie must be valid.
    /// Movie title must be unique.
    /// </remarks>
    string Add ( Movie movie );

    /// <summary>Deletes a movie from the database.</summary>
    /// <param name="id">ID of the movie to delete.</param>
    /// <remarks>
    /// Id must be > 0.
    /// If the movie does not exist then nothing happens.
    /// </remarks>
    void Delete ( int id );
    
    /// <summary>Gets a movie.</summary>
    /// <param name="id">ID of the movie.</param>
    /// <returns>The movie, if found.</returns>
    /// <remarks>
    /// ID must be > 0.
    /// </remarks>
    Movie Get ( int id );

    /// <summary>Gets all the movies in the database.</summary>
    /// <returns>The list of movies.</returns>
    IEnumerable<Movie> GetAll ();

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
    string Update ( int id, Movie movie );
}