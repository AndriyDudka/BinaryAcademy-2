using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookProject.DTO;

namespace AddressBookProject
{
    public class AddressBook
    {
        private readonly List<User> _listOfUsers;
           
        public AddressBook()
        {
            _listOfUsers = new List<User>();
        }


        public event Action<User> UserAdded;

        public event Action<User> UserRemoved;


        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (user.PhoneNumber[0] != '+' && !('0' <= user.PhoneNumber[0] && user.PhoneNumber[0] <= '9'))
            {
                throw new Exception("Invalid PhoneNumber");
            }
            
            for (int i = 1; i < user.PhoneNumber.Length; i++)
            {
                if (!('0' <= user.PhoneNumber[i] && user.PhoneNumber[i] <= '9'))
                {
                    throw new Exception("Invalid PhoneNumber");
                }
            }

            user.TimeAdded = DateTime.Now.ToString();
            _listOfUsers.Add(user);

            if (UserAdded != null)
            {
                UserAdded(user);
            }
        }

        public void RemoveUser(string id)
        {
            var user = _listOfUsers.FirstOrDefault(u => string.Equals(u.Id, id));
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            try
            {
                _listOfUsers.Remove(user);
            }
            catch (Exception)
            {
                throw new Exception("User not found");
            }
                       
            if (UserRemoved != null)
            {
                UserRemoved(user);
            }
        }
    }
}
