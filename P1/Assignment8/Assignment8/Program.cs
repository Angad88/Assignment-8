using System;
using System.Collections.Generic;

namespace Assignment8
{
    public abstract class Contact
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Email> Emails { get; set; }
    }

    public class Company : Contact
    {
        public List<Individual> Contacts { get; set; }
    }

    public class Individual : Contact
    {
        public Company Company { get; set; }
    }

    public class PhoneNumber
    {
        public string Title { get; set; }
        public string Number { get; set; }
    }

    public class Email
    {
        public string Title { get; set; }
        public string Address { get; set; }
    }

    public class ContactManager
    {
        private List<Contact> contacts;

        public ContactManager()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            contacts.Remove(contact);
        }

        public List<Contact> SearchContacts(string searchTerm)
        {
            List<Contact> searchResults = new List<Contact>();

            foreach (var contact in contacts)
            {
                if (contact.Name.Contains(searchTerm))
                {
                    searchResults.Add(contact);
                }
            }

            return searchResults;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            { 
            }
        }
    }
}

