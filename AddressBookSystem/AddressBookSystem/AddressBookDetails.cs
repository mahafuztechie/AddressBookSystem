using System;
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
    }

  
}
