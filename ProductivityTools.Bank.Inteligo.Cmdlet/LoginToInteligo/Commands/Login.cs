using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductivityTools.Bank.Inteligo.Caller;
using ProductivityTools.Bank.Millenium.App.Runner;
using ProductivityTools.Bank.Millenium.Selenium;
using ProductivityTools.MasterConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Bank.Inteligo.Cmdlet.LoginToInteligo.Commands
{
    class Login : InteligoCommandBase<LoginToInteligoCmdlet>
    {
        public Login(LoginToInteligoCmdlet cmdletType) : base(cmdletType)
        {
        }

        protected override bool Condition => true;

        protected override void Invoke()
        {
            this.InteligoApplication.Login(Login, Password,this.Cmdlet.ShowBrowser);
        }
    }
}
