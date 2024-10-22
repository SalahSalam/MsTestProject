using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.DevTools;
namespace MsTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\Users\\salah\\webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
             _driver = new ChromeDriver(DriverDirectory);
            //_driver = new FirefoxDriver(DriverDirectory);
            // _driver = new EdgeDriver(DriverDirectory); 
        }


        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //_driver.Navigate().GoToUrl("http://localhost:5503/index.htm");
            _driver.Navigate().GoToUrl("file:///C:/Users/salah/javascript/CollectWords/index.html");
            Assert.AreEqual("Collect Words", _driver.Title);

            IWebElement inputElement1 = _driver.FindElement(By.Id("input"));
            inputElement1.SendKeys("abc");

            IWebElement saveButton = _driver.FindElement(By.Id("save"));
            saveButton.Click();

            IWebElement showButton = _driver.FindElement(By.Id("show"));
            showButton.Click();

            IWebElement resultElement = _driver.FindElement(By.Id("message"));
            Assert.AreEqual("List of words: abc", resultElement.Text);

            inputElement1.Clear();
            inputElement1.SendKeys("def");
            saveButton.Click();
            showButton.Click();
            Assert.AreEqual("List of words: abc, def", resultElement.Text);

            IWebElement clearButton = _driver.FindElement(By.Id("clear"));
            clearButton.Click();
            showButton.Click();
            Assert.AreEqual("No words to show.", resultElement.Text);
        }
    }
}