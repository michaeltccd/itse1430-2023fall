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

//Get the title
Console.WriteLine("Enter a title: ");
title = Console.ReadLine();

Console.WriteLine("Enter a description: ");
description = Console.ReadLine();

//TODO: Fix length
Console.WriteLine("Enter the run length (in mins): ");
string lengthString = Console.ReadLine();

Console.WriteLine(title);
Console.WriteLine(description);
Console.WriteLine(lengthString);

//double someFloatingValue = 3.14159;
//char letterGrade = 'A';

//{
//    int hours = 5;
//    //int title = 54;
//    title = "Jaws";

//    Console.WriteLine(title);
//    Console.WriteLine(length);
//}
