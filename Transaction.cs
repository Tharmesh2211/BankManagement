using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement
{
    public class Transaction : AccountList
    { 
        public int AccountNumber {  get; set; }
        public string TransactionType {  get; set; }
        public double StoreAmount { get; set; } 
        public double TotalBalance {  get; set; }

        List<Transaction> transactions = null;
        
        Transaction transaction = null, StoreTransaction = null;

        int x = 0;
        public Transaction() 
        {
            transactions = new List<Transaction>();
        }

        public override void Deposit()
        {
            try
            {
                bool check = true;

                while(check)
                {
                    Console.Clear();

                    Console.WriteLine("Deposit Amount Should Be 100 Multiple !");
                        
                    Console.Write("\nEnter Account Number To Deposit  -  ");
                    int AccountNumber = int.Parse(Console.ReadLine());

                    
                    if (FindAccount(AccountNumber))
                    {
                        Console.Write("Enter Deposit Amount  -  ");

                        int DepositAmount = int.Parse(Console.ReadLine());

                        if (DepositAmount % 100 != 0)
                            continue;

                        StoreAccount.Inital_Balance += DepositAmount;

                        transaction = new Transaction
                        {
                            AccountNumber = StoreAccount.AccountNumber,

                            TransactionType = DepositAmount + " ( D )",

                            TotalBalance = StoreAccount.Inital_Balance
                        };

                        AddTransAccount(transaction);

                        Console.WriteLine("Amount Deposited Successfully !!");
                    }
                    else
                    {
                        Console.WriteLine("No Account Found !!");
                    }

                    check = false;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void AddTransAccount(Transaction transaction)
        {
            try
            {
                transactions.Add(transaction);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message); 
            }
        }

        public override void Withdrawal()
        {
            try
            {
                bool check = true;

                while (check)
                {
                    Console.Clear();
                    Console.WriteLine("Withdrawal Amount Should Be 100 Multiple !");

                    Console.Write("Enter Account Number To Witdraw  -  ");
                    int AccountNumber = int.Parse(Console.ReadLine());

                    if (FindAccount(AccountNumber))
                    {
                        Console.Write("Enter Withdraw Amount  -  ");

                        int WithdrawAmount = int.Parse(Console.ReadLine());

                        if (WithdrawAmount % 100 != 0)
                            continue;

                        if (WithdrawAmount > StoreAccount.Inital_Balance)
                        {
                            Console.WriteLine("Insufficient Amount !");
                            Console.ReadKey();
                            break;
                        }
                        
                        StoreAccount.Inital_Balance -= WithdrawAmount;

                        transaction = new Transaction
                        {
                            AccountNumber = StoreAccount.AccountNumber,

                            TransactionType = WithdrawAmount + " ( W )",

                            TotalBalance = StoreAccount.Inital_Balance
                        };

                        AddTransAccount(transaction);

                        Console.WriteLine("Amount Withdrawan Successfully !!");

                    }
                    else
                    {
                        Console.WriteLine("No Account Found !!");
                    }
                    check = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool SeaarchTransAccount(int AccountNumber)
        {
            foreach(var transaccount in transactions)
            {
                if (transaccount.AccountNumber == AccountNumber)
                    return true;
            }
            return false;
        }
        public override void ReadOneTransaction()
        {
            if(IsCount())
            {
                Console.WriteLine("\nReading Transaction Detail !!");

                Console.Write("Enter Account Number   -  ");
                int AccountNumber = int.Parse(Console.ReadLine());
                int x = 0;
                if(SeaarchTransAccount(AccountNumber) && FindAccount(AccountNumber))
                {
                    Console.Clear();
                    foreach (var transaction in transactions)
                    {
                        if (transaction.AccountNumber == AccountNumber)
                        {
                            if (x == 0)
                            {
                                Console.WriteLine("Account Number   -  " + transaction.AccountNumber);
                                Console.WriteLine("\nOld Amount     -  " + StoreAccount.Store_Inital_Balance);
                                x = 1;
                            }

                            StoreTransaction = transaction;
                            Console.WriteLine("\nTransaction Type  -  " + transaction.TransactionType);
                        }
                    }

                    Console.WriteLine("\nAvailable Balance    -  " + StoreTransaction.TotalBalance);
                }
                else
                {
                    Console.WriteLine("Account Not Found !");
                }
            }
            else
            {
                Console.WriteLine("Transaction List Is Empty !!");
            }
            
        }

        public override bool IsCount()
        {
            if(transactions!=null && transactions.Count != 0)
            {
                return true;
            }
            return false;
        }
    }
}
