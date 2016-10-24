using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    class Email : Message
    {
        private const int MESSAGE_TEXT_LENGTH = 128;

        public Email(string messageID, String body) : base(messageID, body) { }

        public override void processMessage()
        {
            throw new NotImplementedException();
        }

        public override void setMessageText(string messageText)
        {
            throw new NotImplementedException();
        }

        public override void setSender(string sender)
        {
            throw new NotImplementedException();
        }
    }
}
