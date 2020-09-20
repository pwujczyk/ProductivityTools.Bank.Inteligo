using ProductivityTools.Bank.Millenium.Selenium;
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
        }
    }
}
