// Movie data:
//  Title, genre, description, mpaa rating
//  Length, release year, budget
//  IsBlackAndWhite
// Operations: Add, edit, view, delete

//Movie details
string title = "", description = "";
string genre = "", rating = "";

Int32 len; // int len;
int length = 0, releaseYear = 1900;
bool isBlackAndWhite = false;

//Not using
//decimal budget = 125.45M;

//Entry point
var done = false;
do
{
    //int command = DisplayMenu();
    //if (command == 1)
    //    AddMovie();
    //else if (command == 2)
    //    EditMovie();
    //else if (command == 3)
    //    DeleteMovie();
    //else if (command == 4)
    //    ViewMovie();
    //else if (command == 0)
    //    done = true;
    switch (DisplayMenu())
    {
        case 1: AddMovie(); break;
        case 2: EditMovie(); break;
        case 3: DeleteMovie(); break;
        case 4: ViewMovie(); break;
        case 0:
        {
            done = true; 
            //Do more stuff here
            break;
        };

        default: Console.WriteLine("Unknown option"); break;
    };
} while (!done);

/// Functions

int DisplayMenu () 
{
    Console.WriteLine("-----------");
    Console.WriteLine("A)dd Movie");
    Console.WriteLine("E)dit Movie");
    Console.WriteLine("D)elete Movie");
    Console.WriteLine("V)iew Movie");
    Console.WriteLine("Q)uit");

    do
    {
        //var input = Console.ReadLine();
        //if (input == "A" || input == "a")
        //    return 1;
        //else if (input == "E" || input == "e")
        //    return 2;
        //else if (input == "D" || input == "d")
        //    return 3;
        //else if (input == "V" || input == "v")
        //    return 4;
        //else if (input == "Q" || input == "q")
        //    return 0;
        switch(Console.ReadKey(true).Key)
        {
            //case "A": //return 1;
            //case "a": return 1;
            case ConsoleKey.A: return 1;

            //case "E": //return 2;
            //case "e": return 2;
            case ConsoleKey.E: return 2;

            //case "D": //return 3;
            //case "d": return 3;
            case ConsoleKey.D: return 3;

            //case "V": //return 4;
            //case "v": return 4;
            case ConsoleKey.V: return 4;

            //case "Q": //return 0;
            //case "q": return 0;
            case ConsoleKey.Q: return 0;
        };
    } while (true);
}

//Get a new movie
void AddMovie ()
{    
    title = ReadString("Enter a title: ", true);    
    description = ReadString("Enter a description: ", false);
    
    length = ReadInt("Enter the run length (in mins): ", 0);
    releaseYear = ReadInt("Enter the release year: ", 1900);

    genre = ReadString("Enter a genre: ", false);
    rating = ReadRating("Enter a rating: ");

    isBlackAndWhite = ReadBoolean("Black and White (Y/N)?");
}

void EditMovie()
{
    Console.WriteLine("Not implemented yet");
}

void DeleteMovie()
{
    if (String.IsNullOrEmpty(title))
        return;

    if (!Confirm($"Are you sure you want to delete the movie '{title}' (Y/N)?"))
        return;

    title = "";
}

//Display the movie details
void ViewMovie ()
{
    // Length of a string
    int len = title.Length;

    if (String.IsNullOrEmpty(title))
    {
        Console.WriteLine("No movies available");
        return;
    };

    Console.WriteLine();
    //Console.WriteLine("--------------");
    Console.WriteLine("".PadLeft(15, '-'));
    
    //Console.WriteLine("\n--------------");

    Console.WriteLine(title);

    //String formatting
    //Run Length: ## mins
    //Console.WriteLine("Run Length: " + length + " mins");
    // 1. Concat or Join
    //Console.WriteLine("Run Length: " + length.ToString() + " mins");
    //var message = String.Concat("Run Length: ", length.ToString(), " mins");
    //Console.WriteLine(message);
    //var message2 = String.Join(" ", "Run Length:", length, "mins");
    // 2. String.Format
    //string message = String.Format("Run Length: {0} mins", length);
    //Console.WriteLine(message);
    //decimal price = 45.45252;
    //String.Format("{0:C}", price);  //$45.45
    //Console.WriteLine("Run Length: {0} mins", length);    
    // 3. String interpolation
    string message = $"Run Length: {length} mins";
    Console.WriteLine(message);

    //Released yyyy
    //Console.WriteLine("Released " + releaseYear);
    Console.WriteLine($"Released {releaseYear}");

    Console.WriteLine(genre);

    //MPAA Rating: 
    Console.WriteLine($"MPAA Rating: {rating}");

    //Black and White? 
    // Conditional: Eb ? Et : Ef
    //string format = "Color";
    //if (isBlackAndWhite)
    //    format = "Black and White";

    //V2
    string format = isBlackAndWhite ? "Black and White" : "Color";    
    Console.WriteLine("Format: ".PadLeft(10) + format);

    //V3
    //Console.WriteLine("Format: " + (isBlackAndWhite ? "Black and White" : "Color"));

    Console.WriteLine(description);

    //More string functions
    //string path1 = @"C:\temp";
    //string path2 = @"Windows";
    //if (!path1.EndsWith("\\"))
    //    path1 = path1 + "\\";
    //if (path2.StartsWith("\\"))
    //    ///path2 = path2.Substring(1);
    //    path2 = path2.Trim('\\');
    //string path3 = path1 + "\\" + path2;

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

        //NOT SAFE
        //int result = Int32.Parse(value);
        //int result;
        //if (Int32.TryParse(value, out result))
        if (Int32.TryParse(value, out var result))
        //if (int.TryParse(value, out var result))
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
        //if (value == "PG")
        // 1. String compare 1 -> Don't use
        //if (value.ToUpper() == "PG")
        //value = value.ToLower();
        //if (value == "pg")
        // 2. String compare 2 -> 
        //if (String.Compare(value, "PG", true) == 0) // String.Compare(value, "PG", StringComparison.CurrentCultureIgnoreCase)
        //if (value.CompareTo("PG") == 0)
        // 3. String Equals -> PREFERRED
        if (String.Equals(value, "PG", StringComparison.CurrentCultureIgnoreCase))
            return "PG";
        else if (String.Equals(value, "G", StringComparison.CurrentCultureIgnoreCase))
            return "G";
        else if (String.Equals(value, "PG-13", StringComparison.CurrentCultureIgnoreCase))
            return "PG-13";
        else if (String.Equals(value, "R", StringComparison.CurrentCultureIgnoreCase))
            return "R";
        //else if (value == "") // else if (value == String.Empty
        //else if (value == "" || value == null) //Don't do this
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
        //if (!isRequired)
        //    return value;

        ////Is it empty?
        //if (value != "")
        //    return value;

        Console.WriteLine("Value is required");
    } while (true);    
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