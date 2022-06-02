using ClarkCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarkCodingChallenge.BusinessLogic
{
    public interface IContactsService
    {
        public bool SaveContact(EntryViewModel entryViewModel);
        public List<EntryViewModel> GetContacts(string lastName, bool sortAscending);
    }
}
