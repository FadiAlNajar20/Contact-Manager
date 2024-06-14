# Contact-Manager

### Contacts-Manager

#### Overview
This project is a console application that functions as a contact manager, developed using Test Driven Development (TDD). The application allows users to add, remove, view for contacts.

#### Features
- **Add Contact**: Adds a new contact to the list.
- **Remove Contact**: Removes an existing contact from the list.
- **View All Contacts**: Displays all contacts in the list.

#### Program Structure
- **ContactManager/Program.cs**: Contains the main logic for managing contacts.
- **ContactManagerTests**: Contains unit tests for verifying the functionality of the contact management methods using Xunit.

#### Methods
- **AddContact(string contact)**: Adds a new contact to the list. Returns the updated list of contacts or an error message if the contact is invalid or already exists.
- **RemoveContact(string contact)**: Removes a contact by name. Returns the updated list of contacts.
- **ViewAllContacts()**: Returns a list of all contacts.

#### Usage
1. **Clone the repository**:
    ```sh
    git@github.com:FadiAlNajar20/Contact-Manager.git
    ```
2. **Navigate to the project directory**:
    ```sh
    cd Contacts-Manager
    ```
3. **Build and run the application**:
    ```sh
    dotnet run --project ContactManager
    ```

#### Unit Tests
To run the unit tests, use the following command:
```sh
dotnet test
```

The tests cover the following scenarios:
- Adding a new contact
- Removing a contact
- Viewing all contacts
- Preventing duplicate contacts
- Handling empty contact inputs

### Code Implementation

#### ContactManager/Program.cs
```csharp
using System;
using System.Collections.Generic;

namespace ContactManager
{
    public class Program
    {
        private static List<string> contacts = new List<string>();

        static void Main(string[] args)
        {
            ContactsManager();
            Console.ReadKey();
        }

        public static void ContactsManager()
        {
            // Add Contact
            AddContact("John Wick");
            AddContact("John Smith");
            AddContact("John Smith"); // Should not be added
            AddContact("Some one");
            AddContact(""); // Should not be added

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List of Contact: ");
            Console.ResetColor();

            PrintAllContacts();

            // Remove Contact 
            RemoveContact("Some one");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUpdate list after deletion: ");
            Console.ResetColor();

            PrintAllContacts();

            // Try to Remove Contact with the same name
            RemoveContact("Some one");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUpdate List of Contact:");
            Console.ResetColor();

            PrintAllContacts();
        }

        public static List<string> AddContact(string contact)
        {
            if (string.IsNullOrWhiteSpace(contact))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot add an empty contact.\n");
                Console.ResetColor();
                return contacts;
            }

            if (contacts.Contains(contact))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The name already exists: {contact}\n");
                Console.ResetColor();
                return contacts;
            }

            contacts.Add(contact);
            return contacts;
        }

        public static List<string> RemoveContact(string contact)
        {
            if (contacts.Contains(contact))
            {
                contacts.Remove(contact);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nWarning: No one who has this name --> {contact}");
                Console.ResetColor();
            }
            return contacts;
        }

        public static List<string> ViewAllContacts()
        {
            return new List<string>(contacts);
        }

        public static void PrintAllContacts()
        {
            var allContacts = ViewAllContacts();
            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}
```

#### ContactManagerTests/UnitTest1.cs
```csharp
using ContactManager;
using System;
using Xunit;

namespace ContactManagerTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddContact()
        {
            // Arrange
            ContactManager.Program.AddContact("John");

            // Act
            var result = ContactManager.Program.AddContact("Jane");

            // Assert
            Assert.Contains("Jane", result);
        }

        [Fact]
        public void TestAddDuplicateContact()
        {
            // Arrange
            ContactManager.Program.AddContact("John");

            // Act
            var result = ContactManager.Program.AddContact("John");

            // Assert
            Assert.Equal(4, result.Count);
        }

        [Fact]
        public void TestAddEmptyContact()
        {
            // Act
            var result = ContactManager.Program.AddContact("");

            // Assert
            Assert.DoesNotContain("", result);
        }

        [Fact]
        public void TestRemoveExistingContact()
        {
            // Arrange
            ContactManager.Program.AddContact("John");

            // Act
            var result = ContactManager.Program.RemoveContact("John");

            // Assert
            Assert.DoesNotContain("John", result);
        }

        [Fact]
        public void TestRemoveNonExistingContact()
        {
            // Arrange
            ContactManager.Program.AddContact("John");

            // Act
            var result = ContactManager.Program.RemoveContact("Jane");

            // Assert
            Assert.Contains("John", result);
        }

        [Fact]
        public void TestViewAllContacts()
        {
            // Arrange
            ContactManager.Program.AddContact("John Doe");
            ContactManager.Program.AddContact("Jane Doe");

            // Act
            var result = ContactManager.Program.ViewAllContacts();

            // Assert
            Assert.Contains("John Doe", result);
            Assert.Contains("Jane Doe", result);
        }
    }
}
```