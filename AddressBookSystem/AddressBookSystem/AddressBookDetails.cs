using System;
using System.Collections;
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
    }
}
