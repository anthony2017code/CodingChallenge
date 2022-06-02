using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess
{
    public static class ContactsDataAccess
    {
        //TODO: Place data access code here
        private static  Dictionary<int, Entry> fakeDB = new Dictionary<int, Entry>();
        
        public static bool save(Entry entry)
        {
            int id = fakeDB.Count;//TODO: make this a real id system
            if (fakeDB.ContainsKey(id))
            {                
                return false;
            }
            else
            {
                fakeDB.Add(id, entry);
                return true;
            }
        }

        public static IEnumerable<Entry> GetContacts()
        {
            return fakeDB.Values;
        }
    }
}
