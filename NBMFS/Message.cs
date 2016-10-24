﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    public abstract class Message
    {
        private string _messageID;
        private string _messageBody;
        private string _sender;
        private string _messageText;

        Message(string messageID, String body)
        {
            setMessageID(messageID);
            setMessageBody(body);
        }

        #region Getters and Setters

        public string getMessageID()
        {
            return _messageID;
        }

        public void setMessageID(string messageID)
        {
            //Regex to check ID validity. [SET][0-9]{9}
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
        public abstract void setSender();

        public string getMessageText()
        {
            return _messageText;
        }

        //Message texts for each class of message vary in length
        public abstract void setMessageText();

        #endregion
    }
}
