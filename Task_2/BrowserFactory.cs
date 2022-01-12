using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    class BrowserFactory
    {
        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    InitWebDriver.ChromeDriver();
                    break;
                case "Edge":
                    InitWebDriver.EdgeDriver();
                    break;

            }
        }
    }
}
