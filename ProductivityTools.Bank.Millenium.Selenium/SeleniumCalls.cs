using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProductivityTools.BankAccounts.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Login");
            Console.WriteLine(loginBox);
            var loginControl = loginBox.FindElement(By.TagName("input"));
            Console.WriteLine("Login found");
            Thread.Sleep(2000);
            var x = loginControl.GetAttribute("innerHTML");
            var x1 = loginControl.GetAttribute("outerHTML");
            Console.WriteLine(x1);
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


        public List<BasicData> GetBasicData()
        {
            var result = new List<BasicData>();
            var accountTable=this.Chrome.FindElement(By.ClassName("AccountsTable"));
            var rowseven = accountTable.FindElements(By.ClassName("row_even"));
            var rowsodd = accountTable.FindElements(By.ClassName("row_odd"));

            var allRows = rowseven.Concat(rowsodd);

            foreach (var row in allRows)
            {
                BasicData basicData = new BasicData();
                result.Add(basicData);

                var x = row.FindElements(By.TagName("TD"));
                string accountName = x[0].Text;
                string availiablefunds = x[1].Text;
                string saldo = x[2].Text;

                basicData.AvailiableFunds = decimal.Parse(availiablefunds);
                basicData.Saldo = decimal.Parse(saldo);
                basicData.BlockedFunds = basicData.Saldo - basicData.AvailiableFunds;
                basicData.Bank = "Inteligo";
                basicData.Account = accountName.Split('\n')[0].Trim();               
            }

            return result;
        }
    }
}
