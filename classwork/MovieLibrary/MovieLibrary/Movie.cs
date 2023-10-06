/*
 * ITSE 1430
 * Fall 2023
 */
namespace MovieLibrary;

/// <summary>Represents a movie.</summary>
public class Movie : ValidatableObject
{
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

    /// <summary>Gets or sets the unique identifier of the movie.</summary>
    public int Id { get; private set; }

    /// <summary>Gets or sets the title of movie.</summary>
    public string Title
    {
        get { return _title ?? ""; }
        set { _title = value?.Trim() ?? ""; }
    }

    /// <summary>Gets or sets the optional description.</summary>
    public string Description
    {
        get { return _description ?? ""; }
        set { _description = value; }
    }

    /// <summary>Gets or sets the genre.</summary>
    public string Genre
    {
        get { return _genre ?? ""; }
        set { _genre = value; }
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
    public bool NeedsIntermission
    {
        get { return RunLength >= 150; }
    }

    /// <summary>Minimum release year.</summary>
    public const int MinimumReleaseYear = 1900;

    /// <summary>Gets the default rating.</summary>
    public readonly string DefaultRating = "PG";

    private string _title;
    private string _description = "";
    private string _genre = "";

    /// <summary>Validates the movie instance.</summary>
    /// <returns>Error message if invalid or empty string otherwise.</returns>
    public override bool TryValidate ( out string message ) /* Movie this */
    {
        //Title is required
        if (String.IsNullOrEmpty(_title))
        {
            message = "Title is required";
            return false;
        };

        //Release Year >= 1900
        if (ReleaseYear < MinimumReleaseYear)
        {
            message = $"Release Year must be >= {MinimumReleaseYear}";
            return false;
        };

        //Length >= 0
        if (RunLength < 0)
        {
            message = "Length must be at least 0";
            return false;
        };

        if (ReleaseYear < 1940 && !IsBlackAndWhite)
        {
            message = "Movies before 1940 must be black and white";
            return false;
        };

        return base.TryValidate(out message);
    }

    public override string ToString ()
    {
        return $"{Title} [{ReleaseYear}]";
    }
}