using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace Task_2
{
    public sealed class InitWebDriver
    {
        private static IWebDriver driver;
        private InitWebDriver() { }
        public static IWebDriver ChromeDriver()
        {
            if (driver == null)
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();

            }
            return driver;
        }
        public static IWebDriver EdgeDriver()
        {
            if (driver == null)
            {
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                driver = new EdgeDriver();

            }
            return driver;
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void QuitDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
        
}
