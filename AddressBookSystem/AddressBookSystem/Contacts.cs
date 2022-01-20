using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    // creating a class Contacts
    internal class Contacts
    {
        //decclaring variabls
        string firstName, lastName, city, state, address, email;
        int zip;
        long phoneNumber;

        // creating a a constructor to initialize variables
        public Contacts(string firstName, string lastName, string city, string state, string address, string email, int zip, long phoneNumber)
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

        //implementing getters & setters
        public String GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public String GetLastName()
        {
            return lastName;
        }
        public void GetFirstName(string lastName)
        {
            this.lastName = lastName;
        }
        public String GetCity()
        {
            return city;
        }
        public void SetCity(string city)
        {
            this.city=city;
        }
        public String GetState()
        {
            return state;
        }
        public void SetState(string state)
        {
            this.state=state;
        }
        public String GetAddress()
        {
            return address;
        }
        public void SetAddress(string address)
        {
            this.address = address;
        }
        public String GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email=email;
        }
        public int GetZip()
        {
            return zip;
        }
        public void SetZip(int zip)
        {
            this.zip = zip;
        }
        public long GetPhoneNumber()
        {
            return phoneNumber;
        }
        public void SetPhoneNumber(long phoneNumber)
        {
             this.phoneNumber = phoneNumber;
        }

        // overrding string method 
        public override string ToString()
        {
            return ("First Name: " + firstName + " Last Name: " + lastName + " City: " + city + " State: " + state + " Address" + address + " zip: " + zip + " Phone Number: " + phoneNumber);
        }
    }
}
