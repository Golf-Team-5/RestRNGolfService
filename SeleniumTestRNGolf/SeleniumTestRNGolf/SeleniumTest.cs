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
        //der er lagt i bin\debug\netcoreapp2.1,
        //ved at lede i appens base directory

        IWebDriver firefoxDriver = new FirefoxDriver(AppContext.BaseDirectory);
        //IWebDriver chromeDriver = new ChromeDriver(AppContext.BaseDirectory);

        string testPageUrl =  "http://localhost:3000/testpage.html";

        [TestMethod]
        public void BallCanGetInHoleTest()
        {
            firefoxDriver.Navigate().GoToUrl(testPageUrl);
            IWebElement testScoreBtn = firefoxDriver.FindElement(By.Id("scoreBtn"));
            

            testScoreBtn.Click();
            
        }


        [TestMethod]
        public void TestMethod2()
        {
            firefoxDriver.Navigate().GoToUrl(testPageUrl);
            firefoxDriver.Quit();
        }
    }
}
