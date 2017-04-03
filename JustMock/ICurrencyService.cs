using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMock
{
    public interface ICurrencyService
    {
        decimal GetConversionRate(string fromCurrency, string toCurrency);
    }
}
