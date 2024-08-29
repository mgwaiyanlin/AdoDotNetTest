using DotNetPractice.ConsoleApp;
using System.Data;
using System.Data.SqlClient;


AdoDotNetProgram adoDotNetProgram = new AdoDotNetProgram();

//adoDotNetProgram.UpdateData(2, "Updated Title", "Updated Author", "Updated Blog Content");
adoDotNetProgram.DeleteData(1);
//Console.WriteLine("\t*** Welcome to Our Database CRUD with AdoDotNet ***\n");

//Console.WriteLine("Choose the following one of numbers to take action: ");
//Console.WriteLine("0. Close the program");
//Console.WriteLine("1. Read Data");
//Console.WriteLine("2. Create Data");
//Console.WriteLine("3. Update Data");

//Console.Write("\nEnter a number: ");
//int user_input = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine(user_input);

//switch (user_input)
//{
//    case 0:
//        adoDotNetProgram.CloseProgram();
//        break;
//    case 1:
//        adoDotNetProgram.ReadData();
//        break;
//    default:
//        Console.WriteLine("Invalid Input!!! :(");
//        break;
//}
