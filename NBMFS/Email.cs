using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    class Email : Message
    {
        //Email regex obtained from http://emailregex.com/
        public Email(string messageID, String body) : base(messageID, body, 1028, @"^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-z0-9](?:[A-z0-9-]*[A-z0-9])?\.)+[A-z0-9](?:[A-z0-9-]*[A-z0-9])?")
        {
        }

        public override void processMessage()
        {
            throw new NotImplementedException();
        }
    }
}
