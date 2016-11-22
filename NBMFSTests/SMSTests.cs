using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using NBMFS;

namespace NBMFSTests
{
    [TestClass]
    public class SMSTests
    {
        [TestMethod]
        public void CreateValidSMS()
        {
            //arrange
            string messageID = "S012345678";
            string messageText = "Testing message body";
            string sender = "+44111111111";

            try
            {
                SMS tweet = new SMS(messageID, sender, messageText);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Exception thrown :" + ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSMS_WithInvalidID()
        {
            //arrange
            string messageID = "Invalid";
            string body = "Testing message body";
            string sender = "+44111111111";

            SMS tweet = new SMS(messageID, sender, body);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSMS_WithInvalidSender()
        {
            //arrange
            string messageID = "S012345678";
            string messageText = "Testing message body";
            string sender = "invalid";

            Tweet tweet = new Tweet(messageID, sender, messageText);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSMS_WithInvalidMessageLength()
        {
            //arrange
            string messageID = "S012345678";
            string messageText = "This is an invalid message tweet because it contains too many characters."
                                + "This is an invalid message tweet because it contains too many characters.";
            string sender = "+44111111111";

            SMS tweet = new SMS(messageID, sender, messageText);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        public void SMS_Expands_Text_Speak()
        {
            //arrange
            string messageID = "S012345678";
            string messageText = "Message with slang LOL more text";
            string sender = "+44111111111";

            SMS tweet = new SMS(messageID, sender, messageText);

            Assert.AreEqual("Message with slang LOL <Laughing out loud> more text", tweet.ProcessedMessage);
        }
    }
}
