using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2.PageObjects
{
    class PageItemDota2
    {
        private readonly By nameItem = By.XPath("//div[@class='item_desc_description']//h1");

        private readonly By nameGame = By.XPath("//div[@class='item_desc_game_info']//div[@id='largeiteminfo_game_name']");

        private readonly By nameRarity = By.XPath("//div[@class='item_desc_game_info']//div[@id='largeiteminfo_item_type']");

        private readonly By nameHero = By.XPath("//div[@class='item_desc_description']//div[@id='largeiteminfo_item_descriptors']//div[@class='descriptor'][1]");

        public bool IsCompareDataItem()
        {
            var item = InitWebDriver.GetDriver().FindElement(nameItem).Text;
            var game = InitWebDriver.GetDriver().FindElement(nameGame).Text;
            var rarity = InitWebDriver.GetDriver().FindElement(nameRarity).Text;
            var hero = InitWebDriver.GetDriver().FindElement(nameHero).Text;

            if (item == DataGameDota2.ItemName && game == DataGameDota2.TitleGame &&
                rarity.Contains(DataGameDota2.Rarity) && hero.Contains(DataGameDota2.Hero))
            {
                return true;
            }
            else
                return false;

        }


    }
}
