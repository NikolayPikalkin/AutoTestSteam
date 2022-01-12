using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using Task_2.PageObjects;
using System.Threading;

namespace Task_2
{
    public class AboutOnlineTest : BaseTest
    {
       
        SteamHomePageObject steamHomePage = new SteamHomePageObject();
        AboutPageObject aboutPage = new AboutPageObject();
        
        [Test]
        public void TestAboutPage()
        {
            InitWebDriver.GetDriver().Navigate().GoToUrl(configModel.MainUrl);
            WaitUntil.WaitDownloadUrl(InitWebDriver.GetDriver(), configModel.MainUrl);
            Assert.IsTrue(steamHomePage.IsHomePageOpen(), "HomePage is not open");

            steamHomePage.SelectEnglishLanguage();
            steamHomePage.AboutButtonClick();
            bool trueAboutPage = aboutPage.IsAboutPageOpen();
            Assert.IsTrue(trueAboutPage, "AboutPage is not open");

            Assert.IsTrue(aboutPage.IsComparePlayers(), "Player ñomparison error");

            aboutPage.GoToHome();
            Assert.IsTrue(steamHomePage.IsHomePageOpen(), "HomePage is not open");
        }

    }
}
