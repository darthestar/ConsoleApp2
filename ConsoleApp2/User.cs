using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//need Bank Account
//--owner name
//--savings account number
//--checking account number
//--savings balance
//--checking balance

namespace ATMApp
{
    class User
    {
        public string SavingsAcct { get; }
        public string CheckingAcct { get; }
        public string AccountOwner { get; }
        public int SavingsBalance { get; set;}
        public int CheckingBalance { get;set;}


        public User(string savingsAcctNumber, string checkingAcctNumber, string accountOwnerName, int savingsBalance, int checkingBalance)
        {
            SavingsAcct = savingsAcctNumber;
            CheckingAcct = checkingAcctNumber;
            AccountOwner = accountOwnerName;
            SavingsBalance = savingsBalance;
            CheckingBalance = checkingBalance;
        }

        public int GetSavingsBalance() => SavingsBalance;
        public int GetCheckingBalance() => CheckingBalance;
        public string GetAccountOwner() => AccountOwner;

    }
}
