using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Inlamning1
{
    internal class AddressBook
    {
        private List<Contacts>? _contacts { get; set; } = new List<Contacts>(); //skapar listan med kontakter

        private void DisplayContactDetails(Contacts contact)
        {
            Console.WriteLine($"Contact number: {contact.Number} \nName: {contact.Name} \nEmail: {contact.Email} \nAddress: {contact.Address} \n \n");   //visa kontakt (all info, en kontakt)
        }
        public void AddContact(string name, string address, string email) //beräknar nästa nummer samt lägger till kontakt i listan
        {
            int nextContactNumber;
            if (_contacts.Count == 0)
            { 
                nextContactNumber = 1;
            }
            else
            {
                nextContactNumber = _contacts.LastOrDefault().Number + 1;
            }
            var newContact = new Contacts(name, nextContactNumber, address, email);
            _contacts?.Add(newContact);
        }


        public void DisplayContact(int contactNumber) //metod som visar fullständig kontaktinformation
        {
            var contact = _contacts.FirstOrDefault(c => c.Number == contactNumber);
            if (contact == null)
            {
                Console.Clear();
                Console.WriteLine("There are no contacts that match that number.");  //användaren finns inte-meddelande
                Console.ReadKey();
                    
            }
            else
            {
                Console.Clear();
                DisplayContactDetails(contact);
                Console.ReadKey();
            }
        }



        public void DisplayAllContacts(ListBox ContactList) //metod som visar alla kontakter (endast namn + email)
        {
            if (_contacts.Count == 0)
            {
                
            }

            else
            {             
                foreach (var contact in _contacts)
                {
                    ContactList.Items.Add(contact);
                }
            }
        }

        public void DisplayMatchingContacts(string searchPhrase)  //visar detaljerad information för kontakter som sökningen matchar
        {
            var matchingContacts = _contacts.Where(c => c.Name == (searchPhrase)).ToList();
            if (matchingContacts.Count == 0)
            {
                Console.WriteLine("There are no contacts that match your search.");
            }
            else
            {
                foreach (var contact in matchingContacts)
                {
                    DisplayContactDetails(contact);
                }
            }
        }
        //KAN SKAPA EN SÖKFUNKTION SOM ENDAST ANVÄNDER CONTACT.NUMBER

        public void DisplaySpecificContact(string searchNumber)  //visar detaljerad information för endast en kontakt
        {
            var matchingContacts = _contacts.Where(c => c.Name == (searchNumber)).ToList();
            foreach (var contact in matchingContacts)
            {
                DisplayContactDetails(contact);
            }
        }

        public void DeleteContact(int searchNumber) 
        {
            _contacts.RemoveAll(c => c.Number == searchNumber);
        }
        public void EditContact(int searchNumber, string name, string address, string email)
        {
            _contacts.FirstOrDefault(c => c.Number == searchNumber).Name = name;
            _contacts.FirstOrDefault(c => c.Number == searchNumber).Address = address;
            _contacts.FirstOrDefault(c => c.Number == searchNumber).Email = email;
        }

    }
}
