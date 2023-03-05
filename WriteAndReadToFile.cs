using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;


namespace Phone
{
    class WriteAndReadToFile
    {

        

        public void WriteUserToFile(Person person)
        {
            using (StreamWriter sw = File.AppendText(@"D:\files\phone\phone.txt"))
            {
                sw.WriteLine(person.FirstName + "," + person.LastName + "," +person.Number + "," + person.Adress + ",");
            }
        }

        public void ReadFromFile(AdressBook ab)
        {
            string textLine;
            try
            {
                using (StreamReader sr = new StreamReader(@"D:\files\phone\phone.txt"))
                {
                    while ((textLine = sr.ReadLine()) != null)
                    {
                        string[] userInformation = textLine.Split(',');
                        Person p = new Person(userInformation[0], userInformation[1],userInformation[2], userInformation[3]);
                        ab.AdressBookList.Add(p);
                    }
                }
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("File does not exist " + fnf);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong" + e);
            }
        }

        public void UpdateUserOnFile(List<Person> adressBookList)
        {
            // Remove old row
            using (StreamWriter sw = new StreamWriter(@"D:\files\phone\phone.txt"))
            {
                sw.Flush();
                foreach (var person in adressBookList)
                {
                    sw.WriteLine(person.FirstName + "," + person.LastName + "," +person.Number + "," + person.Adress + ",");
                }
            }
        }
    }
}