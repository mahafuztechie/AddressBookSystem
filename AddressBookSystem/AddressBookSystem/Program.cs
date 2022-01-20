// See https://aka.ms/new-console-template for more information
using AddressBookSystem;
using System.Collections;
Console.WriteLine("Welcome to Adddress book system");
int num;
string key = "z";


AddressBookDetails addressbook  = new AddressBookDetails();

/// <summary>
/// implementing a whileLoop with switch case to ask user if he wants to add or display contact
/// </summary>
while (key != "n")
{
    Console.WriteLine("Select an Option");
    Console.WriteLine("1 - Addcontact, 2 - Display contact, 3 - deleteContact");
    num = Convert.ToInt32(Console.ReadLine());
    switch (num)
    {
        case 1:
            addressbook.AddContacts();
            break;
        case 2:
            addressbook.display();
            break;
    }
    Console.WriteLine("Do u want to continue? Press y/n");
   
    key = Console.ReadLine();
}
Console.ReadLine();
