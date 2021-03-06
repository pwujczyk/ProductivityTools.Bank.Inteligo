﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
            var assemblylocation = System.IO.Path.GetDirectoryName(assemblydlllocation);
        }

        public void Init(bool showbrowser)
        {
            ChromeOptions options = new ChromeOptions();
            if (showbrowser == false)
            {
                options.AddArgument("headless");
            }
            // options.BinaryLocation = System.IO.Path.Join(assemblylocation, "chromedriver.exe");
            this.Chrome = new ChromeDriver(options);
    
        }

        public void CloseBrowser()
        {
            this.Chrome.Close();
        }

        public void Login(string login, string password)
        {
            this.Chrome.Url = Addresses.LoginPage;

            var loginBox = this.Chrome.FindElement(By.ClassName("field_row-client_id_field"));
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

            var additionalSecureWindow = this.Chrome.FindElement(By.ClassName("button_enter"));
            additionalSecureWindow.Click();
        }


        public List<BasicData> GetBasicData()
        {
            var result = new List<BasicData>();
            var accountTable = this.Chrome.FindElement(By.ClassName("scrolled_window"));
            var rowseven = accountTable.FindElements(By.ClassName("row_even"));
            var rowsodd = accountTable.FindElements(By.ClassName("row_odd"));

            var allRows = rowseven.Concat(rowsodd);

            Actions actions = new Actions(this.Chrome);
          

            foreach (var row in allRows)
            {

                actions.MoveToElement(row);
                actions.Perform();

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
