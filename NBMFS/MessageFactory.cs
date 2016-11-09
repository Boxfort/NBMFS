using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    class MessageFactory
    {
        public Message CreateMessage(string id, string sender, string messageText, string subject = "")
        {
            if (id.ToUpper().Contains("S"))
            {
                return new SMS(id.ToUpper(), sender, messageText);
            }
            else if (id.ToUpper().Contains("T"))
            {
                return new Tweet(id.ToUpper(), sender, messageText);
            }
            else if (id.ToUpper().Contains("E"))
            {
                if (subject.Length > 3 && subject.Trim().Substring(0, 3).ToUpper() == "SIR")
                {
                    return new SIR(id.ToUpper(), sender, messageText, subject);
                }
                else
                {
                    return new Email(id.ToUpper(), sender, messageText, subject);
                }
            }
            else
            {
                throw new ArgumentException("Invalid ID format.");
            }
        }
    }
}
