using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2.PageObjects
{
    class TopSellersPageObject
    {
       private readonly By uniqueElement = By.XPath("//div[@class='page_content']//h2[@class='pageheader full']");
        private readonly By seeAllTag = By.XPath("//div[contains(@class,'block search_collapse_block')]//a[@class='see_all_expander']");
        private readonly By SteamOs = By.XPath("//span[@data-loc='SteamOS + Linux']//span[@class='tab_filter_control_label']");

        private readonly By checkBoxSteamOsSelected = By.XPath("//div[contains(@class,'block_content block_content_inner')]//input[@id='os' and @value='linux'] ");

        private readonly By numberOfPlayersField = By.XPath("//div[@data-collapse-name='category3']");
        private readonly By menuNumberOfPlayersField = By.XPath("//div[@data-collapse-name='category3' ]//div[contains(@class,'block_content block_content_inner') and @style='display: block;']");
        private readonly By checkBoxLanCoop = By.XPath("//div[@data-value='48']//span[@data-value='48']//span[@class='tab_filter_control_label']");
        private readonly By lanCoopSelected = By.XPath("//div[contains(@class,'block_content block_content_inner')]//input[@id='category3' and @value='48']");

        private readonly By action = By.XPath("//div[@data-value='19']//span[@data-value='19']//span[@class='tab_filter_control_label']");
        private readonly By actionSelected = By.XPath("//div[@id='TagFilter_Container']//input[@value ='19']");

        private readonly By searchResultCount = By.XPath("//div[@class='search_results_count']");
        private readonly By searchResultRows = By.XPath("//div[@id='search_resultsRows']//a");
        private readonly By resultRowsBlock = By.XPath("//div[@class='search_results']");
        private readonly By pageContent = By.XPath("//div[@class='page_content_ctn']");

        private readonly By titleFirstResultLocator = By.XPath("//div[@id='search_resultsRows']//a[1]//span[@class='title']");
        private readonly By dataReleaseFirstResultLocator = By.XPath("//div[@id='search_resultsRows']//a[1]//div[contains(@class,'col search_released responsive_secondrow')]");
        private readonly By priceFirstResultLocator = By.XPath("//div[@class='search_results']//a[1]//div[contains(@class,'col search_price  responsive_secondrow')]");

        public bool IsTopSellersOpen()
        {
            var unEl = InitWebDriver.GetDriver().FindElements(uniqueElement).Count > 0;
            return unEl;
        }
        public void SteamOsClick()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), SteamOs);
            var checkBox = InitWebDriver.GetDriver().FindElement(SteamOs);
            checkBox.Click();
        }
        public bool IsSteamOsSelected()
        {
            var checkBox = InitWebDriver.GetDriver().FindElement(checkBoxSteamOsSelected).Enabled;

            if (checkBox)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void PlayersFieldClick()
        {
            var numbPlay = InitWebDriver.GetDriver().FindElement(numberOfPlayersField);
            numbPlay.Click();
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), menuNumberOfPlayersField);
        }
        public void LanCoopClick()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), checkBoxLanCoop);
            var lan = InitWebDriver.GetDriver().FindElement(checkBoxLanCoop);
            lan.Click();
        }
        public bool IsLanCoopSelected()
        {
            var lanCoop = InitWebDriver.GetDriver().FindElement(lanCoopSelected).Enabled;

            if (lanCoop)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ActionClick()
        {
            var seeAll = InitWebDriver.GetDriver().FindElement(seeAllTag);
            seeAll.Click();
            var act = InitWebDriver.GetDriver().FindElement(action);
            act.Click();
        }
        public bool IsActionSelected()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), resultRowsBlock);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), searchResultCount);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), searchResultRows);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), titleFirstResultLocator);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), dataReleaseFirstResultLocator);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), pageContent);

            var actSel = InitWebDriver.GetDriver().FindElement(actionSelected).Enabled;

            if (actSel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsSearchResultAndCountFound()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), resultRowsBlock);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), searchResultCount);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), searchResultRows);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), titleFirstResultLocator);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), dataReleaseFirstResultLocator);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), pageContent);

            var searchResult = Convert.ToInt32(ParseStringToInt.ParseDataString(searchResultCount));
            var resultRows = InitWebDriver.GetDriver().FindElements(searchResultRows).Count;

            if (searchResult == resultRows)
            {
                return true;
            }
            else
                return false;
        }
        public void SaveDataAboutGame()
        {
            DataGame.Title = InitWebDriver.GetDriver().FindElement(titleFirstResultLocator).Text;
            DataGame.Release = InitWebDriver.GetDriver().FindElement(dataReleaseFirstResultLocator).Text;
            string priceBuf = InitWebDriver.GetDriver().FindElement(priceFirstResultLocator).Text;
            DataGame.Price = Convert.ToInt32(ParsePrice.ParseMethod(priceBuf));
        }
        public void FirstResultClick()
        {
            InitWebDriver.GetDriver().FindElement(titleFirstResultLocator).Click();
        }

    }
}
