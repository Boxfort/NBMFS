using Microsoft.VisualStudio.TestTools.UnitTesting;

using NBMFS;

namespace NBMFSTests
{
    [TestClass]
    public class MessageFactoryTests
    {
        [TestMethod]
        public void MessageFactory_CreateSMS()
        {
            string messageID = "S012345678";
            string messageText = "Testing message body";
            string sender = "+44111111111";

            Message returnMessage;

            MessageFactory mf = new MessageFactory();

            returnMessage = mf.CreateMessage(messageID, sender, messageText);

            Assert.IsTrue(returnMessage.GetType() == typeof(SMS));
        }

        [TestMethod]
        public void MessageFactory_CreateTweet()
        {
            string messageID = "T012345678";
            string messageText = "Testing message body";
            string sender = "@sender";

            Message returnMessage;

            MessageFactory mf = new MessageFactory();

            returnMessage = mf.CreateMessage(messageID, sender, messageText);

            Assert.IsTrue(returnMessage.GetType() == typeof(Tweet));
        }

        [TestMethod]
        public void MessageFactory_CreateEmail()
        {
            string messageID = "E012345678";
            string messageText = "Testing message body";
            string sender = "example@example.com";
            string subject = "subject";

            Message returnMessage;

            MessageFactory mf = new MessageFactory();

            returnMessage = mf.CreateMessage(messageID, sender, messageText, subject);

            Assert.IsTrue(returnMessage.GetType() == typeof(Email));
        }

        [TestMethod]
        public void MessageFactory_CreateSIR()
        {
            string messageID = "E012345678";
            string sender = "Example@example.com";
            string messageText = "Sort Code: 11-11-11 \r\n Nature of Incident: Theft";
            string subject = "SIR 01/02/16";

            Message returnMessage;

            MessageFactory mf = new MessageFactory();

            returnMessage = mf.CreateMessage(messageID, sender, messageText, subject);

            Assert.IsTrue(returnMessage.GetType() == typeof(SIR));
        }
    }
}
