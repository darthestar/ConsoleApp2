using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace ATMApp
{
    class Account
    {
        // want a private value, that holds the acount amount
        // You want to access that value from outside the Account, read only
        public User CurrentUser { get; set; }
        
        
        public Account(User user)
        {
            CurrentUser = user;
        }

        //  WITHDRAW
        //--prompt to withdraw from savings, OR from check and to enter an amount to withdraw, then deduct that amount. 
        //--This should do some basic error handler---make sure that the value inputted is a number & balance is positive

        public void Withdraw(string reply, int amount, User CurrentUser)
        {   
            

            if (reply == "savings")
            {
               CurrentUser.SavingsBalance  = CurrentUser.SavingsBalance - amount;
            }
            else
            {
               CurrentUser.CheckingBalance  = CurrentUser.CheckingBalance - amount;
             }

        }

        //  DEPOSIT
        //--this should prompt the user to choose check/save/enter an amount to deposit, then add that amount. 
        //--This should do some basic error handler -make sure that the value inputted is a number


        public void Deposit(string reply, int amount, User CurrentUser)
        {
            if (reply == "savings")
            {
                CurrentUser.SavingsBalance = CurrentUser.GetSavingsBalance() + amount;
            }
            else
            {
                CurrentUser.CheckingBalance = CurrentUser.GetCheckingBalance() + amount;
            }
        }

        public void Transfer(string reply, int amount, User CurrentUser)
        {
            if (reply == "savings"){
            
                CurrentUser.SavingsBalance = CurrentUser.GetSavingsBalance() - amount;
                CurrentUser.CheckingBalance = CurrentUser.GetCheckingBalance() + amount;
                }
            else
            {
             if(amount <= CurrentUser.CheckingBalance)
             CurrentUser.CheckingBalance = CurrentUser.GetCheckingBalance() - amount;
             CurrentUser.SavingsBalance = CurrentUser.GetSavingsBalance() + amount;
            }
        }
        

        public void AddData(bool madedeposit,string reply, int amount, User CurrentUser, List<string> atmdata){
            var convertamount = Convert.ToString(amount);
            var deposit = "";
            if(madedeposit){
                deposit = "deposit";
                }
            atmdata.Add(deposit);
            atmdata.Add(convertamount);
            atmdata.Add(CurrentUser.AccountOwner);
            
        }

        public void DataWriter(List<string> atmdata){

          Console.WriteLine("---------------------");
            foreach (var transaction in atmdata)
            {               Console.WriteLine($" {transaction[0]}");
            }
            
        }

    }
}