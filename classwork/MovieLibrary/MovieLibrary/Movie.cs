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
    public class Movie : ValidatableObject
    {
        //ctors - initialize instances

        //Default constructor
        public Movie ()// : base("")
        {
            //init anything that field inits won't work with
            _initialized = true;
        }

        /// <summary>Initializes the Movie class.</summary>
        /// <param name="id">Identifier of the movie.</param>
        public Movie ( int id ) : this(id, "")
        {
            //Id = id;
            //Initialize(id, "");
        }

        public Movie ( string title ) : this(0, title)
        {
            //Title = title;
            //Initialize(0, title);
        }

        public Movie ( int id, string title ) : this()
        {
            //Initialize(id, title);
            Id = id;
            Title = title;            
        }

        //private void Initialize ( int id, string title )
        //{
        //    Id = id;
        //    Title = title;

        //    _initialized = true;
        //}

        //Properties - field like syntax with method functionality
        //  property_defn ::= full_property | auto_property
        //
        //  full_property ::= [mods] T id { [ getter ] [ setter ] }
        //  getter ::= get { S* }  
        //  setter ::= set { S* }  
        //
        //  auto_property ::= [mods] T id { [ get; ] [ set; ] } [ = Et ;]

        /// <summary>Gets or sets the unique identifier of the movie.</summary>
        public int Id { 
            //Mixed accessibility - getter/setter has different access than property
            get;
            /*set;*/
            private set;
        }

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

        /// <summary>Gets or sets the optional description.</summary>
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

        /// <summary>Gets or sets the genre.</summary>
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

        /// <summary>Gets or sets the MPAA rating.</summary>
        //public string Rating
        //{
        //    get 
        //    {
        //        if (String.IsNullOrEmpty(_rating))
        //            return ""; 
                
        //        return _rating; 
        //    }
        //    set { _rating = value; }
        //}
        public Rating Rating { get; set; }
        
        /// <summary>Gets or sets the run length.</summary>
        /// <value>Must be at least zero.</value>
        public int RunLength { get; set; }

        //private int _releaseYear = 1900;
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Must be at least 1900.</value>
        public int ReleaseYear { get; set; } = MinimumReleaseYear;

        //private bool _isBlackAndWhite;
        //public bool IsBlackAndWhite
        //{
        //    get { return _isBlackAndWhite; }
        //    set { _isBlackAndWhite = value; }
        //}

        /// <summary>Determines if the movie is black and white or color.</summary>
        public bool IsBlackAndWhite { get; set; }

        //Calculated property
        /// <summary>Determines if the movie needs an intermission.</summary>
        /// <value>Any movie that is at least 2 and a half hours needs an intermission.</value>
        public bool NeedsIntermission
        {
            //Runlength > 150
            get { return RunLength >= 150; }
            //set { }  //Optional
        }

        //Fields - data        
        
        /// <summary>Minimum release year.</summary>
        public const int MinimumReleaseYear = 1900;

        //Const - compile time constant, must recompile to change
        //Readonly - runtime constant, do not recompile to change
        //public const string DefaultRating = "PG";
        public readonly string DefaultRating = "PG";

        //  field_defn ::= [mods] T id [ = Et ];
        private string _title;
        private string _description = "";
        private string _genre = "";
        private string _rating = "";

        private readonly bool _initialized = false;

        //Methods - functionality

        /// <summary>Download metadata from Internet.</summary>
        /// <remarks>
        /// Searches IMDB and TheTVDB.com.
        /// </remarks>
        private void DownloadMetadata ()
        {
            //Initialize(0, "");
        }

        /// <summary>Validates the movie instance.</summary>
        /// <returns>Error message if invalid or empty string otherwise.</returns>
        public override bool TryValidate ( out string message ) /* Movie this */
        {
            //this.OnlyVisibleToDerivedTypes();
            //var title = "";

            //Title is required
            //if (String.IsNullOrEmpty(this.title))
            if (String.IsNullOrEmpty(_title))
            {
                message = "Title is required";
                return false;
            };

            //var releaseYear = 10;

            //Release Year >= 1900
            //if (this.releaseYear < 1900)
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

            //TODO: Rating is in a list

            //If ReleaseYear < 1940 then IsBlackAndWhite must be true
            if (ReleaseYear < 1940 && !IsBlackAndWhite)
            {
                message = "Movies before 1940 must be black and white";
                return false;
            };

            //Valid
            return base.TryValidate(out message);
            //message = "";
            //return true;
        }
    }
}