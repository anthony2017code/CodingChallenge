using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService : IContactsService
    {
        //TODO: Place business logic for contact here
        public bool SaveContact(EntryViewModel entryViewModel)
        {
            Entry entry = new Entry();
            //TODO: validations
            entry.LastName = entryViewModel.LastName;
            entry.FirstName = entryViewModel.FirstName;
            entry.Email = entryViewModel.Email;
            ContactsDataAccess.save(entry);
            //TODO: check if save failed
            return true;
        }

        public List<EntryViewModel> GetContacts(string lastName, bool sortAscending)
        {
            List<EntryViewModel> contacts = new List<EntryViewModel>();
            IEnumerable<Entry> contactsData = ContactsDataAccess.GetContacts();
            if(string.IsNullOrEmpty(lastName))
            {
                foreach (Entry entry in contactsData)
                {
                    EntryViewModel model = new EntryViewModel();
                    model.LastName = entry.LastName;
                    model.FirstName = entry.FirstName;
                    model.Email = entry.Email;
                    contacts.Add(model);
                }
            }
            else
            {
                foreach (Entry entry in contactsData)
                {
                    if(entry.LastName == lastName)
                    {
                        EntryViewModel model = new EntryViewModel();
                        model.LastName = entry.LastName;
                        model.FirstName = entry.FirstName;
                        model.Email = entry.Email;
                        contacts.Add(model);                        
                    }
                }
            }
            if(sortAscending)
            {
                return contacts.OrderBy(item => item.LastName).ToList();
            }
            else
            {
                return contacts.OrderByDescending(item => item.LastName).ToList();
            }
        }
    }
}

