using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMock
{
    public interface IAccountService
    {        
        void TransferFunds(Account from, Account to, decimal amount);
    }
}
