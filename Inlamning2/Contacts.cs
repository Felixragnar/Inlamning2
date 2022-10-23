using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning1
{
    internal class Contacts
    
    {   //Constructor
        public Contacts(string name, int number, string address, string email)
        {
            Name = name;
            Number = number;
            Address = address;
            Email = email;
        }

        public string Name { get; set; }    
        public int Number { get; set; }  
        public string Address { get; set; } 
        public string Email { get; set; }
        public override string ToString() //För att endast Name ska visas i listan
        {
            return Name;
        }
    }   
    
}
