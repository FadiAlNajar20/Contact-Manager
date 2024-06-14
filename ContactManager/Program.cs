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
