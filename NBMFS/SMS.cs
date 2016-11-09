using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    class SMS : Message
    {
        public SMS(string messageID, string sender, string messageText) : base(messageID, sender, messageText, 140, @"^\+[0-9]{11,13}")
        {
        }

        protected override void processMessage()
        {
            throw new NotImplementedException();
        }
    }
}
