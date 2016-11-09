using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS
{
    public class Tweet : Message
    {
        public Tweet(string messageID, string sender, string messageText) : base(messageID, sender, messageText, 128, @"^@[a-zA-Z0-9_]{1,15}")
        {
        }

        protected override void processMessage()
        {
            throw new NotImplementedException();
        }
    }
}
