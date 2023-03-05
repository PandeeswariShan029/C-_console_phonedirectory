using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;


namespace Phone
{


     class AdressBook
    {
        public WriteAndReadToFile wtf;
        public List<Person> adressBookList = new List<Person>();
        public List<Person> AdressBookList
        {
            get { return adressBookList; }
            set { this.adressBookList = value; }
        }


        public AdressBook()
        {
            AdressBookList = new List<Person>();
            wtf = new WriteAndReadToFile();
        }

        // Create instance of Person-class and call AddPersonToList-method
        public void CreateUser()
        {
            int n;
            Console.WriteLine("Enter firstName:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter lastName:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter Contact Number:");
            var number = Console.ReadLine();

            n = number.Length;
            if(n!=10 && n!=7){
                Console.WriteLine("invalid number");
               Console.WriteLine("Enter Contact Number:");
                number = Console.ReadLine();
            }
            
            

            Console.WriteLine("Enter adress:");
            var adress = Console.ReadLine();

            Person person = new Person(firstName, lastName,number, adress);
            AddPersonToList(person);
            wtf.WriteUserToFile(person);

        }


        // Add new person to AdressBookList
        private void AddPersonToList(Person person) => AdressBookList.Add(person);

        //Remove user from list where first and last name match
        

        //Remove user from list where first and last name match
        public void RemovePersonFromList()
        {
            Console.WriteLine("Enter firstName of the user you want to remove");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter lastname of the user you want to remove");
            var lastName = Console.ReadLine();

            AdressBookList.RemoveAll(item => item.FirstName == firstName && item.LastName == lastName);
            wtf.UpdateUserOnFile(adressBookList);
        }

        //Show all Persons in AdressBookList
        public void ShowAllPersonsInList()
        {
            foreach (var person in AdressBookList)
            {
                Console.WriteLine("FirstName: {0}, LastName: {1},Number:{2}, Adress: {3}", person.FirstName, person.LastName,person.Number, person.Adress);
            }
        }

        public void UpdateUserInformation()
        {
            Console.WriteLine("Which information do you want to update?");
            Console.WriteLine("#1: Firstname, #2: Lastname,3# Number, 4# Adress");
            var userOption = Console.ReadLine();

            Console.WriteLine("Enter firstname on existing user to be updated");
            var oldFirstName = Console.ReadLine();
            UpdateUserFunction(userOption, oldFirstName);
        }

        private void UpdateUserFunction(string userOption, string oldFirstName)
        {
            var personsWithMatchingFirstName = AdressBookList.Where(person => person.FirstName == oldFirstName);
            string newValue;

            if (userOption == "1")
            {
                Console.WriteLine("Enter a new first Name");
                newValue = Console.ReadLine();

                foreach (var person in personsWithMatchingFirstName)
                {
                    person.FirstName = newValue;
                    wtf.UpdateUserOnFile(adressBookList);
                }
            }
            else if (userOption == "2")
            {
                Console.WriteLine("Enter a new last name");
                newValue = Console.ReadLine();

                foreach (var person in personsWithMatchingFirstName)
                {
                    person.LastName = newValue;
                    wtf.UpdateUserOnFile(adressBookList);
                }
            }
            else if (userOption == "3")
            {
                Console.WriteLine("Enter a new Number");
                newValue = Console.ReadLine();

                foreach (var person in personsWithMatchingFirstName)
                {
                    person.Number = newValue;
                    wtf.UpdateUserOnFile(adressBookList);
                }
            }
            else if (userOption == "4")
            {
                Console.WriteLine("Enter a new adress");
                newValue = Console.ReadLine();

                foreach (var person in personsWithMatchingFirstName)
                {
                    person.Adress = newValue;
                    wtf.UpdateUserOnFile(adressBookList);
                }
            }
        }
        

        
        public void Search()
        {
            Console.WriteLine("Enter the address you want to search");
            
            string ans= Console.ReadLine();
            string find = ans.ToLower();
             if (AdressBookList.Exists(person => person.Adress == find))
             {
                 foreach (Person person in AdressBookList )
                {
                    if (person.Adress == find)
                    {
                        Console.WriteLine("Contact Number :{0}\n" +
                        "First name :{1}\n" +
                        "Last Name:{2}\n"+
                        "Address :{3}\n" , person.Number, person.FirstName,person.LastName,person.Adress);
                    }
                }
            }
             }
             public void SearchByName()
           {
            Console.WriteLine("Enter the name you want to search");
            
            string ans= Console.ReadLine();
            string find = ans.ToLower();
             if (AdressBookList.Exists(person => person.FirstName == find))
             {
                 foreach (Person person in AdressBookList )
                {
                    if (person.FirstName == find)
                    {
                        Console.WriteLine("Contact Number :{0}\n" +
                        "First name :{1}\n" +
                        "Last Name:{2}\n"+
                        "Address :{3}\n" , person.Number, person.FirstName,person.LastName,person.Adress);
                    }
                }
            }
             }
             public void SearchByNumber()
           {
            Console.WriteLine("Enter the number you want to search");
            
            string ans= Console.ReadLine();
            string find = ans.ToLower();
             if (AdressBookList.Exists(person => person.Number == find))
             {
                 foreach (Person person in AdressBookList )
                {
                    if (person.Number == find)
                    {
                        Console.WriteLine("Contact Number :{0}\n" +
                        "First name :{1}\n" +
                        "Last Name:{2}\n"+
                        "Address :{3}\n" , person.Number, person.FirstName,person.LastName,person.Adress);
                    }
                }
            }
             }
        }
    }
