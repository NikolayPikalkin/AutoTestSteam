using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2.PageObjects
{
    class MarketPageObject
    {
        private readonly By uniqueElement = By.XPath("//div[@class='market_header_logo']");
        private readonly By showOptions = By.XPath("//div[@class='market_search_advanced_button']");
        private readonly By searchAdvancedForm = By.XPath("//form[@id='market_advanced_search']");
        private readonly By selectGameBar = By.XPath("//div[@id='market_advancedsearch_appselect_activeapp']");
        private readonly By selectGameDota2 = By.XPath("//div[@id='market_advancedsearch_appselect_options_apps']//span[contains(text(),'Dota 2')]");
        private readonly By selectHero = By.XPath("//div[@class='econ_tag_filter_category']//select[@name='category_570_Hero[]']");
        private readonly By selectLifestealer = By.XPath("//div[@class='econ_tag_filter_category']//option[@value='tag_npc_dota_hero_life_stealer']");
        private readonly By rarityImmortal = By.XPath("//input[@value='tag_Rarity_Immortal']");
        private readonly By inputTextSearch = By.XPath("//input[@class='filter_search_box market_search_sidebar_search_box']");
        private readonly By searchButton = By.XPath("//div[@class='btn_medium btn_green_white_innerfade']//span");

        private readonly By tagDota2 = By.XPath("//div[@class='market_search_results_header']//a[1]");
        private readonly By tagLifestealer = By.XPath("//div[@class='market_search_results_header']//a[2]");
        private readonly By tagImmortal = By.XPath("//div[@class='market_search_results_header']//a[3]");
        private readonly By tagGolden = By.XPath("//div[@class='market_search_results_header']//a[4]");

        private readonly By firstFiveResults = By.XPath("(//span[@class='market_listing_item_name'])[position()<6]");

        private readonly By deleteDota2Button = By.XPath("//div[@class='market_search_results_header']//a[1]//span");
        private readonly By deleteGoldenButton = By.XPath("//div[@class='market_search_results_header']//a[4]//span");
        private readonly By countResultsAfterDelete = By.XPath("//div[@id='searchResultsRows']//a");

        private readonly By nameFistItem = By.XPath("//span[@id='result_0_name']");

        public bool IsMarketPageOpen()
        {
            var unEl = InitWebDriver.GetDriver().FindElements(uniqueElement).Count > 0;
            return unEl;
        }
        public void ShowOptionsClick()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), showOptions);
            InitWebDriver.GetDriver().FindElement(showOptions).Click();
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), searchAdvancedForm);
        }
        public bool IsSearchFormOpen()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), searchAdvancedForm);
            var unEl = InitWebDriver.GetDriver().FindElements(searchAdvancedForm).Count > 0;
            return unEl;
        }
        public void SelectedGameClick()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), selectGameBar);
            InitWebDriver.GetDriver().FindElement(selectGameBar).Click();
        }
        public void SelectedDota2()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), selectGameDota2);
            InitWebDriver.GetDriver().FindElement(selectGameDota2).Click();
        }
        public void SelectedHeroLifestealer()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), selectHero);
            InitWebDriver.GetDriver().FindElement(selectHero).Click();
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), selectLifestealer);
            InitWebDriver.GetDriver().FindElement(selectLifestealer).Click();
        }
        public void SelectedImmortal()
        {
            InitWebDriver.GetDriver().FindElement(rarityImmortal).Click();
        }
        public void InputTextSearch()
        {
            InitWebDriver.GetDriver().FindElement(inputTextSearch).SendKeys(BaseTest.testModel.SearchTag);
        }
        public void SearchButtonClick()
        {
            InitWebDriver.GetDriver().FindElement(searchButton).Click();
        }
        public bool IsCheckingSelectedTags()
        {
            var tDota2 = InitWebDriver.GetDriver().FindElement(tagDota2).Text;
            var tLifestealer = InitWebDriver.GetDriver().FindElement(tagLifestealer).Text;
            DataGameDota2.Hero = tLifestealer;
            var tImmortal = InitWebDriver.GetDriver().FindElement(tagImmortal).Text;
            DataGameDota2.Rarity = tImmortal;
            var tGolden = InitWebDriver.GetDriver().FindElement(tagGolden).Text;

            if (tDota2 == "Dota 2" && tLifestealer == "Lifestealer" && tImmortal == "Immortal" && tGolden == "«golden»")
            {
                return true;
            }
            else
                return false;
        }
        public bool IsCheckingFirstFiveResults()
        {
            var listResults = InitWebDriver.GetDriver().FindElements(firstFiveResults);
            string str;
            foreach (var e in listResults)
            {
                str = e.Text;
                if (!str.Contains("Golden"))
                {
                    return false;
                } 
            }
            return true;
        }
        public void DeleteTagDota2Golden()
        {
            InitWebDriver.GetDriver().FindElement(deleteDota2Button).Click();
            InitWebDriver.GetDriver().FindElement(deleteGoldenButton).Click();

        }
        public bool IsResultsUpdated()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), countResultsAfterDelete);
            var countResults = InitWebDriver.GetDriver().FindElements(countResultsAfterDelete).Count > 8;
            return countResults;
        }
        public void OpenFistResultClick()
        {
            var name = InitWebDriver.GetDriver().FindElement(nameFistItem);
            DataGameDota2.ItemName = name.Text;
            name.Click();
        }
    }
}
