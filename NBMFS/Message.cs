using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS
{
    public abstract class Message
    {
        protected string _messageID;
        protected string _messageBody;
        protected string _sender;
        protected string _messageText;

        public Message(string messageID, String body)
        {
            setMessageID(messageID);
            setMessageBody(body);
        }

        public abstract void processMessage();

        #region Getters and Setters

        public string getMessageID()
        {
            return _messageID;
        }

        public void setMessageID(string messageID)
        {
            //Regex to check ID validity e.g. S012345678
            Regex regex = new Regex(@"^[SET][0-9]{9}");

            if (!regex.IsMatch(messageID))
                throw new ArgumentException();

            _messageID = messageID;
        }

        public string getMessageBody()
        {
            return _messageBody;
        }

        public void setMessageBody(string body)
        {
            _messageBody = body;
        }

        public string getSender()
        {
            return _sender;
        }

        //Senders for each class of message will be of a different format.
        public abstract void setSender(string sender);

        public string getMessageText()
        {
            return _messageText;
        }

        //Message texts for each class of message vary in length
        public abstract void setMessageText(string messageText);

        #endregion
    }
}
