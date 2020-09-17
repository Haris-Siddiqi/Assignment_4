using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class AccountException : Exception
    {
        public AccountException(ExceptionEnum reason):base(reason.ToString())
        {
            Console.WriteLine(reason.ToString());
        }
    }
}
