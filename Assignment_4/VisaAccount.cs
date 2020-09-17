
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment_4
{
    class VisaAccount : Account, ITransaction
    {
        //Given fields
        private double creditLimit;
        private static double INTEREST_RATE = 0.1995;

        //Given constructor - It invokes the base constructor “VS-” and its argument
        public VisaAccount(double balance = 0, double cl = 1200)
        : base("VS-", balance)
        {
            creditLimit = cl;
        }

        //Given methods
        public void DoPayment(double amount, Person person)
        {
            //The method calls the Deposit() method of the base class with amount to be deposited (amount) and a person object
            base.Deposit(amount, person);
        }

        //The method takes the amount to be withdrawn and a person object
        public void DoPurchase(double amount, Person person)
        {
            if (this.IsUser(person.Name) == false)
            {
                throw new AccountException(ExceptionEnum.USER_DOES_NOT_EXIST);
            }
            
            if (person.IsAuthenticated == false)
            {
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
            }

            if ((this.Balance * -1) + amount > this.creditLimit)
            {
                throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }

            base.Deposit(-(amount), person);
        }

        // Need to implement all methods from ITransaction.cs
        public void Withdraw(double amount, Person person)
        {
        }

        public override void PrepareMonthlyReport()
        {
            double interest = (LowestBalance * INTEREST_RATE) / 12.00;
            Balance = Balance - interest;
            transactions.Clear();
        }
    }
}