using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ProgramIsRunning = true;
            AdressBook ab = StartProgram();

            Console.WriteLine("--------- AdressBook 1.0 ---------");

            while (ProgramIsRunning)
            {
                // Print user options
                PrintUserOptions();
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ab.CreateUser();
                        break;
                    case "2":
                        ab.UpdateUserInformation();
                        break;
                    case "3":
                        ab.RemovePersonFromList();
                        break;
                    case "4":
                        ab.ShowAllPersonsInList();
                        break;
                    case "5":
                        ab.Search();
                        break;
                    case "6":
                        ab.SearchByName();
                    break;
                    case "7":
                        ab.SearchByNumber();
                    break;
                    case "x":
                        ProgramIsRunning = false;
                        break;
                }
            }
        }

        private static void PrintUserOptions()
        {
            Console.WriteLine("Choose one of the following options: ");
            Console.WriteLine("#1 Create new user");
            Console.WriteLine("#2 Edit user information");
            Console.WriteLine("#3 Delete existing user");
            Console.WriteLine("#4 Show all users in adressBook");
             Console.WriteLine("#5 Search By Address");
             Console.WriteLine("#6 Search By Name");
             Console.WriteLine("#7 Search By Number");
        }

        private static AdressBook StartProgram()
        {
            AdressBook ab = new AdressBook();

            //Start program by loading saved users from txt-file
            WriteAndReadToFile writer = new WriteAndReadToFile();
            writer.ReadFromFile(ab);
            return ab;
        }
    }
}