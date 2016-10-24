using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    class SMS : Message
    {
        public SMS(string messageID, string body, int messageTextLength, string senderRegex) : base(messageID, body, 140, @"^\+[0-9]{11,13}")
        {
        }

        public override void processMessage()
        {
            throw new NotImplementedException();
        }
    }
}
