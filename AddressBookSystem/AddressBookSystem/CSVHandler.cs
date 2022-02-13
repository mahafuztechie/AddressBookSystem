using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace AddressBookSystem
{
    public class CSVHandler
    {
        //csv file path
        static string filePathCSV = @"C:\Users\dell\source\repos\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBookSystem\ContactList.csv";
        // write into csv file
        public static void WriteIntoCSVFile(Dictionary<string, Contacts> allbooks, string bookName)
        {
            foreach (KeyValuePair<string, Contacts> kv in allbooks)
            {
                string bookpath = kv.Key;
                Contacts contacts = kv.Value;

                //check if oath matches 
                if (bookpath.Equals(bookName))
                {
                    using (StreamWriter stw = new StreamWriter(filePathCSV))
                    {
                        using (CsvWriter writer = new CsvWriter(stw, CultureInfo.InvariantCulture))
                        {
                            //write into csv
                            writer.WriteRecords(contacts.getContacts());
                        }
                    }
                }
            }
        }

        public static void ReadFromCSVFile()
        {
            Console.WriteLine("Reading from CSV File");

            using (StreamReader str = new StreamReader(filePathCSV))
            {
                using (CsvReader reader = new CsvReader(str, CultureInfo.InvariantCulture))
                {
                    var records = reader.GetRecords<Contacts>().ToList();

                    foreach (Contacts c in records)
                    {
                        Console.WriteLine(c);
                    }
                }
            }
        }
    }
}
