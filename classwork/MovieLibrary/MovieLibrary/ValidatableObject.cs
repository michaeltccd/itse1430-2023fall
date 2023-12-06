/*
 * ITSE 1430
 * Fall 2023
 */
namespace MovieLibrary;

/// <summary>Provides a base class for validating objects.</summary>
[Obsolete("Use IValidatableObject instead")]
public class ValidatableObject
{
    /// <summary>Determines if the object is valid.</summary>
    public bool IsValid 
    { 
        get { return TryValidate(out var _); }
    }

    /// <summary>Validates an instance.</summary>
    /// <param name="message">Error message if invalid.</param>
    /// <returns>true if valid or false otherwise.</returns>
    public virtual bool TryValidate ( out string message )
    {                
        message = "";
        return true;
    }

    /// <summary>Validates the movie instance.</summary>
    /// <returns>Error message if invalid or empty string otherwise.</returns>
    public string Validate ()
    {
        if (!TryValidate(out var message))
            return message;

        return "";
    }
}