using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task_2.PageObjects
{
    class SteamHomePageObject
    {
        private readonly By aboutButton = By.XPath("//div[@class='supernav_container']//a[@class='menuitem' and contains(text(),'ABOUT')]");

        private readonly By uniqueElement = By.XPath("//div[@class='gutter_items']//span[@class='icon tags']");

        private readonly By menuLanguage = By.XPath("//div[@id='global_action_menu']//span[@id='language_pulldown']");

        private readonly By selectEngLanguage = By.XPath("//div[@class='popup_body popup_menu']//a[contains(text(),'English')]");

        private readonly By noteworthyString = By.XPath("//div[@id='noteworthy_tab']//span[@class='pulldown']//a[@class='pulldown_desktop']");

        private readonly By noteworthyMenu = By.XPath("//div[@id='noteworthy_flyout']//div[contains(@class,'popup_body popup_menu popup_menu_browse')]");

        private readonly By topSellersButton = By.XPath("//div[@id='noteworthy_flyout']//a[@class='popup_menu_item'][1]");

        public void SelectEnglishLanguage()
        {
            var menuLang = InitWebDriver.GetDriver().FindElement(menuLanguage);
            if (menuLang.Text != "language")
            {
                menuLang.Click();
                var selEngLang = InitWebDriver.GetDriver().FindElement(selectEngLanguage);
                selEngLang.Click();
            }
            
        }
        public bool IsHomePageOpen()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), noteworthyString);
            var unEl = InitWebDriver.GetDriver().FindElements(uniqueElement).Count > 0;

            return unEl;
        }
        public void AboutButtonClick()
        {

            WaitUntil.WaitElement(InitWebDriver.GetDriver(), aboutButton);
            InitWebDriver.GetDriver().FindElement(aboutButton).Click();
        }
        public void CursorOnNoteworhty()
        {
            Actions actions = new Actions(InitWebDriver.GetDriver());
            var noteworthy = InitWebDriver.GetDriver().FindElement(noteworthyString);
            actions.MoveToElement(noteworthy).Build().Perform();
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), noteworthyMenu);
            
        }
        public void TopSellersClick()
        {
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), noteworthyMenu);
            WaitUntil.WaitElement(InitWebDriver.GetDriver(), topSellersButton);
            var sellButton =  InitWebDriver.GetDriver().FindElement(topSellersButton);
            sellButton.Click();
        }
    }
}
