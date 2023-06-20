using System.Collections;
using Module3HW2.Models;

namespace Module3HW2
{
    public class ContactCollection : IEnumerable
    {
        private readonly string _cultureString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789#";
        public ContactCollection()
        {
            Contacts = new SortedDictionary<string, List<Contact>>();
        }

        public ContactCollection(string cultureString)
        {
            _cultureString = cultureString;
            Contacts = new SortedDictionary<string, List<Contact>>();
        }

        public SortedDictionary<string, List<Contact>> Contacts { get; }
        public void Add(string firstName, string lastName)
        {
            var key = firstName[0].ToString();
            if (!_cultureString.Contains(key))
            {
                key = _cultureString[_cultureString.Length - 1].ToString();
            }

            if (!Contacts.ContainsKey(key))
            {
                Contacts.TryAdd(key, new List<Contact>());
            }

            Contacts[key].Add(new Contact { FirstName = firstName, LastName = lastName });
            Contacts[key].Sort();
        }

        public bool Add(string firstName, string lastName, string phoneNumber, PhoneType phoneType)
        {
            var key = firstName[0].ToString();
            if (!_cultureString.Contains(key))
            {
                key = _cultureString[_cultureString.Length - 1].ToString();
            }

            if (!Contacts.ContainsKey(key))
            {
                if (!Contacts.TryAdd(key, new List<Contact>()))
                {
                    return false;
                }
            }

            var contactId = GetContactIdInList(firstName, lastName);
            if (contactId != null)
            {
                Contacts[key][(int)contactId].PhoneNumbers.Add(new PhoneInfo { Number = phoneNumber, Type = phoneType });
                return true;
            }

            var newContact = new Contact { FirstName = firstName, LastName = lastName };
            newContact.PhoneNumbers.Add(new PhoneInfo { Number = phoneNumber, Type = phoneType });
            Contacts[key].Add(newContact);
            Contacts[key].Sort();
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var contactsByChar in Contacts)
            {
                yield return contactsByChar.Key;
                foreach (var contact in contactsByChar.Value)
                {
                    yield return contact.FullName;
                    foreach (var phone in contact.PhoneNumbers)
                    {
                        yield return $"{phone.Number} ({phone.Type})";
                    }
                }
            }
        }

        private int? GetContactIdInList(string firstName, string lastName)
        {
            var key = firstName[0].ToString();
            if (Contacts.ContainsKey(key))
            {
                for (var i = 0; i < Contacts[key].Count; i++)
                {
                    var resultFirstName = string.Compare(Contacts[key][i].FirstName, firstName);
                    var resultLastName = string.Compare(Contacts[key][i].LastName, lastName);
                    if (resultFirstName == 0 && resultLastName == 0)
                    {
                        return i;
                    }
                }
            }

            return null;
        }
    }
}
