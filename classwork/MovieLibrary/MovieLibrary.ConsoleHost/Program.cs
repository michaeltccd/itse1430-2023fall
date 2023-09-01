// Movie data:
//  Title, genre, description, mpaa rating
//  Length, release year, budget
//  IsBlackAndWhite
// Operations: Add, edit, view, delete

string title = "", description = "";
//title = "";
string genre = "", rating = "";

int length = 0, releaseYear = 1900;

decimal budget = 125.45M;
bool isBlackAndWhite = false;

//Get movie details and display
GetMovie();
DisplayMovie();

/// Functions

//Get a new movie
void GetMovie ()
{    
    title = ReadString("Enter a title: ", true);    
    description = ReadString("Enter a description: ", false);
    
    length = ReadInt("Enter the run length (in mins): ", 0);
    releaseYear = ReadInt("Enter the release year: ", 1900);
}

//Display the movie details
void DisplayMovie ()
{
    Console.WriteLine(title);
    Console.WriteLine(description);
    Console.WriteLine(length);
}

//Functions run in isolation
// Parameters - Getting data into a function
// Return type - Getting data out of a function
int ReadInt ( string message, int minimumValue )
{
    Console.WriteLine(message);

    string value = Console.ReadLine();

    //NOT SAFE
    //int result = Int32.Parse(value);
    int result;
    if (Int32.TryParse(value, out result))
        if (result >= minimumValue)
            return result;

    //TODO: Input validation
    return 0;
}

string ReadString ( string message, bool isRequired )
{
    Console.WriteLine(message);

    string value = Console.ReadLine();

    if (!isRequired)
        return value;
    //else
    //    return "";

    //TODO: Input validation for required
    return value;
    //if (false)
    //{
    //    if (true)
    //        Console.WriteLine("");
    //} else
    //    Console.WriteLine("");
    //return Console.ReadLine();
}

//double someFloatingValue = 3.14159;
//char letterGrade = 'A';

//{
//    int hours = 5;
//    //int title = 54;
//    title = "Jaws";

//    Console.WriteLine(title);
//    Console.WriteLine(length);
//}
