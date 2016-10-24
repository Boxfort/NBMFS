using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    class Tweet : Message
    {
        Tweet(string messageID, String body) : base(messageID, body) { }

        public override void processMessage()
        {
            throw new NotImplementedException();
        }

        public override void setMessageText()
        {
            throw new NotImplementedException();
        }

        public override void setSender()
        {
            throw new NotImplementedException();
        }
    }
}
