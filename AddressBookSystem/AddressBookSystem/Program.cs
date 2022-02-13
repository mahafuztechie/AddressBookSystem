// See https://aka.ms/new-console-template for more information
using AddressBookSystem;
using System.Collections;

namespace AddressBookSystem
{
    class Program
    {
        public static string filePath = @"C:\Users\dell\source\repos\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBookSystem\ContactList.txt";
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
                    Console.WriteLine("\n1. Display All Contacts\n2. Add New Contact\n3. Edit Contact\n4. Delete Contact\n5. sort by name \n6. sort by city\n7. sort by state \n8. sort by zipcode\n9.  Exit");
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
                        cont.SortByName();
                    }
                    else if (choice == 6)
                    {
                        cont.SortByCity();
                    }
                    else if (choice == 7)
                    {
                        cont.SortByState();
                    }
                    else if (choice == 8)
                    {
                        cont.SortByZipCode();
                    }
                    else if (choice == 9)
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
                    Console.WriteLine("\n1. Create New Address Book \n2. Use Existing Address Book   \n3. Display all Address book \n4. Person by city \n5. Person by state \n6. write Contacts to Text File \n7. Read from text file \n8. Write Contacts in CSV File \n9. Read from csv file \n10. Write in json file \n11. Read from Json file \n12. Exit");
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
                        switchbook.DisplayAllAddressBook();
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
                        // writing to text file if file exists
                        if (File.Exists(filePath))
                        {
                            using (StreamWriter stw = File.CreateText(filePath))
                            {
                                foreach (KeyValuePair<string, Contacts> kv in switchbook.getAllAddressBook())
                                {
                                    string a = kv.Key;

                                    stw.WriteLine("Address Book Name: " + a);
                                    foreach (Contacts c in kv.Value.getContacts())
                                    {
                                        stw.WriteLine(c);
                                    }
                                }
                                Console.WriteLine("Address Book written into the file successfully!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("File doesn't exist!!!");
                        }
                    }
                    else if (choice == 7)
                    {
                        //reading from text file if Exists
                        if (File.Exists(filePath))
                        {
                            using (StreamReader str = File.OpenText(filePath))
                            {
                                string s = "";
                                while ((s = str.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("File doesn't exist!!!");
                        }
                    }
                    else if(choice == 8)
                    {
                        Console.WriteLine("Enter the Address Book Name:");
                        string name = Console.ReadLine();
                        var allbooks = switchbook.getAllAddressBook();
                        if (allbooks.ContainsKey(name))
                        {
                            CSVHandler.WriteIntoCSVFile(allbooks, name);
                            Console.WriteLine("Data inserted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Book Name Not Found");
                        }
                    }
                    else if (choice == 9)
                    {
                            CSVHandler.ReadFromCSVFile();
                            Console.WriteLine("Data read successfully");
                    }
                    else if (choice == 10)
                    {
                        Console.WriteLine("Enter the Address Book Name:");
                        string nameJSON = Console.ReadLine();
                        var allbooks = switchbook.getAllAddressBook();
                        if (allbooks.ContainsKey(nameJSON))
                        {
                            JsonHandler.WriteIntoJSONFile(allbooks, nameJSON);
                            Console.WriteLine("Data inserted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Book Name Not Found");
                        }
                    }
                    else if(choice == 11)
                    {
                        JsonHandler.ReadFromJSONFile();
                        Console.WriteLine("Data read successfully");
                    }
                    else if (choice == 12)
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
