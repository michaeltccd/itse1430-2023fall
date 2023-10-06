/*
 * ITSE 1430
 * Fall 2023
 * 
 * Sample movie library
 */

namespace MovieLibrary.ConsoleHost;

class Program
{
    static void Main ()
    {
        var app = new Program();
        app.Run();
    }

    void Run ()
    {
        //TODO: Remove this
        Movie movie = null; //= new Movie();

        //Entry point
        var done = false;
        do
        {
            switch (DisplayMenu())
            {
                case MenuCommand.Add: movie = AddMovie(); break;
                case MenuCommand.Edit: EditMovie(); break;
                case MenuCommand.Delete:
                {
                    //TODO: Clean this up
                    if (DeleteMovie(movie))
                        movie = new Movie();
                    break;
                };
                case MenuCommand.View: ViewMovie(movie); break;
                case MenuCommand.Quit:
                {
                    done = true;
                    break;
                };

                default: Console.WriteLine("Unknown option"); break;
            };
        } while (!done);
    }

    /// Functions

    MenuCommand DisplayMenu ()
    {
        Console.WriteLine("-----------");
        Console.WriteLine("A)dd Movie");
        Console.WriteLine("E)dit Movie");
        Console.WriteLine("D)elete Movie");
        Console.WriteLine("V)iew Movie");
        Console.WriteLine("Q)uit");

        do
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.A: return MenuCommand.Add;
                case ConsoleKey.E: return MenuCommand.Edit;
                case ConsoleKey.D: return MenuCommand.Delete;
                case ConsoleKey.V: return MenuCommand.View;
                case ConsoleKey.Q: return MenuCommand.Quit;
            };
        } while (true);
    }

    //Get a new movie
    Movie AddMovie ()
    {
        var movie = new Movie();
        //var movie = new Movie(10, "Something");
        //movie.Title = "Something";
        //movie.Description = "Something";

        do
        {
            movie.Title = ReadString("Enter a title: ", true);
            movie.Description = ReadString("Enter a description: ", false);

            movie.RunLength = ReadInt("Enter the run length (in mins): ", 0);
            movie.ReleaseYear = ReadInt("Enter the release year: ", Movie.MinimumReleaseYear);

            movie.Genre = ReadString("Enter a genre: ", false);
            movie.Rating = ReadRating("Enter a rating: ");
            //if (movie.Rating != null)
            //    movie.Rating.Name = "Whatever";

            movie.IsBlackAndWhite = ReadBoolean("Black and White (Y/N)?");
            //movie.NeedsIntermission = true;

            //Validate
            ValidatableObject validInstance = movie;
            //validInstance.Only
            var error = validInstance.Validate();   //Validate(movie)
            if (String.IsNullOrEmpty(error))
                return movie;

            Console.WriteLine($"ERROR: {error}");
        } while (true);
    }

    void EditMovie ()
    {
        Console.WriteLine("Not implemented yet");
    }

    bool DeleteMovie ( Movie movie )
    {
        //if (String.IsNullOrEmpty(movie.Title))
        if (movie == null)
            return false;

        if (!Confirm($"Are you sure you want to delete the movie '{movie.Title}' (Y/N)?"))
            return false;

        //TODO: Delete movie
        //title = "";
        return true;
    }

    //Display the movie details
    void ViewMovie ( Movie movie )
    {
        //if (String.IsNullOrEmpty(movie.Title))
        if (movie == null)
        {
            Console.WriteLine("No movies available");
            return;
        };

        //var len = movie?.RunLength;
        //movie?.Validate();

        //movie.DownloadMetadata();    

        Console.WriteLine();
        Console.WriteLine("".PadLeft(15, '-'));

        Console.WriteLine(movie.Title);

        string message = $"Run Length: {movie.RunLength} mins";
        Console.WriteLine(message);
        if (movie.NeedsIntermission)
            Console.WriteLine("Includes intermission");

        Console.WriteLine($"Released {movie.ReleaseYear}");
        Console.WriteLine(movie.Genre);
        Console.WriteLine($"MPAA Rating: {movie.Rating}");

        string format = movie.IsBlackAndWhite ? "Black and White" : "Color";
        Console.WriteLine("Format: ".PadLeft(10) + format);

        Console.WriteLine(movie.Description);
    }

    bool Confirm ( string message )
    {
        return ReadBoolean(message);
    }

    //Functions run in isolation
    // Parameters - Getting data into a function
    // Return type - Getting data out of a function

    /// <summary>Reads a boolean value.</summary>
    /// <param name="message">Message to show.</param>
    /// <returns>Returns true if the value was true or false otherwise.</returns>
    bool ReadBoolean ( string message )
    {
        Console.WriteLine(message);

        //Handle errors
        while (true)
        {
            //string value = Console.ReadLine();
            //var value = Console.ReadLine();
            //if (value == "Y" || value == "y")
            //    return true;
            //else if (value == "N" || value == "n")  // value == "N" || "n"
            //    return false;
            switch (Console.ReadKey(true).Key)
            {
                //case "Y":
                //case "y": return true;
                case ConsoleKey.Y: return true;

                case ConsoleKey.N: return false;
                //case "N":
                //case "n": return false;            
            };

            //Console.WriteLine("Please enter Y/N");

            ////Stops current iteration, exits loop
            //if (false)
            //    break;

            ////Stops current iteration, loops around and tries again
            //if (false)
            //    continue;
        };
    }

    int ReadInt ( string message, int minimumValue )
    {
        Console.WriteLine(message);

        do
        {
            string value = Console.ReadLine();

            if (Int32.TryParse(value, out var result))
                if (result >= minimumValue)
                    return result;

            Console.WriteLine("Value must be at least " + minimumValue);
        } while (true);
    }

    Rating ReadRating ( string message )
    {
        Console.WriteLine(message);

        do
        {
            string value = Console.ReadLine();
            if (String.Equals(value, "PG", StringComparison.CurrentCultureIgnoreCase))
                return Rating.PG;
            else if (String.Equals(value, "G", StringComparison.CurrentCultureIgnoreCase))
                return Rating.G;
            else if (String.Equals(value, "PG-13", StringComparison.CurrentCultureIgnoreCase))
                return Rating.PG13;
            else if (String.Equals(value, "R", StringComparison.CurrentCultureIgnoreCase))
                return Rating.R;
            else if (String.IsNullOrEmpty(value))
                return null;

            Console.WriteLine("Invalid rating");
        } while (true);
    }

    string ReadString ( string message, bool isRequired )
    {
        Console.WriteLine(message);

        do
        {
            string value = Console.ReadLine().Trim();

            if (!isRequired || !String.IsNullOrEmpty(value))
                return value;

            Console.WriteLine("Value is required");
        } while (true);
    }

    void Display ( object value )
    {
        //If a string call ToString
        //If an int call ToString() with minimum 2 digits
        //if a float call ToString() with 2 digits precision
        //if boolean then print Yes or No
        //Otherwise ToString()

        //Type checking/casting
        // 1. is_expression ::= E is T (boolean)
        // Cast 2. c_style ::= (T)E
        // 3. as_expression ::= E as T (T)
        // 4. pattern_matching ::= E is T id (boolean with side effect of id = (T)E)

        //if (value is string)
        //{
        //    //Is a string - dangerous
        //    //var valueString = (string)value;
        //    var valueString = value as string;
        //    Console.WriteLine(valueString);

        //    //string x = "Hello";
        //    //int y = (int)x;
        //};
        //
        // Approach 3
        //var valueString = value as string;
        //if (valueString != null)
        //{
        //    Console.WriteLine(valueString);
        //};

        // Pattern match (PREFERRED)
        if (value is string str)
        {
            Console.WriteLine(str);
        } else if (value is int i)
        {
            Console.WriteLine(i);
        };

        //if (value is int)
        //{
        //    //Blows up if it fails
        //    int y = (int)value;
        //};
        //var intValue = value as int;
    }
}