using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NBMFS;

namespace NBMFSTests
{
    [TestClass]
    public class SIRTests
    {
        [TestMethod]
        public void CreateValidSIR()
        {
            //Arrange
            string messageID = "E012345678";
            string sender = "Example@example.com";
            string messageText = "Sort Code: 11-11-11 \r\n Nature of Incident: Theft";
            string subject = "SIR 01/02/16";

            //Assert

            try
            {
                SIR IncidentReport = new SIR(messageID, sender, messageText, subject);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Exception thrown :" + ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSIR_WithInvalidSubject()
        {
            //Arrange
            string messageID = "E012345678";
            string sender = "Example@example.com";
            string messageText = "Sort Code: 11-11-11 \r\n Nature of Incident: Theft";
            string subject = "invalid";

            //Assert

            SIR IncidentReport = new SIR(messageID, sender, messageText, subject);

            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSIR_WithInvalidMessageText()
        {
            //Arrange
            string messageID = "E012345678";
            string sender = "Example@example.com";
            string messageText = "invalid";
            string subject = "SIR 01/02/16";

            //Assert

            SIR IncidentReport = new SIR(messageID, sender, messageText, subject);

            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSIR_WithInvalidSortCode()
        {
            //Arrange
            string messageID = "E012345678";
            string sender = "Example@example.com";
            string messageText = "Sort Code: invalid \r\n Nature of Incident: Theft";
            string subject = "SIR 01/02/16";

            //Assert

            SIR IncidentReport = new SIR(messageID, sender, messageText, subject);

            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSIR_WithInvalidIncident()
        {
            //Arrange
            string messageID = "E012345678";
            string sender = "Example@example.com";
            string messageText = "Sort Code: 11-11-11 \r\n Nature of Incident: Invalid";
            string subject = "SIR 01/02/16";

            //Assert

            SIR IncidentReport = new SIR(messageID, sender, messageText, subject);

            Assert.Fail("No exception thrown");
        }

    }
}
