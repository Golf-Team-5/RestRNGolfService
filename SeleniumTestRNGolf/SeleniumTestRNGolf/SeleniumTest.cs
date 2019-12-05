using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumTestRNGolf
{
    [TestClass]
    public class SeleniumTest
    {

        //disse drivers finder henholdsvis geckodriver og chromedriver,
        //der er lagt sammen med projektets .cs og .csproj filer,
        //ved at lede i appens base directory
        //IWebDriver firefoxDriver = new FirefoxDriver(AppContext.BaseDirectory);
        IWebDriver firefoxDriver = new FirefoxDriver(AppContext.BaseDirectory);

        [TestMethod]
        public void TestMethod1()
        {
            //chromeDriver.Navigate().GoToUrl("https://www.google.com/");
            //chromeDriver.Quit();
        }


        [TestMethod]
        public void TestMethod2()
        {
            firefoxDriver.Navigate().GoToUrl("http://localhost:3000/testpage.html");
            firefoxDriver.Quit();
        }

        [TestMethod]
        public void TestMethod3()
        {
            firefoxDriver.Navigate().GoToUrl("http://localhost:3000/testpage.html");
            

            //string testCourseLength = "1000";
            string testHit = "200";

            Thread.Sleep(500);
            // Tager fat i to input elementer på test html siden via deres id
           // IWebElement courseLength = firefoxDriver.FindElement(By.Id("course-length"));
            IWebElement golfHit = firefoxDriver.FindElement(By.Id("hit"));
            // Resulatet af metodekald vises her
            IWebElement result = firefoxDriver.FindElement(By.Id("resultat-af-et-slag"));
            // Knap der kalder metoden
            IWebElement PositionCalled = firefoxDriver.FindElement(By.Id("PositionButton"));

          //  courseLength.Clear();
          //  courseLength.SendKeys(testCourseLength);
            Thread.Sleep(1000);
            golfHit.Clear();
            golfHit.SendKeys(testHit);
            Thread.Sleep(1000);

            PositionCalled.Click();
            Thread.Sleep(1000);
            
            int methodResult = Int32.Parse(result.Text);

            int actualValue = 800;

            //assert
            Assert.AreEqual(actualValue,methodResult);

            //firefoxDriver.Quit();
        }
    }
}
