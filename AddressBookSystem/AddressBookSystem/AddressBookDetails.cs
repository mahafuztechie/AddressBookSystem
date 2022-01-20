﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBookDetails
    {

        ArrayList allcontacts = new ArrayList();
       
        //method to add Contacts
        public void AddContacts()
        {
            Console.WriteLine("Enter First Name : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name : ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State : ");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Address : ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Email : ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Zipcode : ");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone Number : ");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Contacts contact = new Contacts(firstName, lastName, city, state, address, email, zip, phoneNumber);
            Console.WriteLine("contact added: " +contact);

            //adding contact into list
            allcontacts.Add(contact);  
        }

        // method to display contact
        public void display()
        {
            //foreach loop to iterate all contacts from list & print
            foreach(Contacts contact in allcontacts)
            {
                Console.WriteLine(contact);
            }
        }

        // method to edit contact
        public void EditContact()
        {
            Console.WriteLine("Enter first Name of contact u want to edit");
            string fName = Console.ReadLine();
            foreach (Contacts eachContact in allcontacts)
            {
                //compare if user entered firtname exist in the contact-list if it exits then let user edit contact
                if (fName == eachContact.GetFirstName())
                {
                    Console.WriteLine("Enter First Name : ");
                    string firstName = Console.ReadLine();
                    eachContact.SetFirstName(firstName);
                    Console.WriteLine("Enter Last Name : ");
                    string lastName = Console.ReadLine();
                    eachContact.SetLastName(lastName);
                    Console.WriteLine("Enter City: ");
                    string city = Console.ReadLine();
                    eachContact.SetCity(city);
                    Console.WriteLine("Enter state Name : ");
                    string state = Console.ReadLine();
                    eachContact.SetState(state);
                    Console.WriteLine("Enter Address Name : ");
                    string address = Console.ReadLine();
                    eachContact.SetAddress(address);
                    Console.WriteLine("Enter zip-code : ");
                    int zip = Convert.ToInt32(Console.ReadLine());
                    eachContact.SetZip(zip); 
                    Console.WriteLine("Enter Phone number : ");
                    long phoneNumber = Convert.ToInt64(Console.ReadLine());
                    eachContact.SetPhoneNumber(phoneNumber);
                    break;

                }
                else
                {
                    Console.WriteLine("invalid contact name, Please check & try again");
                    break;
                }
            }
        }



    }

  
}