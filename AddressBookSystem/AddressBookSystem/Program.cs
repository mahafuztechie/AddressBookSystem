// See https://aka.ms/new-console-template for more information
using AddressBookSystem;
using System.Collections;

namespace AddressBookSystem
{
    class Program
    {
        //method to perform all CRUD operations on Contacts
        public static void AddressBook(Contacts cont)
        {
            bool flag = true;
            int choice;
           
            //Menu to display for the user
            while (flag)
            {
                //tryblock to check if any  exception occur
                try
                {
                    Console.WriteLine("\n1. Display All Contacts\n2. Add New Contact\n3. Edit Contact\n4. Delete Contact\n5. Exit");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        cont.DisplayContacts();
                    }
                    else if (choice == 2)
                    {
                        cont.AddContact();
                    }
                    else if (choice == 3)
                    {
                        cont.EditContact();
                    }
                    else if (choice == 4)
                    {
                        cont.DeleteContact();
                    }
                    else if (choice == 5)
                    {
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                //handling the occured exception And print to console
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message + "\n" + e.StackTrace);
                }
            }
        }
        static void Main(string[] args)
        {
            AddressBookDetails switchbook = new AddressBookDetails();

            bool flag = true;
            int choice;

            while (flag)
            {
                //tryblock to check any if exceptions occur
                try
                {
                    Console.WriteLine("\n1. Create New Address Book \n2. Use Existing Address Book \n3. Exit");
                    choice = int.Parse(Console.ReadLine());
                    //creating New address book
                    if (choice == 1)
                    {
                        Contacts contact = new Contacts();
                        Console.Write("\nEnter New Address Book's Name: ");
                        string addressBookName = Console.ReadLine();
                        switchbook.AddNewAddressBook(addressBookName, contact);
                        Console.WriteLine("Successfully created " + addressBookName + "\tUsing Address Book " + addressBookName);
                        AddressBook(contact);
                    }
                    //using existing addressbook
                    else if (choice == 2)
                    {
                        Console.Write("\nEnter Address Book's Name: ");
                        string addressBookName = Console.ReadLine();
                        Contacts contact = switchbook.GetAddressBook(addressBookName);
                        if (contact != null)
                        {
                            Console.WriteLine("Using Address Book " + addressBookName);
                            AddressBook(contact);
                        }
                        else
                            Console.WriteLine("There is no Book with name " + addressBookName);
                    }
                    else if (choice == 3)
                    {
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                // catch block to handle exception
                catch (Exception e)
                {
                    Console.WriteLine("Invalid data entered. Error: " + e.Message + "\n" + e.StackTrace);
                }
            }


        }

    }
}
