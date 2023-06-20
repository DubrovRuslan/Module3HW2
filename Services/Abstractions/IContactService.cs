using Module3HW2.Models;

namespace Module3HW2.Services.Abstractions
{
    public interface IContactService
    {
        public void AddContact(string firstName, string lastName);
        public bool AddContact(string firstName, string lastName, string phoneNumber, PhoneType phoneType);
        public void ShowAllContacts();
    }
}
