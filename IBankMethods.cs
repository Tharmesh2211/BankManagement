using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement
{
    public interface IBankMethods
    {
        void AccountInput();
        void IsBalance(Account account);
        void Create(Account account);
        void Read();
        void Update();
        void Delete();
        int Change();
        bool IsContain();
        bool FindAccount(int AccountNumber);
        void Deposit();
        void AddTransAccount(Transaction transaction);
        void Withdrawal();
        void ReadOneTransaction();
        bool IsCount();
    }
}
