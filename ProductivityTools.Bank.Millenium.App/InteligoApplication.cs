﻿using ProductivityTools.Bank.Inteligo.Caller;
using ProductivityTools.Bank.Millenium.Selenium;
using ProductivityTools.BankAccounts.Contract;
using System;
using System.Collections.Generic;

namespace ProductivityTools.Bank.Millenium.App.Runner
{
    public class InteligoApplication
    {
        SeleniumCalls Selenium;
        HttpCaller Caller;

        public InteligoApplication(SeleniumCalls selenium, HttpCaller httpCaller)
        {
            this.Selenium = selenium;
            this.Caller = httpCaller;
        }

        public void Login(string login, string password)
        {
            Selenium.Login(login, password);
        }

        public async void Run(string login, string password)
        {
            Selenium.Login(login, password);
            List<BasicData> basicDataList = this.Selenium.GetBasicData();
            foreach (var basicData in basicDataList)
            {
                await this.Caller.SaveBasicData(basicData);
            }
        }
    }
}
