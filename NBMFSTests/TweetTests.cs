using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NBMFS;

namespace NBMFSTests
{
    [TestClass]
    public class TweetTests
    {
        [TestMethod]
        public void CreateTweet_WithValidID()
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
    }
}
