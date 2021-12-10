using System.Collections.Generic;

namespace Module3HW2.Models
{
    public class Contact
    {
        public Contact()
        {
            PhoneNumbers = new List<PhoneInfo>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public List<PhoneInfo> PhoneNumbers { get; }
    }
}
