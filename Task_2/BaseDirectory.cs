using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public static class BaseDirectory
    {
        public static string BaseDirect;
        public static void FindDirectory()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            BaseDirect = domain.BaseDirectory;
            string delStr = "bin";
            int indexOfDelStr = BaseDirect.IndexOf(delStr);
            BaseDirect = BaseDirect.Remove(indexOfDelStr);
        }
    }
}
