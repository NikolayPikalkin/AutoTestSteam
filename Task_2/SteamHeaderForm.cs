using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    class SteamHeaderForm
    {
        private readonly By communityLocator = By.XPath("//div[@class='supernav_container']//a[@data-tooltip-content='.submenu_community']");
        private readonly By marketLocator = By.XPath("//div[@class='supernav_container']//div[@class='submenu_community']//a[contains(@href,'market')]");
        public void CursorOnComminity()
        {
            Actions actions = new Actions(InitWebDriver.GetDriver());
            var community = InitWebDriver.GetDriver().FindElement(communityLocator);
            actions.MoveToElement(community).Build().Perform();
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), marketLocator);
        }
        public void CommunityButtonClick()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), marketLocator);
            var marketButton = InitWebDriver.GetDriver().FindElement(marketLocator);
            marketButton.Click();
        }


    }
}
