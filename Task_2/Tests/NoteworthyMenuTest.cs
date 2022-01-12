using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using Task_2.PageObjects;
using System.Threading;

namespace Task_2
{
    public class NoteworthyMenuTest : BaseTest
    {
        SteamHomePageObject steamHomePage = new SteamHomePageObject();
        TopSellersPageObject topSellersPage = new TopSellersPageObject();
        [Test]
        public void TestNoteworthyMenu()
        {
            //Главная страница открыта
            InitWebDriver.GetDriver().Navigate().GoToUrl(configModel.MainUrl);
            Assert.IsTrue(steamHomePage.IsHomePageOpen(), "HomePage is not open");

            ////Страница топ продаж открыта
            steamHomePage.CursorOnNoteworhty();
            steamHomePage.TopSellersClick();
            Assert.IsTrue(topSellersPage.IsTopSellersOpen(), " TopSellers is not open");
            
            ////CheckBoxSteamOs выбран
            topSellersPage.SteamOsClick();
            Assert.IsTrue(topSellersPage.IsSteamOsSelected(), "CheckboxSteam is not selected");

            //CheckBoxLanCoop выбран
            topSellersPage.PlayersFieldClick();
            topSellersPage.LanCoopClick();
            Assert.IsTrue(topSellersPage.IsLanCoopSelected(), "CheckboxLanCoop is not selected");

            //CheckBoxAction выбран
            topSellersPage.ActionClick();
            Assert.IsTrue(topSellersPage.IsActionSelected(), "CheckboxAction is not selected");
            
            //Количество найдных и фактическое значение равняется
            Assert.IsTrue(topSellersPage.IsSearchResultAndCountFound(), "Search result not equal result Rows");
            topSellersPage.SaveDataAboutGame();
            PageFirstGame gamePage = new PageFirstGame();

            topSellersPage.FirstResultClick();
            Assert.IsTrue(gamePage.IsGamePageOpen(), "Page game is not open");
            Assert.IsTrue(gamePage.IsDataСomparison(), "Dates don't match!");


        }
    }
}
