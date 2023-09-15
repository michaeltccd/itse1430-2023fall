/*
 * ITSE 1430
 * Fall 2023
 */
namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Paragraphs of descriptions.
    /// </remarks>
    public class Movie
    {
        //Fields - data
        /// <summary>Title of movie.</summary>
        public string title = "";
        public string description = "";
        public string genre = "";
        public string rating = "";

        public int length;
        public int releaseYear = 1900;
        public bool isBlackAndWhite;
    }
}