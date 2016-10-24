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
        public Tweet(string messageID, string body) : base(messageID, body, 128, @"^@[a-zA-Z0-9_]{1,15}") { }

        public override void processMessage()
        {
            throw new NotImplementedException();
        }
    }
}
