using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProductivityTools.BankAccounts.Contract;
using System;
using System.Net.Sockets;
using System.Threading;

namespace ProductivityTools.Bank.Millenium.Selenium
{
    public class SeleniumCalls
    {
        IWebDriver Chrome;

        public SeleniumCalls()
        {
            var assemblydlllocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var assemblylocation=System.IO.Path.GetDirectoryName(assemblydlllocation);
            ChromeOptions options = new ChromeOptions();
           // options.BinaryLocation = System.IO.Path.Join(assemblylocation, "chromedriver.exe");
            this.Chrome = new ChromeDriver(options);
        }

        public void Login(string login, string password)
        {
            this.Chrome.Url = Addresses.LoginPage;

            var loginBox=this.Chrome.FindElement(By.ClassName("field_row-client_id_field"));
            var loginControl = loginBox.FindElement(By.TagName("input"));
            Thread.Sleep(2000);
            loginControl.SendKeys(login);
            var dalejControl = this.Chrome.FindElement(By.ClassName("button-dalej"));
            dalejControl.Click();

            Thread.Sleep(2000);
            var passwordBox = this.Chrome.FindElement(By.ClassName("field_row-password_field"));
            var passwordControl = passwordBox.FindElement(By.TagName("input"));
            passwordControl.SendKeys(password);
            var loginButtonControl = this.Chrome.FindElement(By.ClassName("button-login"));
            loginButtonControl.Click();
        }


        public BasicData GetBasicData()
        {
            var accountTable=this.Chrome.FindElement(By.ClassName("AccountsTable"));
            var rows = accountTable.FindElements(By.ClassName("row_even"));
            foreach(var row in rows)
            {
                BasicData basicData = new BasicData();
                
                var x = row.FindElements(By.TagName("TD"));
                string accountName = x[0].Text;
                string availiablefunds = x[1].Text;
                string saldo = x[2].Text;

                basicData.AvailiableFunds = decimal.Parse(availiablefunds);
                basicData.Saldo = decimal.Parse(saldo);
            }
            throw new NotImplementedException();
        }
    }
}
