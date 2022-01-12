using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public static class WaitUntil
    {
        public static void WaitDownloadUrl(IWebDriver webDriver, string location)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(location));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Cannot find location {location}", ex);
            }

        }
        public static void WaitElement(IWebDriver webDriver, By locator)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(BaseTest.configModel.WaitTime)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(BaseTest.configModel.WaitTime)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
