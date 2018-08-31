using Microsoft.VisualStudio.TestTools.UnitTesting;
using busTimesTag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using busTimesTagTests.Fakes;
using busTimesTagTests;

namespace busTimesTag.Tests
{
    [TestClass()]
    public class TagAPITests
    {
        [TestMethod()]
        public void GetDataTest()
        {
            FakeRequestAPI fake = new FakeRequestAPI();
            fake.JsonToReturn = Resource1.Json;

            tagAPI target = new tagAPI(fake);
            List<LinesNearData> result = target.GetData("5.728029", "45.185658", "450");

            Assert.AreEqual("https://data.metromobilite.fr/api/linesNear/json?x=5.728029&y=45.185658&dist=450&details=true", fake.LastUrlReceived);
        }
    }
}