using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_2
{
    public class ConfigModel
    {
        public string MainUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int WaitTime { get; set; }
        public string Browser { get; set; }
    }

}


