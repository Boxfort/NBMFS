﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS
{
    [DataContract]
    [KnownType(typeof(SMS))]
    [KnownType(typeof(Tweet))]
    [KnownType(typeof(Email))]
    [KnownType(typeof(SIR))]
    public abstract class Message
    { 
        protected string _messageID;
        protected string _sender;
        protected string _messageText;

        protected const string TEXTWORDS_URL = @"../../textwords.csv";

        protected readonly int MESSAGE_TEXT_LENGTH;
        protected readonly string SENDER_REGEX;

        public Message(string messageID, string sender, string messageText, int messageTextLength, string senderRegex)
        {
            //Readonly values are passed in by inhertied classes in order to re-use code
            MESSAGE_TEXT_LENGTH = messageTextLength;
            SENDER_REGEX = senderRegex;

            ID = messageID;
            MessageText = messageText;
            Sender = sender;
        }

        protected abstract void ProcessMessage();

        #region Getters and Setters

        [DataMember]
        public string ID
        {
            get { return _messageID; }
            set
            {
                //Regex to check ID validity e.g. S012345678
                if (!Regex.IsMatch(value, @"^[SET][0-9]{9}"))
                    throw new ArgumentException("Message ID must be in the format 'S123456789'");

                _messageID = value;
            }
        }

        [DataMember]
        public string Sender
        {
            get { return _sender; }
            set
            {
                if (!Regex.IsMatch(value, SENDER_REGEX))
                {
                    string example;
                    if (this is SMS)
                    {
                        example = "+12345678910";
                    }
                    else if (this is Tweet)
                    {
                        example = "@TwitterUser";
                    }
                    else
                    {
                        example = "example@example.com";
                    }

                    throw new ArgumentException("Sender must be in the format '" + example + "'.");
                }

                _sender = value;
            }
        }

        [DataMember]
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                if (value.Length > MESSAGE_TEXT_LENGTH)
                    throw new ArgumentException("Message text must not contain more than "+MESSAGE_TEXT_LENGTH+" characters.");

                _messageText = value;
            }
        }

        #endregion
    }
}
