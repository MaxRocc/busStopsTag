using busTimesTag;
using busTimesTag.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busTimesTagTests.Fakes
{
    class FakeRequestAPI : IRequestAPI
    {
        public string JsonToReturn { get; set; }

        public string LastUrlReceived { get; private set; }

        public string DoRequest(string url)
        {
            LastUrlReceived = url;
            return JsonToReturn;
        }
    }
}
