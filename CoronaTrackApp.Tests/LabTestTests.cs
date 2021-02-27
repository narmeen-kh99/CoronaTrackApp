using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoronaTrackApp.Tests
{
    [TestClass]
    public class LabTestTests
    {

        [TestMethod]
        public void ReplaceParams_WithSuccess()
        {
            var inputTest = new LabTest(1, 1, 123, "01/04/20", true);

            var myObj = new LabTest(1,1, 555, "01/04/20", false);
            myObj.replaceParams(inputTest);

            var expected = new LabTest(1, 1, 123, "01/04/20", true);

            Assert.AreEqual(expected, myObj);
        }
 
    }
}
