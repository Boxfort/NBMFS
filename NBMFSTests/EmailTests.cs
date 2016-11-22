using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using NBMFS;

namespace NBMFSTests
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void CreateValidEmail()
        {
            //arrange
            string messageID = "E012345678";
            string messageText = "Testing message body";
            string sender = "Email@example.com";
            string subject = "subject";

            try
            {
                Email email = new Email(messageID, sender, messageText, subject);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Exception thrown :" + ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateEmail_WithInvalidID()
        {
            //arrange
            string messageID = "Invalid";
            string messageText = "Testing message body";
            string sender = "Email@example.com";
            string subject = "subject";

            Email email = new Email(messageID, sender, messageText, subject);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateEmail_WithInvalidSender()
        {
            //arrange
            string messageID = "E012345678";
            string messageText = "Testing message body";
            string sender = "invalid";
            string subject = "subject";
        
            Email email = new Email(messageID, sender, messageText, subject);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateEmail_WithInvalidSubject()
        {
            //arrange
            string messageID = "E012345678";
            string messageText = "Testing message body";
            string sender = "example@example.com";
            string subject = "too long too long too long too long too long too long too long too long too long too long";

            Email email = new Email(messageID, sender, messageText, subject);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateEmail_WithInvalidMessageLength()
        {
            //arrange
            string messageID = "E012345678";
            string messageText = "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters."
                                + "This is an invalid message Email because it contains too many characters.";
            string sender = "example@example.com";
            string subject = "subject";

            Email email = new Email(messageID, sender, messageText, subject);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        public void Email_Removes_URLs()
        {
            //arrange
            string messageID = "E012345678";
            string messageText = "Message with a url www.example.com more text";
            string sender = "example@example.com";
            string subject = "subject";

            Email email = new Email(messageID, sender, messageText, subject);

            Assert.AreEqual("Message with a url <URL Quarantined> more text", email.ProcessedMessage);
        }

        [TestMethod]
        public void Email_Adds_URL_to_List()
        {
            //arrange
            string messageID = "E012345678";
            string messageText = "Message with a url www.example.com more text";
            string sender = "example@example.com";
            string subject = "subject";

            Email email = new Email(messageID, sender, messageText, subject);

            Assert.IsTrue(email.URLs.Contains("www.example.com"));
        }
    }
}
