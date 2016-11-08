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
            this.ID = messageID;
            this.MessageBody = body;

            //Readonly values are passed in by inhertied classes in order to re-use code
            MESSAGE_TEXT_LENGTH = messageTextLength;
            SENDER_REGEX = senderRegex;
        }

        public abstract void processMessage();

        #region Getters and Setters

        public string ID
        {
            get { return _messageID; }
            set
            {
                //Regex to check ID validity e.g. S012345678
                if (!Regex.IsMatch(value, @"^[SET][0-9]{9}"))
                    throw new ArgumentException();

                _messageID = value;
            }
        }

        public string MessageBody
        {
            get { return _messageBody; }
            set { _messageBody = value; }
        }

        public string Sender
        {
            get { return _sender; }
            set
            {
                if (!Regex.IsMatch(value, SENDER_REGEX))
                    throw new ArgumentException();

                _sender = value;
            }
        }

        public string MessageText
        {
            get { return _messageText; }
            set
            {
                if (value.Length > MESSAGE_TEXT_LENGTH)
                    throw new ArgumentException();

                _messageText = value;
            }
        }

        #endregion
    }
}
