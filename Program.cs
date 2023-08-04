using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

class Program
{
    private static List<Contact> contacts = new List<Contact>();

    static void Main()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Contact Book Application");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ViewContacts();
                    break;
                case "3":
                    UpdateContact();
                    break;
                case "4":
                    DeleteContact();
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddContact()
    {
        Console.WriteLine("Enter the contact details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        Contact newContact = new Contact
        {
            Name = name,
            PhoneNumber = phoneNumber,
            Email = email
        };

        contacts.Add(newContact);
        Console.WriteLine("Contact added successfully.");
    }

    static void ViewContacts()
    {
        Console.WriteLine("Contact List:");
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine();
            }
        }
    }

    static void UpdateContact()
    {
        Console.Write("Enter the name of the contact to update: ");
        string nameToUpdate = Console.ReadLine();

        Contact contactToUpdate = contacts.Find(c => c.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));

        if (contactToUpdate == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine("Enter the updated contact details:");
        Console.Write("Name: ");
        contactToUpdate.Name = Console.ReadLine();
        Console.Write("Phone Number: ");
        contactToUpdate.PhoneNumber = Console.ReadLine();
        Console.Write("Email: ");
        contactToUpdate.Email = Console.ReadLine();

        Console.WriteLine("Contact updated successfully.");
    }

    static void DeleteContact()
    {
        Console.Write("Enter the name of the contact to delete: ");
        string nameToDelete = Console.ReadLine();

        Contact contactToDelete = contacts.Find(c => c.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

        if (contactToDelete == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        contacts.Remove(contactToDelete);
        Console.WriteLine("Contact deleted successfully.");
    }
}
