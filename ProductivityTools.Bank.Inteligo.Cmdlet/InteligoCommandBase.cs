using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductivityTools.Bank.Inteligo.Caller;
using ProductivityTools.Bank.Millenium.App.Runner;
using ProductivityTools.Bank.Millenium.Selenium;
using ProductivityTools.MasterConfiguration;
using ProductivityTools.PSCmdlet;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Bank.Inteligo.Cmdlet
{
    internal abstract class InteligoCommandBase<T> : PSCmdlet.PSCommandPT<T> where T : PSCmdletPT
    {
        protected InteligoApplication InteligoApplication;
        protected string Password;
        protected string Login;

        public InteligoCommandBase(T cmdletType) : base(cmdletType)
        {
            string environment = Environment.GetEnvironmentVariable("MasterConfigurationPath");

            if (String.IsNullOrWhiteSpace(environment))
                throw new ArgumentNullException("MasterConfigurationPath Environment variable not set-up");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddMasterConfiguration(force: true)
                .Build();

            Login = configuration["login"];
            Password = configuration["password"];

            var serviceProvider = new ServiceCollection()
                .AddSingleton<InteligoApplication>()
                .AddSingleton<SeleniumCalls>()
                .AddSingleton<HttpCaller>()
                .BuildServiceProvider();
            InteligoApplication = serviceProvider.GetService<InteligoApplication>();
        }
    }
}
