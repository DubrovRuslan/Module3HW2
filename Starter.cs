using Module3HW2.Models;
using Module3HW2.Services.Abstractions;

namespace Module3HW2
{
    public class Starter
    {
        private readonly IContactService _contactProvider;
        public Starter(IContactService contactProvider)
        {
            _contactProvider = contactProvider;
        }

        public void Run()
        {
            _contactProvider.AddContact("Руслан", "Дубров");
            _contactProvider.AddContact("Петр", "Петренко", "436456", PhoneType.Mobile);
            _contactProvider.AddContact("Петр", "Баранов", "32343235", PhoneType.Work);
            _contactProvider.AddContact("Александр", "Зайченко", "2353443", PhoneType.Main);
            _contactProvider.AddContact("Александр", "Зайченко", "+380973452312", PhoneType.Work);
            _contactProvider.ShowAllContacts();
        }
    }
}
