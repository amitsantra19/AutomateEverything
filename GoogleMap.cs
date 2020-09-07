using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Collections.Generic;

namespace AutomateGoogleMap
{
    [TestClass]
    public class GoogleMap
    {
        [TestMethod]
        public void AutomateGoogleMap()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.google.co.in/maps/");
            webDriver.Manage().Window.Maximize();
            Thread.Sleep(4000);
            var mylocation = webDriver.FindElement(By.Id("mylocation"));
            mylocation.Click();
            Thread.Sleep(2000);
            Actions actions = new Actions(webDriver);
            var element = webDriver.FindElement(By.ClassName("widget-scene-canvas"));
            actions.ContextClick(element).Build().Perform();
            Thread.Sleep(2000);
            var getdirection = webDriver.FindElements(By.ClassName("action-menu-entry-text")).FirstOrDefault(ele => ele.Text.Equals("Directions from here"));
            Actions actions1 = new Actions(webDriver);
            actions1.Click(getdirection).Build().Perform();
            Thread.Sleep(3000);
            IEnumerable<IWebElement> destinationBox = webDriver.FindElements(By.ClassName("tactile-searchbox-input")).Where(ele => ele.Displayed).ToList();
            var chooseDest = destinationBox.FirstOrDefault(ele => ele.GetAttribute("aria-label").Contains("Choose destination"));
            chooseDest.Click();
            Thread.Sleep(2000);
            chooseDest.SendKeys("truffles");
            //var suggestList = webDriver.FindElement(By.ClassName("suggestions-grid"));
            IWebElement select = webDriver.FindElements(By.ClassName("sbsb_c")).FirstOrDefault(ele => ele.Text.Contains("4th B Cross Rd, 5th Block, Koramangala"));
            select.Click();
            Thread.Sleep(1000);
            //var minDistance = webDriver.FindElement(By.ClassName("section-directions-trip-numbers"));
        }
    }
}
