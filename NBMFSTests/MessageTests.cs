using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NBMFS;

namespace NBMFSTests
{
    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void CreateTweet_WithValidID()
        {
            //arrange
            string messageID = "T012345678";
            string body = "Testing message body";

            try
            {
                Tweet tweet = new Tweet(messageID, body);
            }
            catch(ArgumentException ex)
            {
                Assert.Fail("Exception thrown :" + ex.Message);
            }

            //assert
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTweet_WithInvalidID()
        {
            //arrange
            string messageID = "Invalid";
            string body = "Testing message body";

            Tweet tweet = new Tweet(messageID, body);

            //assert
            Assert.Fail("No exception thrown");
        }
    }
}
