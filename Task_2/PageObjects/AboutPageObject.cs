using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2.PageObjects
{
    class AboutPageObject
    {
        private readonly By uniqueElement = By.XPath("//div[@id='about_games_hero']");
        private readonly By countOnline = By.XPath("//div[contains(@class,'online_stat_label gamers_online')]/parent::div");
        private readonly By countPlayingNow = By.XPath("//div[contains(@class,'online_stat_label gamers_in_game')]/parent::div");
        private readonly By homePageButton = By.XPath("//div[@class='supernav_container']//a[@data-tooltip-content='.submenu_store']");

        public bool IsComparePlayers()
        {
            var onlinePlayers = Convert.ToInt32(ParseStringToInt.ParseDataString(countOnline));
            var playingNow = Convert.ToInt32(ParseStringToInt.ParseDataString(countPlayingNow));

            return playingNow < onlinePlayers;
        }

        public bool IsAboutPageOpen()
        {
            var unEl = InitWebDriver.GetDriver().FindElements(uniqueElement).Count > 0;

            if (unEl)
            {
                return true;
            }
            else
                return false;
        }

        public void GoToHome()
        {
            InitWebDriver.GetDriver().FindElement(homePageButton).Click();
        }

    }
}
