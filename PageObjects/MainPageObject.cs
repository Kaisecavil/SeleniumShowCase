using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumShowCase
{
    public class MainPageObject
    {
        private IWebDriver _webDriver;
        private By _formAuthButton = By.XPath("//a[text()='Form Authentication']");

        public MainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public LoginPageObject LoginPage()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            IWebElement formauthBtn = wait.Until(e => e.FindElement(_formAuthButton));
            formauthBtn.Click();
            return new LoginPageObject(_webDriver);
        }
    }
}
