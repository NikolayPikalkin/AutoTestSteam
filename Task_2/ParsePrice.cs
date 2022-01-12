using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public static class ParsePrice
    {
        public static string ParseMethod(string str)
        {
            string resultStr = null;
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i]=='\n')
                {
                    resultStr = null;
                }
                if (Convert.ToInt32(str[i]) >= 48 && Convert.ToInt32(str[i]) <= 57)
                {
                    resultStr += str[i];
                }
            }
            return resultStr;

        }
    }
}
