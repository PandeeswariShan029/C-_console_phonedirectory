using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

    namespace Phone
{ 
   public  class Person
    { 
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Number { get; set; }
    public string Adress { get; set; }
    

    public Person(string firstName, string lastName,string number, string adress)
    {
        int n;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Number = number;
        this.Adress = adress;
        n = Number.Length;
        
        
    }
    
}
}