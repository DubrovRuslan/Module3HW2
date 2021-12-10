using System;
using System.Globalization;
using Module3HW2.Models;
using Module3HW2.Services;

namespace Module3HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configSrvice = new ConfigService();
            var config = configSrvice.ReadConfig();
            ContactCollection phoneBook = null;
            if (config == null)
            {
                phoneBook = new ContactCollection();
            }
            else
            {
                var currentCultureName = CultureInfo.CurrentCulture.Name;
                foreach (var item in config.Localization)
                {
                    if (item.Key == currentCultureName)
                    {
                        phoneBook = new ContactCollection(item.Value);
                    }
                }
            }

            phoneBook.Add("Руслан", "Дубров");
            phoneBook.Add("Петр", "Петренко", "436456", PhoneType.Mobile);
            phoneBook.Add("Петр", "Баранов", "32343235", PhoneType.Work);
            phoneBook.Add("Александр", "Зайченко", "2353443", PhoneType.Main);
            phoneBook.Add("Александр", "Зайченко", "+380973452312", PhoneType.Work);

            foreach (var item in phoneBook)
            {
                Console.WriteLine(item);
            }
        }
    }
}
