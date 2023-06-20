using System.Globalization;
using Module3HW2.Models;
using Module3HW2.Services.Abstractions;

namespace Module3HW2.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactCollection _phoneBook;
        private readonly IConfigService _configService;
        private readonly Config _config;
        public ContactService(IConfigService configService)
        {
            _configService = configService;
            _config = _configService.ReadConfig();
            if (_config == null)
            {
                _phoneBook = new ContactCollection();
            }
            else
            {
                var currentCultureName = CultureInfo.CurrentCulture.Name;
                foreach (var item in _config.Localization)
                {
                    if (item.Key == currentCultureName)
                    {
                        _phoneBook = new ContactCollection(item.Value);
                    }
                }
            }
        }

        public void AddContact(string firstName, string lastName)
        {
            _phoneBook.Add(firstName, lastName);
        }

        public bool AddContact(string firstName, string lastName, string phoneNumber, PhoneType phoneType)
        {
            return _phoneBook.Add(firstName, lastName, phoneNumber, phoneType);
        }

        public void ShowAllContacts()
        {
            foreach (var item in _phoneBook)
            {
                Console.WriteLine(item);
            }
        }
    }
}
