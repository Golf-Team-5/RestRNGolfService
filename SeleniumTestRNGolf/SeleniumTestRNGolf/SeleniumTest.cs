using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestRNGolf
{
    [TestClass]
    public class SeleniumTest
    {
        IWebDriver driver = new ChromeDriver("http://localhost:52549/api/swingdata");

        [TestInitialize]
        public void TestSetUp()
        {
            driver.Navigate().GoToUrl("https://");
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
