using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace SeleniumShowCase
{
    public class Tests
    {
        private IWebDriver _webDriver;
        private By _flashMessage = By.Id("flash");

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            _webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void AuthFormSuccessTest()
        {
            var mainMenu = new MainPageObject(_webDriver);

            mainMenu
                .LoginPage()
                .Login("tomsmith", "SuperSecretPassword!");

            Assert.IsTrue(GetFlashMessageClass().Contains("success"));
        }

        [Test]
        public void AuthFormFailTest()
        {
            var mainMenu = new MainPageObject(_webDriver);

            mainMenu
                .LoginPage()
                .Login("invalidUserName", "incorrectPassword");
            
            Assert.IsTrue(GetFlashMessageClass().Contains("error"));
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        public string GetFlashMessageClass()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            IWebElement flashMessage = wait.Until(e => e.FindElement(_flashMessage));
            return flashMessage.GetAttribute("class");
        }
    }
}