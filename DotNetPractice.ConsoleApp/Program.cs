using DotNetPractice.ConsoleApp;
using System.Data;
using System.Data.SqlClient;


AdoDotNetProgram adoDotNetProgram = new AdoDotNetProgram();

Console.WriteLine("\t*** Welcome to Our Database CRUD with AdoDotNet ***\n");

Console.WriteLine("Choose the following one of numbers to take action: ");
Console.WriteLine("0. Close the program");
Console.WriteLine("1. Read Data");
Console.WriteLine("2. Write Data");
Console.WriteLine("3. Update Data");

Console.Write("\nEnter a number: ");
string user_input = Console.ReadLine();

Console.WriteLine(user_input);
