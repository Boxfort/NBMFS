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
    }
}
