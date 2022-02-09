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
        public Dictionary<string, List<Contacts>> ContactByCity;
        public Dictionary<string, List<Contacts>> ContactByState;
        List<string> cities;
        List<string> states;

        List<Contacts> con = new List<Contacts>();

        public AddressBookDetails()
        {
            switchAddressBook = new Dictionary<string, Contacts>();
            ContactByCity = new Dictionary<string, List<Contacts>>();
            ContactByState = new Dictionary<string, List<Contacts>>();
            cities = new List<string>();
            states = new List<string>();

        }
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
        public void GetByCityOrState(string cityOrstate)
        {
           

            //iterate over each addressbook to & search contact by city or state 
            foreach (var item in switchAddressBook)
            {
                //assign all address book matching lists to new list
                foreach (Contacts contact in item.Value.SearchContactByCityOrState(cityOrstate))
                {
                    if (cities.Contains(contact.city) == false)
                    {
                        cities.Add(contact.city);
                    }
                    if (states.Contains(contact.state) == false)
                    {
                        states.Add(contact.state);
                    }
                }

            }
        }

        //set contacts in city dictionary with specific cities
        public void SetContactByCityDictionary(string city)
        {
            GetByCityOrState(city);

            foreach (string c in cities)
            {
                List<Contacts> contact = new List<Contacts>();
                foreach (var addressBook in switchAddressBook)
                {
                    contact.AddRange(addressBook.Value.SearchContactByCityOrState(city));
                }
                if (ContactByCity.ContainsKey(c))
                {
                    ContactByCity[c] = contact;
                }
                else
                {
                    ContactByCity.Add(c, contact);
                }
            }
            ViewPersonsByCity(city);
        }
        //set contacts in state dictionary with specific state
        public void SetContactByStateDictionary(string state)
        {
            GetByCityOrState(state);

            foreach (string s in states)
            {
                List<Contacts> contact = new List<Contacts>();
                foreach (var addressBook in switchAddressBook)
                {
                    contact.AddRange(addressBook.Value.SearchContactByCityOrState(state));
                }
                if (ContactByState.ContainsKey(s))
                {
                    ContactByState[s] = contact;
                }
                else
                {
                    ContactByState.Add(s, contact);
                }
            }
           ViewPersonsByState(state);
        }

        //view all contacts from city dictionary matching the city key
        public void ViewPersonsByCity(string city)
        {
            Console.WriteLine("Contacts By City");
            if (ContactByCity.ContainsKey(city))
            {
                foreach (Contacts contact in ContactByCity[city])
                {
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\nAddress :" + contact.address + "   ZipCode :" + contact.zip + "\nPhone No :" + contact.phoneNumber + "   Email :" + contact.email);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
        //view all contacts from state dictionary matching the state key
        public void ViewPersonsByState(string state)
        {
            Console.WriteLine("Contacts By State");
            if (ContactByState.ContainsKey(state))
            {
                foreach (Contacts contact in ContactByState[state])
                {
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\nAddress :" + contact.address + "   ZipCode :" + contact.zip + "\nPhone No :" + contact.phoneNumber + "   Email :" + contact.email);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }

    }
}
