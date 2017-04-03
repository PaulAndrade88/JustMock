using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMock
{
    public class AccountService : IAccountService
    {
        private readonly ICurrencyService currencyService;

        public AccountService(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public void TransferFunds(Account from, Account to, decimal amount)
        {
            from.Withdraw(from);
            decimal conversionRate = 
                currencyService.GetConversionRate(from.Currency, to.Currency);
            decimal convertedAmount = amount * conversionRate;
            to.Deposit(convertedAmount);
        }
    }
}
