using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    abstract class Account
    {
        // Fields
        public readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        private static int LAST_NUMBER = 100_000;

        // Properties
        public double Balance { get; set; }
        public double LowestBalance { get; private set; }
        public string Number { get; }

        // Constructor
        public Account(string type, double balance)
        {
            //Concatenate the type of account (type) and the starting balance (LastNumber)
            Number = type + LAST_NUMBER;

            //Increments LastNumber
            LAST_NUMBER++;

            //Assigns the second argument to Balance 
            Balance = balance;

            //Assigns the second argument to LowestBalance
            LowestBalance = balance;
        }

        public void Deposit(double amount, Person person)
        {
            //Increase (or decrease) Balance by the value of 'amount'.
            this.Balance = this.Balance + amount;

            //Update LowestBalance based on the current value of Balance
            if (this.Balance < LowestBalance)
            {
                LowestBalance = this.Balance;
            }

            //Create a Transaction object based on the current time, the Account'Number', the amount, and a person object.
            Transaction newTransaction = new Transaction(this.Number, amount, person, DateTime.Now);

            //Adds the above object to the list of transactions
            transactions.Add(newTransaction);
        }

        public void AddUser(Person person)
        {
            //Takes a person object and adds the argument to holders (the list of persons)
            users.Add(person);
        }

        // Returns true if match found
        public bool IsUser(string name)
        {
            for (int user = 0; user < users.Count; user++)
            {
                if (users[user].Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public abstract void PrepareMonthlyReport();

        // This method overrides the same method of the Object class
        public override string ToString()
        {
            string userString = "";
            string transactionString = "";

            foreach(var value in users)
            {
                userString += value.ToString() + ", ";
            }

            foreach (var value in transactions)
            {
                transactionString += "\n\t" + value.ToString();
            }

            userString = userString.TrimEnd(' ');
            userString = userString.TrimEnd(',');
            string result = "Account number: " + Number + "\nBalance: " + Balance.ToString() + "\nAccount holder: " + userString + "\nTransactions: " + transactionString + "\n";
            return result;
        }
    }
}
