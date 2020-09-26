using ProductivityTools.Bank.Millenium.Selenium;
using ProductivityTools.BankAccounts.Contract;
using System;

namespace ProductivityTools.Bank.Millenium.App.Runner
{
    public class InteligoApplication
    {
        SeleniumCalls Selenium;

        public InteligoApplication(SeleniumCalls selenium)
        {
            this.Selenium = selenium;
        }


        public void Run(string login, string password)
        {
            Selenium.Login(login, password);
            BasicData basicData = this.Selenium.GetBasicData();
        }
    }
}
