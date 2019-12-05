using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SeleniumTestRNGolf
{
    [TestClass]
    public class SeleniumTest
    {

        //disse drivers finder henholdsvis geckodriver og chromedriver,
        //der er lagt sammen med projektets .cs og .csproj filer,
        //ved at lede i appens base directory
        IWebDriver firefoxDriver = new FirefoxDriver(AppContext.BaseDirectory);
        IWebDriver chromeDriver = new ChromeDriver(AppContext.BaseDirectory);

        [TestMethod]
        public void TestMethod1()
        {
            chromeDriver.Navigate().GoToUrl("https://www.google.com/");
            chromeDriver.Quit();
        }


        [TestMethod]
        public void TestMethod2()
        {
            firefoxDriver.Navigate().GoToUrl("https://www.google.com/");
            firefoxDriver.Quit();
        }
    }
}
