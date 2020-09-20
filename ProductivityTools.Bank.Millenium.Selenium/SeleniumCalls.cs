using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    }
}
