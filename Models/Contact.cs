namespace Module3HW2.Models
{
    public class Contact : IComparable<Contact>
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

        public int CompareTo(Contact other)
        {
            if (other is null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }

            return string.Compare(FullName, other.FullName);
        }
    }
}
