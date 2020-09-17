using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class SavingAccount : Account, ITransaction
    {
        // Fields
        static private double COST_PER_TRANSACTION = 0.05;
        static private double INTEREST_RATE = 0.015;
    
        // Constructor
        public SavingAccount(double balance = 0)
            : base ("SV-", balance)
        {
        }

        // Methods
        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        // Calls exceptions
        public void Withdraw(double amount, Person person)
        {
            if(!this.IsUser(person.Name))
            throw new AccountException(ExceptionEnum.USER_DOES_NOT_EXIST);
            
            if(!person.IsAuthenticated)
            throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);

            if(amount > this.Balance)
            throw new AccountException(ExceptionEnum.NO_OVERDRAFT);
                base.Deposit(-(amount), person);
        }

        public override void PrepareMonthlyReport()
        {
            double serviceCharge = COST_PER_TRANSACTION * transactions.Count;
            double interest = (LowestBalance * INTEREST_RATE) / 12.00;
            Balance = (Balance + interest) - serviceCharge;
            transactions.Clear();
        }
    }
}