using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CoronaTrackApp.Tests
{
    [TestClass]
    public class PersonTests
    {
        //needs fixing
        [TestMethod]
        public void addRoute_WithSuccess()
        {

            var inputTestRoute = new Route("26/04/20", "19:00", "Ruppin - college");
            var inputTestPerson = new Person(1, "Ron", "Ramal", "13/08/1996", "0544345365", "ron@gmail.com", "natanya", "Zabutinski", 50, 2, 1);
            inputTestPerson.addRoute(inputTestRoute);

            var PersonRoute = inputTestPerson.PRoutes;
            Assert.AreEqual(inputTestRoute, PersonRoute[0]);

        }

        [TestMethod]
        public void updateInformation_WithSuccess()
        {

            var MyObj = new Person(1, "Ron", "Ramal", "13/08/1996", "0544345365", "ron@gmail.com", "natanya", "Zabutinski", 50, 2, 1);
            MyObj.updateInformation(1, "Ron", "Ramal", "13/08/1996", "0544345365", "NewEmail@gmail.com", "HAIFA", "german str", 10, 5, 1);
            var expected = new Person(1, "Ron", "Ramal", "13/08/1996", "0544345365", "NewEmail@gmail.com", "HAIFA", "german str", 10, 5, 1);

            Assert.AreEqual(expected, MyObj);

        }

    }
}
