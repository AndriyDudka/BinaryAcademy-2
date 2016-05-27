using AddressBookProject;
using LoggerProject;

namespace MainProject
{
    internal class Program
    {
        private static void Main()
        {
            AddressBook addressBook = new AddressBook();
            ILogger logger = new ConsoleLogger(); 

            addressBook.UserAdded += logger.Info;
            addressBook.UserRemoved += logger.Info;

            addressBook.AddUser(new User("Dudka", "Andriy", "01.05.94", "Uzhgorod", "Bestuzina 12/7", "+380668839420",
                "Male", "andriy.dudka@gmail.com"));

            addressBook.RemoveUser(0);
            addressBook.RemoveUser(0);
        }
    }
}
