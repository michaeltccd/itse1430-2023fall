/*
 * ITSE 1430
 * Fall 2023
 */
namespace MovieLibrary;

/// <summary>Represents an MPAA rating.</summary>
public class Rating
{
    /// <summary>Initializes an instance of the <see cref="Rating"/> class.</summary>        
    /// <param name="name">Name of the rating.</param>
    public Rating ( string name )
    {
        Name = String.IsNullOrEmpty(name) ? "" : name;
    }

    /// <summary>Represents a standard rating of G.</summary>
    public static readonly Rating G = new Rating("G");
    
    /// <summary>Represents a standard rating of PG.</summary>
    public static readonly Rating PG = new Rating("PG");

    /// <summary>Represents a standard rating of PG-13.</summary>
    public static readonly Rating PG13 = new Rating("PG-13");

    /// <summary>Represents a standard rating of R.</summary>
    public static readonly Rating R = new Rating("R");

    /// <summary>Gets the rating name.</summary>
    public string Name { get; }
    
    /// <inheritdoc />
    public override string ToString ()
    { return Name;}
}
