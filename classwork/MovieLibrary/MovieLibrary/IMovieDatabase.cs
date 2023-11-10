/*
 * ITSE 1430 
 * Fall 2023
 */
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary;

/// <summary>Represents a database of movies.</summary>
public interface IMovieDatabase
{
    /// <summary>Adds a movie to the database.</summary>
    /// <param name="movie">The movie to add.</param>
    /// <returns>The new movie.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
    /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
    /// <exception cref="InvalidOperationException">Movie title is not unique.</exception>    
    Movie Add ( Movie movie );

    /// <summary>Deletes a movie from the database.</summary>
    /// <param name="id">ID of the movie to delete.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
    /// <remarks>
    /// If the movie does not exist then nothing happens.
    /// </remarks>
    void Delete ( int id );

    /// <summary>Gets a movie.</summary>
    /// <param name="id">ID of the movie.</param>
    /// <returns>The movie, if found.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
    Movie Get ( int id );

    /// <summary>Gets all the movies in the database.</summary>
    /// <returns>The list of movies.</returns>
    IEnumerable<Movie> GetAll ();

    /// <summary>Updates a movie in the database.</summary>
    /// <param name="id">ID of the movie to update.</param>
    /// <param name="movie">The updated movie information.</param>
    /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
    /// <exception cref="ArgumentException">Movie does not exist.</exception>
    /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
    /// <exception cref="InvalidOperationException">Movie title is not unique.</exception>
    void Update ( int id, Movie movie );
}