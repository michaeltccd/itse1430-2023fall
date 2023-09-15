/*
 * ITSE 1430
 * Fall 2023
 * 
 * Sample movie library
 */
using MovieLibrary;

//TODO: Remove this
Movie movie = new Movie();

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
        switch(Console.ReadKey(true).Key)
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

    movie.title = ReadString("Enter a title: ", true);
    movie.description = ReadString("Enter a description: ", false);

    movie.length = ReadInt("Enter the run length (in mins): ", 0);
    movie.releaseYear = ReadInt("Enter the release year: ", 1900);

    movie.genre = ReadString("Enter a genre: ", false);
    movie.rating = ReadRating("Enter a rating: ");

    movie.isBlackAndWhite = ReadBoolean("Black and White (Y/N)?");

    return movie;
}

void EditMovie()
{
    Console.WriteLine("Not implemented yet");
}

bool DeleteMovie ( Movie movie )
{
    if (String.IsNullOrEmpty(movie.title))
        return false;

    if (!Confirm($"Are you sure you want to delete the movie '{movie.title}' (Y/N)?"))
        return false;

    //TODO: Delete movie
    //title = "";
    return true;
}

//Display the movie details
void ViewMovie ( Movie movie )
{
    if (String.IsNullOrEmpty(movie.title))
    {
        Console.WriteLine("No movies available");
        return;
    };

    Console.WriteLine();    
    Console.WriteLine("".PadLeft(15, '-'));
    
    Console.WriteLine(movie.title);

    string message = $"Run Length: {movie.length} mins";
    Console.WriteLine(message);
        
    Console.WriteLine($"Released {movie.releaseYear}");
    Console.WriteLine(movie.genre);
    Console.WriteLine($"MPAA Rating: {movie.rating}");

    string format = movie.isBlackAndWhite ? "Black and White" : "Color";    
    Console.WriteLine("Format: ".PadLeft(10) + format);

    Console.WriteLine(movie.description);
}

bool Confirm ( string message )
{
    return ReadBoolean(message);
}

//Functions run in isolation
// Parameters - Getting data into a function
// Return type - Getting data out of a function
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

string ReadRating ( string message )
{
    Console.WriteLine(message);

    do
    {
        string value = Console.ReadLine();
        if (String.Equals(value, "PG", StringComparison.CurrentCultureIgnoreCase))
            return "PG";
        else if (String.Equals(value, "G", StringComparison.CurrentCultureIgnoreCase))
            return "G";
        else if (String.Equals(value, "PG-13", StringComparison.CurrentCultureIgnoreCase))
            return "PG-13";
        else if (String.Equals(value, "R", StringComparison.CurrentCultureIgnoreCase))
            return "R";
        else if (String.IsNullOrEmpty(value))
            return "";

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

enum MenuCommand
{
    Add = 1,
    Edit,
    Delete,
    View,
    Quit = 0
}
#region Demo Code

//void Demo ()
//{
//Playing with strings
//string someValue = 10.ToString(); //"10"
//someValue = (4 + 5).ToString(); // "9"

////Escape characters
//someValue = "Hello\"Bob";
//string filePath = "C:\\windows\\temp";
//filePath = @"C:\windows\temp";  //Verbatim string
////filePath = """file="somevalue";file="somevalue2""""

//double someFloatingValue = 3.14159;
//char letterGrade = 'A';

//{
//    int hours = 5;
//    //int title = 54;
//    title = "Jaws";

//    Console.WriteLine(title);
//    Console.WriteLine(length);
//}


//Playing with strings 2
//string emptyValue;
//var areEqual = "" == String.Empty;  //true
//areEqual = "" == null;  //false
//}
#endregion