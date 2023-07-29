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
        public List<Contact> RelatedContacts { get; set; } // New property for related contacts

        public Contact()
        {
            RelatedContacts = new List<Contact>();
        }
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
            ContactManager contactManager = new ContactManager();

            // Creating individual contacts
            Individual individual1 = new Individual
            {
                Name = "John Doe",
                Address = "123 Main St",
                PhoneNumbers = new List<PhoneNumber>
                {
                    new PhoneNumber { Title = "Work", Number = "555-1234" },
                    new PhoneNumber { Title = "Home", Number = "555-5678" }
                },
                Emails = new List<Email>
                {
                    new Email { Title = "Work", Address = "john.doe@work.com" },
                    new Email { Title = "Personal", Address = "john.doe@gmail.com" }
                }
            };

            Individual individual2 = new Individual
            {
                Name = "Jane Smith",
                Address = "456 Oak Ave",
                PhoneNumbers = new List<PhoneNumber>
                {
                    new PhoneNumber { Title = "Work", Number = "555-9876" },
                    new PhoneNumber { Title = "Mobile", Number = "555-5432" }
                },
                Emails = new List<Email>
                {
                    new Email { Title = "Personal", Address = "jane.smith@gmail.com" }
                }
            };

            // Creating a company with contacts
            Company company1 = new Company
            {
                Name = "ABC Corp",
                Address = "789 Elm Rd",
                PhoneNumbers = new List<PhoneNumber>
                {
                    new PhoneNumber { Title = "Main Office", Number = "555-1111" },
                    new PhoneNumber { Title = "HR", Number = "555-2222" }
                },
                Emails = new List<Email>
                {
                    new Email { Title = "General", Address = "info@abccorp.com" }
                },
                Contacts = new List<Individual> { individual1, individual2 }
            };

            // Establishing relationship between contacts
            company1.Contacts[0].Company = company1; // John Doe works at ABC Corp
            company1.Contacts[1].Company = company1; // Jane Smith works at ABC Corp

            // Adding contacts to the ContactManager
            contactManager.AddContact(individual1);
            contactManager.AddContact(individual2);
            contactManager.AddContact(company1);

            // Searching contacts
            string searchTerm = "John";
            List<Contact> searchResults = contactManager.SearchContacts(searchTerm);

            Console.WriteLine("Search Results:");
            foreach (var contact in searchResults)
            {
                Console.WriteLine($"Name: {contact.Name}, Type: {contact.GetType().Name}");
            }
        }
    }
}
