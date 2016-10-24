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
    }
}
