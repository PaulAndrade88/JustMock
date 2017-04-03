using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMock
{
    public class Account
    {
        public string Currency { get; set; }
        public decimal Balance { get; set; }

        public Account(int balance, string type)
        {

        }
        
        public int Withdraw(Account account)
        {
            return 0;
        }

        public void Deposit(decimal deposit)
        {

        }        
    }
}
