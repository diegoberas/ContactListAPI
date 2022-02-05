using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactList.Model;

namespace ContactList.Repository
{
    public class ContactRepository
    {
        public static List<Contact> Contacts = new List<Contact>()
        {
            new Contact() { Id = 1, Name = "Diego", LastName = "Beras", Email = "diego@gmail.com", PhoneNumberList = (new List<string>(){"8098008000", "8291331311", "8098098888"})},
            new Contact() { Id = 2, Name = "Juan", LastName = "Perez", Email = "juan@gmail.com", PhoneNumberList = (new List<string>(){"8098090000"})},
            new Contact() { Id = 3, Name = "Tito", LastName = "Smith", Email = "tito@gmail.com" }
        };

        // Get all Contacts
        public IEnumerable<Contact> GetContacts()
        {
            return Contacts;
        }

        // Get a contact by Id
        public Contact GetContactById(int id)
        {
            var findContact = Contacts.Find(x => x.Id == id);
            return findContact;
        }

        // Add contact
        public static void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        // Edit contact
        public static void UpdateContact(int id, Contact newContact)
        {
            var oldContact = Contacts.Find(x => x.Id == id);
            oldContact.Name = newContact.Name;
            oldContact.LastName = newContact.LastName;
            oldContact.Email = newContact.Email;
            oldContact.PhoneNumberList = newContact.PhoneNumberList;
        }

        // Delete contact
        public static void DeleteContact(int id)
        {
            var findContact = Contacts.Find(x => x.Id == id);
            Contacts.Remove(findContact);

        }


    }
}
