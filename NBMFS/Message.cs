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

        private readonly int MESSAGE_TEXT_LENGTH;
        private readonly string SENDER_REGEX;

        public Message(string messageID, String body, int messageTextLength, string senderRegex)
        {
            setMessageID(messageID);
            setMessageBody(body);

            //Readonly values are passed in by inhertied classes in order to re-use code
            MESSAGE_TEXT_LENGTH = messageTextLength;
            SENDER_REGEX = senderRegex;
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
            if (!Regex.IsMatch(messageID, @"^[SET][0-9]{9}"))
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

        public void setSender(string sender)
        {
            if (!Regex.IsMatch(sender, SENDER_REGEX))
                throw new ArgumentException();

            _sender = sender;
        }

        public string getMessageText()
        {
            return _messageText;
        }

        public void setMessageText(string messageText)
        {
            if (messageText.Length > MESSAGE_TEXT_LENGTH)
                throw new ArgumentException();

            _messageText = messageText;
        }

        #endregion
    }
}
