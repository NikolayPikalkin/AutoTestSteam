using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public static class ParseStringToInt
    {
        public static string ParseDataString(By fElem)
        {
            string str;
            string resultStr = null;
            str = InitWebDriver.GetDriver().FindElement(fElem).Text;
            for (int i = 0; i < str.Length; i++)
            {
                if (Convert.ToInt32(str[i]) >= 48 && Convert.ToInt32(str[i]) <= 57)
                {
                    resultStr += str[i];
                }
            }
            return resultStr;

        }
    }
}
