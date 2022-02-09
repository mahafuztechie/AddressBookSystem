using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBookDetails
    {
        //dictionary to create addressbook 
         Dictionary<string, Contacts> switchAddressBook = new Dictionary<string, Contacts>();
        //method to add addressbook to dictionary
        public  void AddNewAddressBook(string addressName, Contacts addressBook)
        {
            switchAddressBook.Add(addressName, addressBook);
        }

        //method to fetch single address book if it matches user input
        public Contacts GetAddressBook(string name)
        {
            foreach (var item in switchAddressBook)
            {
                if (item.Key == name)

                    return item.Value;
                
            }
            return null;
        }
        //search contact over multiple addressbook
        public void searchOverMultipleAddressBook()
        {
            Console.WriteLine("enter city or state to search contact");
            string cityOrstate = Console.ReadLine();
            List<Contacts> con = new List<Contacts>();
            //iterate over each addressbook to & search contact by city or state 
            foreach (var item in switchAddressBook)
            {
              //assign all address book matching lists to new list
             con =  item.Value.SearchContactByCityOrState(cityOrstate);
               
            }
            //iterate over new list & display contacts
            if(con.Count > 0)
            {
                foreach (var item in con)
                {
                    item.DisplayContacts();
                }
            }
          
           
        }

    }
}
