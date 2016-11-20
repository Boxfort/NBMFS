using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NBMFS;

namespace NBMFSTests
{
    [TestClass]
    public class TweetTests
    {
        [TestMethod]
        public void CreateValidTweet()
        {
            //arrange
            string messageID = "T012345678";
            string messageText = "Testing message body";
            string sender = "@Sender";

            try
            {
                Tweet tweet = new Tweet(messageID, sender, messageText);
            }
            catch(ArgumentException ex)
            {
                Assert.Fail("Exception thrown :" + ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTweet_WithInvalidID()
        {
            //arrange
            string messageID = "Invalid";
            string body = "Testing message body";
            string sender = "@Sender";

            Tweet tweet = new Tweet(messageID, sender, body);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTweet_WithInvalidSender()
        {
            //arrange
            string messageID = "T012345678";
            string messageText = "Testing message body";
            string sender = "invalid";

            Tweet tweet = new Tweet(messageID, sender, messageText);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTweet_WithInvalidMessageLength()
        {
            //arrange
            string messageID = "T012345678";
            string messageText = "This is an invalid message tweet because it contains too many characters."
                                + "This is an invalid message tweet because it contains too many characters.";
            string sender = "@Sender";

            Tweet tweet = new Tweet(messageID, sender, messageText);

            //assert
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        public void Tweet_Expands_Text_Speak()
        {
            //arrange
            string messageID = "T012345678";
            string messageText = "Message with slang LOL more text";
            string sender = "@Sender";

            Tweet tweet = new Tweet(messageID, sender, messageText);

            Assert.AreEqual("Message with slang LOL <Laughing out loud> more text", tweet.ProcessedMessage);
        }

        [TestMethod]
        public void Tweet_Adds_Hashtags_to_List()
        {
            //arrange
            string messageID = "T012345678";
            string messageText = "Message with a #hashtag";
            string sender = "@Sender";

            Tweet tweet = new Tweet(messageID, sender, messageText);

            Assert.IsTrue(tweet.Hashtags.ContainsKey("#hashtag"));
        }

        [TestMethod]
        public void Tweet_Adds_Mentions_to_List()
        {
            //arrange
            string messageID = "T012345678";
            string messageText = "Message with a @mention";
            string sender = "@Sender";

            Tweet tweet = new Tweet(messageID, sender, messageText);

            Assert.IsTrue(tweet.Mentions.ContainsKey("@mention"));
        }
    }
}
