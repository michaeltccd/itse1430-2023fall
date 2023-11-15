/*
 * ITSE 1430
 * Fall 2023
 */
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary;

/// <summary>Represents a movie.</summary>
public class Movie : IValidatableObject
{
    #region Construction

    /// <summary>Initializes the Movie class.</summary>
    public Movie ()
    {
    }

    /// <summary>Initializes the Movie class.</summary>
    /// <param name="id">Identifier of the movie.</param>
    public Movie ( int id ) : this(id, "")
    {
    }

    public Movie ( string title ) : this(0, title)
    {
    }

    public Movie ( int id, string title )
    {         
        Id = id;
        Title = title;            
    }
    #endregion

    /// <summary>Gets or sets the unique identifier of the movie.</summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the title of movie.</summary>
    public string Title
    {
        get => _title ?? "";
        set => _title = value?.Trim() ?? "";
    }

    /// <summary>Gets or sets the optional description.</summary>
    public string Description
    {
        get => _description ?? "";
        set => _description = value;
    }

    /// <summary>Gets or sets the genre.</summary>
    public string Genre
    {
        get => _genre ?? "";
        set => _genre = value;
    }

    /// <summary>Gets or sets the MPAA rating.</summary>
    public Rating Rating { get; set; }
    
    /// <summary>Gets or sets the run length.</summary>
    /// <value>Must be at least zero.</value>
    public int RunLength { get; set; }
    
    /// <summary>Gets or sets the release year.</summary>
    /// <value>Must be at least 1900.</value>
    public int ReleaseYear { get; set; } = MinimumReleaseYear;

    /// <summary>Determines if the movie is black and white or color.</summary>
    public bool IsBlackAndWhite { get; set; }

    /// <summary>Determines if the movie needs an intermission.</summary>
    /// <value>Any movie that is at least 2 and a half hours needs an intermission.</value>    
    public bool NeedsIntermission => RunLength >= 150;

    /// <summary>Minimum release year.</summary>
    public const int MinimumReleaseYear = 1900;

    /// <summary>Gets the default rating.</summary>
    public readonly string DefaultRating = "PG";

    /// <inheritdoc />
    public override string ToString () => $"{Title} [{ReleaseYear}]";

    /// <inheritdoc />
    public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
    {
        //Title is required
        if (String.IsNullOrEmpty(_title))
            yield return new ValidationResult("Title is required");

        //Release Year >= 1900
        if (ReleaseYear < MinimumReleaseYear)
            yield return new ValidationResult($"Release Year must be >= {MinimumReleaseYear}");

        //Length >= 0
        if (RunLength < 0)
            yield return new ValidationResult("Length must be at least 0");

        if (ReleaseYear < 1940 && !IsBlackAndWhite)
            yield return new ValidationResult("Movies before 1940 must be black and white");            
    }

    #region Private Members

    private string _title;
    private string _description = "";
    private string _genre = "";

    #endregion
}