using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS
{
    class Tweet : Message
    {
        private const int MESSAGE_TEXT_LENGTH = 128;

        public Tweet(string messageID, String body) : base(messageID, body) { }

        public override void processMessage()
        {
            throw new NotImplementedException();
        }

        public override void setMessageText(string messageText)
        {
            if (messageText.Length > MESSAGE_TEXT_LENGTH)
                throw new ArgumentException();

            _messageText = messageText;
        }

        public override void setSender(string sender)
        {
            //Regex to check sender validity e.g. S012345678
            Regex regex = new Regex(@"^@[a-zA-Z0-9_]{1,15}");

            if (!regex.IsMatch(sender))
                throw new ArgumentException();

            _messageID = sender;
        }
    }
}
