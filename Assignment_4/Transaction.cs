using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Transaction
    {
        // Properties
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DateTime Time { get; }

        // Constructor
        public Transaction(string accountNumber, double amount, Person person, DateTime time)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = time;
        }

        // Displays transaction details
        public override string ToString()
        {
            string value = Amount < 0 ? $"Withdraw: {Amount*-1}" : $"Deposit: {Amount}";
            string msg = $"Account number: {AccountNumber}, {value}, Originator: {Originator}, Time: {Time}";
            return msg;
        }
    }
}
