using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net.Sockets;

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
        }
    }
}
