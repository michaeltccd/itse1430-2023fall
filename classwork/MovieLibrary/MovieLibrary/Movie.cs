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

        //Methods - functionality

        /// <summary>Download metadata from Internet.</summary>
        /// <remarks>
        /// Searches IMDB and TheTVDB.com.
        /// </remarks>
        private void DownloadMetadata ()
        { }

        /// <summary>Validates the movie instance.</summary>
        /// <returns>Error message if invalid or empty string otherwise.</returns>
        public string Validate () /* Movie this */
        {
            //Title is required
            //if (String.IsNullOrEmpty(this.title))
            if (String.IsNullOrEmpty(title))
                return "Title is required";

            //var releaseYear = 10;

            //Release Year >= 1900
            //if (this.releaseYear < 1900)
            if (releaseYear < 1900)
                return "Release Year must be >= 1900";

            //Length >= 0
            if (length < 0)
                return "Length must be at least 0";

            //TODO: Rating is in a list

            //If ReleaseYear < 1940 then IsBlackAndWhite must be true
            if (releaseYear < 1940 && !isBlackAndWhite)
                return "Movies before 1940 must be black and white";

            //Valid
            return "";
        }
    }
}