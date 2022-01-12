using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Task_2.PageObjects;

namespace Task_2
{
    public class MarketTest : BaseTest
    {
        SteamHomePageObject steamHomePage = new SteamHomePageObject();
        SteamHeaderForm steamHeaderForm = new SteamHeaderForm();
        MarketPageObject marketPage = new MarketPageObject();

        [Test]
        public void TestMarket()
        {
            InitWebDriver.GetDriver().Navigate().GoToUrl(configModel.MainUrl);
            WaitUntil.WaitDownloadUrl(InitWebDriver.GetDriver(), configModel.MainUrl);
            Assert.IsTrue(steamHomePage.IsHomePageOpen(), "HomePage is not open");

            steamHeaderForm.CursorOnComminity();
            steamHeaderForm.CommunityButtonClick();
            Assert.IsTrue(marketPage.IsMarketPageOpen(), "Market is not open");

            marketPage.ShowOptionsClick();
            Assert.IsTrue(marketPage.IsSearchFormOpen(), "Search advanced form is not open");

            marketPage.SelectedGameClick();
            marketPage.SelectedDota2();
            marketPage.SelectedHeroLifestealer();
            marketPage.SelectedImmortal();
            marketPage.InputTextSearch();
            marketPage.SearchButtonClick();
            Assert.IsTrue(marketPage.IsCheckingSelectedTags(), "Incorrect tags");

            Assert.IsTrue(marketPage.IsCheckingFirstFiveResults(), "No word <golden>");

            marketPage.DeleteTagDota2Golden();
            Assert.IsTrue(marketPage.IsResultsUpdated(), "Results have not been updated");

            marketPage.OpenFistResultClick();
            PageItemDota2 pageItemDota2 = new PageItemDota2();
            Assert.IsTrue(pageItemDota2.IsCompareDataItem(), "Data not equals");

        }
    }
}
