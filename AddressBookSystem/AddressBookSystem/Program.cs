﻿// See https://aka.ms/new-console-template for more information
using AddressBookSystem;
using System.Collections;
Console.WriteLine("Welcome to Adddress book system");
int num;
string key = "z";


AddressBookDetails addressbook  = new AddressBookDetails();

/// <summary>
/// implementing a whileLoop with switch case to ask user if he wants to add or display  or delete or edit contact
/// </summary>
while (key != "n")
{
    Console.WriteLine("Select an Option");
    Console.WriteLine("1 - Addcontact, 2 - Display contact, 3 - Edit Contact, 4 - Delete Contact");
    num = Convert.ToInt32(Console.ReadLine());

    switch (num)
    {
        case 1:
            addressbook.AddContacts();
            addressbook.Display();
            break;
        case 2:
            addressbook.Display();
            break;
        case 3:
            addressbook.EditContact();
            addressbook.Display();
            break;
        case 4:
            addressbook.DeleteContact();
            addressbook.Display();
            break;
    }
    Console.WriteLine("Do u want to continue? Press y/n");
   
    key = Console.ReadLine();
}
Console.ReadLine();
