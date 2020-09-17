using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Person
    {
        // Field
        private string password;

        // Properties
        public bool IsAuthenticated { get; private set; }
        public string SIN { get; }
        public string Name { get; }

        // Constructor
        public Person(string name, string sin)
        {
            Name = name;
            SIN = sin;
            password = sin.Substring(0, 3);
        }

        // Logs in user if password matches, else throw an exception
        public void Login(string pword)
        {
            // Login
            if (pword == password)
            {
                IsAuthenticated = true;
            }
            // Exception
            else
            {
                throw new AccountException(ExceptionEnum.PASSWORD_INCORRECT);
            }
        }

        // Logs out
        public void Logout()
        {
            IsAuthenticated = false;
        }

        // Prints the name
        public override string ToString()
        {
            return Name;
        }
    }
}
