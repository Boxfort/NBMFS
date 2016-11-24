using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS
{
    [DataContract]
    public class SMS : Message
    {
        /// <summary>
        /// Short message service, text message
        /// </summary>
        /// <param name="messageID">Message's unique ID, must be in the form 'S123456789'</param>
        /// <param name="sender">Message's sender, must be an international phone number, e.g. +44111111111</param>
        /// <param name="messageText">Messages main body</param>
        /// <exception cref="System.ArgumentException"></exception>
        public SMS(string messageID, string sender, string messageText) : base(messageID, sender, messageText, 140, @"^\+[0-9]{11,13}")
        {
            ProcessMessage();
        }

        /// <summary>
        /// Expands all slang words detected in the message body and writes to processedMessage
        /// </summary>
        protected override void ProcessMessage()
        {
            StreamReader reader = new StreamReader(File.OpenRead(TEXTWORDS_URL));

            _processedMessage = _messageText;

            while (!reader.EndOfStream)
            {
                string[] words = reader.ReadLine().Split(',');
                string wordRegex = @"\b" + words[0] + @"\b";

                _processedMessage = Regex.Replace(_processedMessage, wordRegex, delegate(Match m)
                {
                    return m.Value + " <" + words[1] + ">";
                }, RegexOptions.IgnoreCase);
            }
        }
    }
}
