/*
 * ITSE 1430
 * Fall 2023
 */
namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Additional remarks to help when using the class.
    /// </remarks>
    public class Movie
    {
        //Fields - data        
        private string _title;

        /// <summary>Gets or sets the title of movie.</summary>
        public string Title
        {
            //string get()
            get {
                if (String.IsNullOrEmpty(_title))
                    return "";

                return _title;
            }

            //void set(string value)
            set 
            {
                if (value != null)
                    value = value.Trim();

                _title = value;
            }
        }

        private string _description = "";
        public string Description
        {
            get 
            {
                if (String.IsNullOrEmpty(_description))
                    return "";

                return _description; 
            }
            set { _description = value; }
        }
        private string _genre = "";
        public string Genre
        {
            get 
            {
                if (String.IsNullOrEmpty(_genre))
                    return ""; 
                
                return _genre; 
            }
            set { _genre = value; }
        }
        private string _rating = "";
        public string Rating
        {
            get 
            {
                if (String.IsNullOrEmpty(_rating))
                    return ""; 
                
                return _rating; 
            }
            set { _rating = value; }
        }

        //Full property syntax
        //private int _length;        
        //public int RunLength
        //{
        //    get { return _length; }
        //    set { _length = value; }
        //}

        //Auto property syntax
        public int RunLength { get; set; }

        //private int _releaseYear = 1900;
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        public int ReleaseYear { get; set; } = 1900;

        //private bool _isBlackAndWhite;
        //public bool IsBlackAndWhite
        //{
        //    get { return _isBlackAndWhite; }
        //    set { _isBlackAndWhite = value; }
        //}
        public bool IsBlackAndWhite { get; set; }

        //Calculated property
        public bool NeedsIntermission
        {
            //Runlength > 150
            get { return RunLength >= 150; }
            //set { }
        }

        //Properties - data with functionality
        

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
            //var title = "";

            //Title is required
            //if (String.IsNullOrEmpty(this.title))
            if (String.IsNullOrEmpty(_title))
                return "Title is required";

            //var releaseYear = 10;

            //Release Year >= 1900
            //if (this.releaseYear < 1900)
            if (ReleaseYear < 1900)
                return "Release Year must be >= 1900";

            //Length >= 0
            if (RunLength < 0)
                return "Length must be at least 0";

            //TODO: Rating is in a list

            //If ReleaseYear < 1940 then IsBlackAndWhite must be true
            if (ReleaseYear < 1940 && !IsBlackAndWhite)
                return "Movies before 1940 must be black and white";

            //Valid
            return "";
        }
    }
}