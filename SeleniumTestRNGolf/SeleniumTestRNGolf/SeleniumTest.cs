using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

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

        string testPageUrl = "http://localhost:3000/testpage.html";


        [TestMethod]
        public void BallCanGetInHoleTest()
        {

            //chromeDriver.Navigate().GoToUrl("https://www.google.com/");
            //chromeDriver.Quit();

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

        [TestMethod]
        public void ReturnHitvalueIsCorrect()
        {
            firefoxDriver.Navigate().GoToUrl("http://localhost:3000/playerPage.htm");


            // udskriver det sidste slags længde
            IWebElement result = firefoxDriver.FindElement(By.Id("current-hit"));

            // Knap der kalder metoden
            IWebElement PositionCalled = firefoxDriver.FindElement(By.Id("ScoreBtn"));

            // simulerer et click på Tag næste sving knappen
            PositionCalled.Click();
            Thread.Sleep(200);

            // tager resultet fra current-hit og laver den om til en int
            int methodResult = Int32.Parse(result.Text);

            // forvente værdi
            int actualValue = 200;

            //assert
            // her testes om værdierne er ens
            Assert.AreEqual(actualValue, methodResult);

            firefoxDriver.Quit();
        }
    }
}
