/*
 Mocking is a concept in Unit Testing where the dependencies 
 in the software being tested are substituted with proxies 
 that are programmed to act in a controlled manner. 
 This prevents those dependencies from interfering with the results. 
 Mocking is commonly used for removing dependencies like database 
 or file system access, or calls to code that are out of scope for the unit being tested.
 */
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace JustMock.Tests
{
    [TestClass]
    public class JustMock
    {
        [TestMethod]
        public void Mocking()
        {
            //AAA PATTERN Arrange-Act-Asserts

            //ARRANGE
            //GetCurrencyService is being called to retrieve the conversion rate.
            ICurrencyService GetCurrencyService = Mock.Create<ICurrencyService>();
            
            //Set an expected return value:            
            Mock.Arrange(() => GetCurrencyService.GetConversionRate("GBP", "CAD"))
                .Returns(2.20m);//.MustBeCalled();
            
            /* Mock.Arrange - is the entry-point for setting expected behavior for given mock.
             * MustBeCalled - This ensures that if GetCurrencyService.GetConversationRate is not called with
               the above citeria. then it will fail the test. */

            var accountService = new AccountService(GetCurrencyService);
            var canadianAccount = new Account(0, "CAD");
            var britishAccount = new Account(0, "GBP");

            //ACT
            britishAccount.Deposit(100);
            accountService.TransferFunds(britishAccount, canadianAccount, 100);

            //ASSERT
            Assert.AreEqual(0, britishAccount.Balance);
            Assert.AreEqual(0, canadianAccount.Balance);

            //Verify whether the required GetConversationRate method is called as expected.
            Mock.Assert(GetCurrencyService);
        }        
    }
}
