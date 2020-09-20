using Microsoft.Extensions.DependencyInjection;
using ProductivityTools.Bank.Millenium.App.Runner;
using ProductivityTools.Bank.Millenium.Selenium;
using System;
using System.Security.Authentication.ExtendedProtection;

namespace ProductivityTools.Bank.Inteligo.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<InteligoApplication>()
                .AddSingleton<SeleniumCalls>()
                .BuildServiceProvider();
            var application = serviceProvider.GetService<InteligoApplication>();
            application.Run("fdsa", "fdsa");
            Console.ReadLine();
        }
    }
}
