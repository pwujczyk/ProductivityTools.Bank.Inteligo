﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductivityTools.Bank.Inteligo.Caller;
using ProductivityTools.Bank.Millenium.App.Runner;
using ProductivityTools.Bank.Millenium.Selenium;
using ProductivityTools.MasterConfiguration;
using System;
using System.Security.Authentication.ExtendedProtection;

namespace ProductivityTools.Bank.Inteligo.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (String.IsNullOrWhiteSpace(environment))
                throw new ArgumentNullException("Environment not found in ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddMasterConfiguration(force:true)
                .Build();

            var login = configuration["login"];
            var password = configuration["password"];

            var serviceProvider = new ServiceCollection()
                .AddSingleton<InteligoApplication>()
                .AddSingleton<SeleniumCalls>()
                .AddSingleton<HttpCaller>()
                .BuildServiceProvider();
            var application = serviceProvider.GetService<InteligoApplication>();

            application.GetBasicData(login, password,true);
            Console.ReadLine();
        }
    }
}
