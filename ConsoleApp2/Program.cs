using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;




//  TRANSFER
//--transfer from savings, OR checking to the other
//--this should prompt the user to enter an amount to transfer, then manipulate that amount. 
//--This should do some basic error handler 
//---make sure that the value inputted is a number & amount entered is available


// STORING BALANCE & TRANSACTIONS
// the system should save the new amount to a file after every action
// the system should log all the transactions that occur to a file
//---LOG what was done, the amount that moved, & when it happened, accounts affected

namespace ATMApp
{
    class Program
    {
        static void PrintData(List<string> atmdata){
                foreach (var transaction in atmdata)
                    {
                    Console.WriteLine($" {transaction[0]}");
                    }
         }

        static void Main(string[] args)
        {
            //need User Interface
            //prompt user to choose withdraw, deposit, or transfer, view transactions

            var Customer = new User("11111S", "11111C", "Octo Cat", 100, 100);
            var AccountData = new Account(Customer);
            List<string> atmData = new List<string>();
            const string FILE_PATH = "../../atmdata.txt";

            Console.WriteLine($"Hello, {Customer.AccountOwner}.\n" +
                $"Your checking account has: ${Customer.GetCheckingBalance()}\n" +
                $"Your savings account has: ${Customer.GetSavingsBalance()}");

            
            
       
           
            var isRunning = true;
            while(isRunning){
                
        
                // read the contents of the file, add to the list
                using (var reader = new StreamReader(FILE_PATH))
                {
                while (reader.Peek() > -1)
                    {
                        var line = reader.ReadLine().Split(',');
                         atmData.Add(line[0]);
                    }
                }

                var savings= ($"Your new Savings balance is : {Customer.GetSavingsBalance()}");
                var checking= ($"Your new Checking balance is : {Customer.GetCheckingBalance()}");

                Console.WriteLine($"Select Options (enter number):\n " +
                    $"1. View Balance \n " +
                    $"2. Make a Withdrawal \n " +
                    $"3. Make a Deposit \n " +
                    $"4. View Transactions \n " +
                    $"5. Transfer Funds \n " +
                    $"6. Quit");
                var reply = Console.ReadLine();
                if (reply == "1")
                {
                    Console.WriteLine("Would you like to view savings or checking?");
                    reply = Console.ReadLine().ToLower();
                    if (reply == "savings")
                    {
                        Console.WriteLine(savings);
                    }
                    else
                        Console.WriteLine(checking);
                }
                else if (reply == "2")
                {
                    Console.WriteLine("Would you like to withdraw from savings or checking?");
                    reply = Console.ReadLine().ToLower();
                    Console.WriteLine("What amount do you want to withdraw?");
                    var amountEntered = Console.ReadLine();
                    var amount = Convert.ToInt32(amountEntered);
                    AccountData.Withdraw(reply, amount, Customer);
                        if (reply == "savings")
                        {
                        Console.WriteLine($"Your remaining balance is:{Customer.GetSavingsBalance()}");
                        }
                        else
                        Console.WriteLine($"Your remaining balance is:{Customer.GetCheckingBalance()}");
                }
            
                else if (reply == "3")
                {
                    Console.WriteLine("Would you like to deposit to savings or checking?");
                    reply = Console.ReadLine().ToLower();
                    Console.WriteLine("What amount do you want to deposit?");
                    var amountEntered = Console.ReadLine();
                    var amount = Convert.ToInt32(amountEntered);
                    var madedeposit = true;
                    AccountData.Deposit(reply, amount, Customer);
                            if (reply == "savings")
                            {
                                 Console.WriteLine($"Your new balance is: {Customer.GetSavingsBalance()}");
                             }
                            else
                                Console.WriteLine($"Your new balance is: {Customer.GetCheckingBalance()}");
                   AccountData.AddData(madedeposit,reply,amount,Customer,atmData);
                  
                }
                else if (reply == "4")
                {
                    PrintData(atmData);
                    AccountData.DataWriter(atmData);
                    Console.WriteLine(atmData[0]);
                }
                else if (reply == "5")
                {
                    Console.WriteLine("Would you like to transfer to savings or checking?");
                    reply = Console.ReadLine().ToLower();

                    var transfer = true;
                        while(transfer){
                    Console.WriteLine("What amount do you want to transfer?");
                    var amountEntered = Console.ReadLine();
                    var amount = Convert.ToInt32(amountEntered);
                        if(reply == "savings"){
                        
                            if(amount <=0 || amount >= Customer.SavingsBalance){
                            Console.WriteLine($"Please enter amount less than or equal to {Customer.SavingsBalance}");
                            }
                            else
                             {
                                AccountData.Transfer(reply, amount, Customer);
                                Console.WriteLine($"After transfer your savings balance is: {Customer.GetSavingsBalance()}");
                                transfer = false;
                             }   
                            }
                        
                         else{ 
                        
                            if(amount <=0 || amount >= Customer.CheckingBalance){
                                Console.WriteLine($"Please enter amount less than or equal to {Customer.CheckingBalance}");
                             }
                            else{
                                AccountData.Transfer(reply, amount, Customer);
                                Console.WriteLine($"After transfer your checking balance is:{Customer.GetCheckingBalance()}");
                                transfer = false;
                                }
                            }
                          }
                        }
                 else {      
                     
                     Console.WriteLine("Goodbye");
                     isRunning = false;
                     Console.ReadLine();   

                      }
                   }
            
            
                 }
               }
             }
              
    
    
            
        
    
    
 
        
  
   