using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Net;
using System.IO;

namespace busTimesTag
{
    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Hello Max");
            tagAPI.GetData("5.728029", "45.185658", "500");
        }
    }
}