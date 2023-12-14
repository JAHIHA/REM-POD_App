using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REM_POD_AppTests.files
{
    public class Seleniumtest
    {
        [TestClass]
        public class UnitTest1
        {
            private static readonly string DriverDirectory = "C:\\Drivers";
            private static IWebDriver _driver;


            [ClassInitialize]
            public static void Setup(TestContext context)
            {
                _driver = new FirefoxDriver(DriverDirectory);
            }

            [ClassCleanup]
            public static void TearDown()
            {
                _driver.Dispose();
            }

            [TestMethod]
            public void TestMethod1()
            {
               
                _driver.Navigate().GoToUrl("file:///C:/javascript/Books/Books.html");


                string title = _driver.Title;
                Assert.AreEqual("REM Pod", title);

                IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
                buttonElement.Click();



                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                IWebElement data = wait.Until(d => d.FindElement(By.Id("temperature")));
                Assert.IsTrue(data.Text.Contains("Temperature"));


                ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.TagName("li"));
                Assert.AreEqual(3, listElements.Count);


            }
        }
    }

}
