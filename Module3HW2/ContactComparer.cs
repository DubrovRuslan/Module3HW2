using System.Collections.Generic;
using Module3HW2.Models;

namespace Module3HW2
{
    internal class ContactComparer : IComparer<Contact>
    {
        public int Compare(Contact x, Contact y)
        {
            return string.Compare(x.FullName, y.FullName);
        }
    }
}
