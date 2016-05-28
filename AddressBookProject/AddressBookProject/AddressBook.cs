using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookProject.DTO;
using LoggerProject;

namespace AddressBookProject
{
    public class AddressBook
    {
        private readonly ILogger _logger;
        private readonly List<User> _listOfUsers;
        
        
        public AddressBook(ILogger logger)
        {
            _logger = logger;
            _listOfUsers = new List<User>();
        }


        public event Action<User> UserAdded;

        public event Action<User> UserRemoved;


        public void AddUser(User user)
        {
            if (user == null)
            {
                _logger.Error("[User] is null");
                throw new ArgumentNullException("user");
            }

            if (user.PhoneNumber[0] != '+' && !('0' <= user.PhoneNumber[0] && user.PhoneNumber[0] <= '9'))
            {
                _logger.Warning("Invalid PhoneNumber");
            }
            
            for (int i = 1; i < user.PhoneNumber.Length; i++)
            {
                if (!('0' <= user.PhoneNumber[i] && user.PhoneNumber[i] <= '9'))
                {
                    _logger.Warning("Invalid PhoneNumber");
                }
            }
            
            _listOfUsers.Add(user);
            if (UserAdded != null)
            {
                UserAdded(user);
            }
        }

        public void RemoveUser(string id)
        {
            var user = _listOfUsers.FirstOrDefault(u => string.Equals(u.Id, id));
            if (user != null)
            {
                _listOfUsers.Remove(user);
            }

            if (UserRemoved != null)
            {
                UserRemoved(user);
            }
        }
    }
}
