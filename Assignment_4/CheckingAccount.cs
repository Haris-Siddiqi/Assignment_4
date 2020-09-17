using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class CheckingAccount : Account, ITransaction
    {
        // Fields
        static private double COST_PER_TRANSACTION = 0.05;
        static private double INTEREST_RATE = 0.005;
        private bool hasOverdraft;
        
        // Constructor
        public CheckingAccount(double balance = 0, bool hasOverdraft = false)
            : base("CK-", balance)
        {
            this.hasOverdraft = hasOverdraft;
        }

        // Calls base class method
        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        // Calls exceptions
        public void Withdraw(double amount, Person person)
        {
            if(!this.IsUser(person.Name))
            throw new AccountException(ExceptionEnum.USER_DOES_NOT_EXIST);
            
            if(person.IsAuthenticated == false)
            throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);

            if(amount > this.Balance && this.hasOverdraft == false)
            throw new AccountException(ExceptionEnum.NO_OVERDRAFT);
                base.Deposit(-(amount), person);
        }

        // Overrides base class
        public override void PrepareMonthlyReport()
        {
            double serviceCharge = COST_PER_TRANSACTION * transactions.Count;
            double interest = (LowestBalance * INTEREST_RATE) / 12.00;
            Balance = (Balance + interest) - serviceCharge;
            transactions.Clear();
        }
    }
}
