using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Task_2.ConfigData;
using Task_2.TestData;

namespace Task_2
{
    public class BaseTest
    {
        public static ConfigModel configModel;
        public static TestDataModel testModel;

        [OneTimeSetUp]
        protected void DoBeforeAllTheTests()
        {
            InitializeData();
        }
        private void InitializeData()
        {   
            BaseDirectory.FindDirectory();

            ConfigDataReader.ConfDataRead(out ConfigModel configModelObject);
            configModel = configModelObject;

            TestDataReader.TestDataRead(out TestDataModel testModelObject);
            testModel = testModelObject;
        }
        [SetUp]
        protected void DoBeforeEach()
        {
            BrowserFactory.InitBrowser(configModel.Browser);
            InitWebDriver.GetDriver().Manage().Window.Size = new Size(configModel.Width,configModel.Height);
            
        }
        [TearDown]
        protected void DoAfterEach()
        {
            InitWebDriver.QuitDriver();
        }
    }
}
