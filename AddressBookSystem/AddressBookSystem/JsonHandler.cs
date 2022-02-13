using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class JsonHandler
    {
        static string filePathJSON = @"C:\Users\dell\source\repos\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBookSystem\ContactList.json";

        // method to write into json
        public static void WriteIntoJSONFile(Dictionary<string, Contacts> allbooks, string bookName)
        {
            Console.WriteLine("Writing Data into JSON File");
            //iterate over all address books
            foreach (KeyValuePair<string,Contacts> kv in allbooks)
            {
                string book = kv.Key;
                var contacts = kv.Value.getContacts();

                //check if book matches
                if (book.Equals(bookName))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                    using (StreamWriter stw = new StreamWriter(filePathJSON))
                    {
                        //write into json file
                        using (JsonTextWriter writer = new JsonTextWriter(stw))
                        {
                            serializer.Serialize(writer, contacts);
                        }
                    }
                }
            }
        }

        //read from json file
        public static void ReadFromJSONFile()
        {
            Console.WriteLine("Reading Data from JSON File");

            //JsonConvert is from JSON.NET Library, deserialize objects & mapping to list of Contacts objects
            List<Contacts> records = JsonConvert.DeserializeObject<List<Contacts>>(File.ReadAllText(filePathJSON));

            foreach (Contacts record in records)
            {
                Console.WriteLine(record);
            }
        }

    }
}
