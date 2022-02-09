using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    // creating a class Contacts
    public class Contacts
    {
        //decclaring variabls
        string firstName { get; set; }
        string lastName { get; set; }
        string city { get; set; }
        string state { get; set; }
        string address { get; set; }
        string email { get; set; }
        int zip { get; set; }
        long phoneNumber { get; set; }

        List<Contacts> allcontacts = new List<Contacts>();
        // creating a a constructor to initialize variables
        public Contacts( string firstName, string lastName, string city, string state, string address, string email, int zip, long phoneNumber)
        {
          
            this.firstName = firstName;
            this.lastName = lastName;   
            this.city = city;
            this.state = state;
            this.address = address;
            this.email = email;
            this.zip = zip; 
            this.phoneNumber = phoneNumber;

        }
        public Contacts()
        {

        }
        // overriding string method 
        public override string ToString()
        {
            return ("First Name: " + firstName + " Last Name: " + lastName + " City: " + city + " State: " + state + " Address" + address + " zip: " + zip + " Phone Number: " + phoneNumber);
        }

        //method to add Contacts
        public void AddContact()
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
            //check if contact exist in list
            if(CheckName(firstName, phoneNumber))
            {
                Console.WriteLine("contact already exists, please give another name or number");
                AddContact();
            }
            else
            {
                //add contact to list if does not exist already
                Contacts contact = new Contacts(firstName, lastName, city, state, address, email, zip, phoneNumber);
                Console.WriteLine("contact added: " + contact);
                allcontacts.Add(contact);
                Console.WriteLine("Contact has been added successfully");

            }
        }

        // method to display contact
        public void DisplayContacts()
        {
            if (allcontacts.Count == 0)
            {
                Console.WriteLine("there are no contacts to display");
            }
            else
            {
                //foreach loop to iterate all contacts from list & print
                Console.WriteLine("Displaying Contacts");
                foreach (Contacts contact in allcontacts)
                {
                    Console.WriteLine(contact);
                }
            }
        }
        //public void DisplayAddressBook()
        //{
        //    Console.WriteLine("Displaying Contacts");
        //    foreach(Contacts contact in allcontacts)
        //    {
        //        Console.WriteLine(contact.GetFirstName() +"\t"+ contact.GetLastName() +"\t"+ contact.GetCity() +"\t"+ contact.GetEmail() +"\t"+ contact.GetAddress() +"\t"+ contact.GetZip() +"\t"+ contact.GetPhoneNumber());
        //    }
        //}

        // method to edit contact
        public void EditContact()
        {
            Console.WriteLine("Enter first Name of contact u want to edit");
            string fName = Console.ReadLine();
            foreach (Contacts eachContact in allcontacts)
            {
                //compare if user entered firtname exist in the contact-list if it exits then let user edit contact
                if (fName == eachContact.firstName)
                {
                    Console.WriteLine("Enter First Name : ");
                    string firstName = Console.ReadLine();
                    eachContact.firstName = firstName;
                    Console.WriteLine("Enter Last Name : ");
                    string lastName = Console.ReadLine();
                    eachContact.lastName = lastName;
                    Console.WriteLine("Enter City: ");
                    string city = Console.ReadLine();
                    eachContact.city = city;
                    Console.WriteLine("Enter state Name : ");
                    string state = Console.ReadLine();
                    eachContact.state = state;
                    Console.WriteLine("Enter Address Name : ");
                    string address = Console.ReadLine();
                    eachContact.address =  address;
                    Console.WriteLine("Enter zip-code : ");
                    int zip = Convert.ToInt32(Console.ReadLine());
                    eachContact.zip = zip;  
                    Console.WriteLine("Enter Phone number : ");
                    long phoneNumber = Convert.ToInt64(Console.ReadLine());
                    eachContact.phoneNumber = phoneNumber;
                    Console.WriteLine("Contact has been Updated successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("invalid contact name, Please check & try again");
                    break;
                }
            }
        }

        //method to delete Contact from Contact-list
        public void DeleteContact()
        {
            Console.WriteLine("Enter first Name of contact u want to delete");
            string fName = Console.ReadLine();
            foreach (Contacts eachContact in allcontacts)
            {
                //compare if user entered firtname exist in the contact-list if it exits then delete the contact object from list
                if (fName == eachContact.firstName)
                {
                    Console.WriteLine("do u really want to delete this contact? Press y/n");
                    string key = Console.ReadLine();
                    if (key == "y")
                    {
                        allcontacts.Remove(eachContact);
                        Console.WriteLine("contact has been deleted");
                        break;
                    }
                }
            
                Console.WriteLine("contact does not exist, please enter valid contact First Name");
            }
        }
        //return true if contact already exists(check for duplicate)
        public bool CheckName(string firstName, long phone)
        {
            foreach (Contacts c in allcontacts)
            {
                if (c.firstName.Equals(firstName) || c.phoneNumber.Equals(phone))
                {
                    return true;
                }
            }
            return false;
        }


       
    }
}
