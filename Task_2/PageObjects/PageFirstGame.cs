using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2.PageObjects
{
    class PageFirstGame
    {
        private readonly By uniqueElement = By.XPath("//div[@id='appDetailsUnderlinedLinks']//div[@class='block_content']");
        private readonly By titleGameLocator = By.XPath("//div[@id='appHubAppName']");
        private readonly By dateReleaseLocator = By.XPath("//div[@class='release_date']//div[@class='date']");
        private readonly By priceLocator = By.XPath("//div[@class='game_area_purchase_game']//div[contains(@class,'game_purchase_price price')]");
        public bool IsGamePageOpen()
        {
            var unEl = InitWebDriver.GetDriver().FindElements(uniqueElement).Count > 0;

            return unEl;
            
        }
        public bool IsDataСomparison()
        {
            var titleGame = InitWebDriver.GetDriver().FindElement(titleGameLocator).Text;
            var dateRelease = InitWebDriver.GetDriver().FindElement(dateReleaseLocator).Text;
            var price = Convert.ToInt32(ParsePrice.ParseMethod(InitWebDriver.GetDriver().FindElement(priceLocator).Text));
            
            if (String.Equals(titleGame,DataGame.Title) && String.Equals(dateRelease,DataGame.Release) && price == DataGame.Price)
            {
                return true;
            }
            else
                return false;

        }
    }
}
