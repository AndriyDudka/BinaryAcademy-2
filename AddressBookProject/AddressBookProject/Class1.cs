using System;
using System.Collections.Generic;

namespace AddressBookProject
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Birthdate { get; set; }
        public string TimeAdded { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public User(string lastName, string firstName, string birthdate, string city, string address, string phoneNumber,
            string gender, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            Birthdate = birthdate;
            TimeAdded = DateTime.Now.ToString();
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Email = email;
        }
    }

    public class AddressBook
    {
        public event Action<string> UserAdded;
        public event Action<string> UserRemoved;

        private readonly List<User> _listOfUsers;

        public AddressBook()
        {
            _listOfUsers = new List<User>();
        }

        public void AddUser(User user)
        {
            user.Id = _listOfUsers.Count;
            _listOfUsers.Add(user);
            if (UserAdded != null) UserAdded("New user was added successfully");
        }

        public void RemoveUser(int id)
        {
            if (UserRemoved == null) return;

            for (var i = 0; i < _listOfUsers.Count; i++)
            {
                if (_listOfUsers[i].Id == id)
                {
                    _listOfUsers.RemoveAt(i);
                    UserRemoved("User, which Id = " + id + " was removed sucessfully");
                    return;
                }
            }
            UserRemoved("Cant find User which Id = " + id);
        }
    }
}
