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
                    Console.WriteLine("\n1. Create New Address Book \n2. Use Existing Address Book   \n3. search over multiple addressbook \n4. person by city \n5. person by state \n6. Exit");
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
                    else if(choice == 3)
                    {
                        Console.WriteLine("enter city or state to search contact");
                        string cityOrstate = Console.ReadLine();
                        switchbook.GetByCityOrState(cityOrstate);
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("enter city to search contacts by city");
                        string city = Console.ReadLine();
                        switchbook.SetContactByCityDictionary(city);
                        //count of contacts in each city
                        foreach (var conByCity in switchbook.ContactByCity)
                        {
                            Console.WriteLine("City :" + conByCity.Key + "   Count :" + conByCity.Value.Count);

                        }

                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("enter state to search contacts by state");
                        string state = Console.ReadLine();
                        switchbook.SetContactByStateDictionary(state);
                        //count of all contacts in each state
                        foreach (var conByState in switchbook.ContactByState)
                        {
                            Console.WriteLine("state :" + conByState.Key + "   Count :" + conByState.Value.Count);

                        }

                    }
                    else if (choice == 6)
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
