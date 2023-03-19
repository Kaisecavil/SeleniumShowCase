using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumShowCase
{
    public class LoginPageObject
    {
        private IWebDriver _webDriver;
        private By _usernameInputButton = By.Id("username");
        private By _passwordInputButton = By.Id("password");
        private By _loginButton = By.XPath("//button[@type = \"submit\"]");
        public LoginPageObject(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        public void Login(string usename, string password) 
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            IWebElement usernameField = wait.Until(e => e.FindElement(_usernameInputButton));
            IWebElement passwordField = wait.Until(e => e.FindElement(_passwordInputButton));
            usernameField.SendKeys(usename);
            passwordField.SendKeys(password);
            IWebElement loginBtn = wait.Until(e => e.FindElement(_loginButton));
            loginBtn.Click();

        }
    }
}
