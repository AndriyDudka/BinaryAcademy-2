using System;
using System.IO;
using System.Text.RegularExpressions;
using AddressBookProject;
using AddressBookProject.DTO;
using LoggerProject;

namespace MainProject
{
    public class Program
    {
        public static void Main()
        {
            var dir = Directory.GetCurrentDirectory();
            var match = Regex.Match(dir, "(\\\\bin\\\\(Debug|Release))");
            if (match.Success)
            {
                dir = dir.Replace(match.Value, String.Empty);
            }
            var loggerFactory = new LoggerFactory(dir + "\\Log\\Log.txt");

            ILogger logger;
            AddressBook addressBook;
            Program program;


            var user = new User
            {
                FirstName = "Andriy",
                LastName = "Dudka",
                Address = "Bestuzina 12/7",
                Birthdate = new DateTime(1994, 5, 1),
                PhoneNumber = "+380668839420",
                Email = "andriy.dudka@gmail.com",
                City = "Uzhgorod",
                Gender = Gender.Male

            };
          
            #region Console Optput test

            logger = loggerFactory.CreateLogger(0);
            addressBook = new AddressBook();
            program = new Program(logger);

            addressBook.UserAdded += program.OnUserAddedHandler;
            addressBook.UserRemoved += program.OnUserRemovedHandler;

            try
            {
                addressBook.AddUser(user);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            try
            {
                addressBook.RemoveUser(user.Id);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            #endregion

            #region File Optput test

            logger = loggerFactory.CreateLogger(1);
            addressBook = new AddressBook();
            program = new Program(logger);

            addressBook.UserAdded += program.OnUserAddedHandler;
            addressBook.UserRemoved += program.OnUserRemovedHandler;

            try
            {
                addressBook.AddUser(user);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            try
            {
                addressBook.RemoveUser(user.Id);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
                      
            #endregion

            Console.ReadKey();
        }


        private readonly ILogger _logger;

        Program(ILogger logger)
        {
            _logger = logger;
        }

        void OnUserAddedHandler(User user)
        {
            _logger.Info(
                    string.Format("Successfully added user: {0}", user.Id));
        }

        void OnUserRemovedHandler(User user)
        {
            if (user == null)
            {
                _logger.Warning("User not found");
                return;
            }

            _logger.Info(
                string.Format("Successfully removed user: {0}", user.Id));
        }
    }
}