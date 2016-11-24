using Newtonsoft.Json;
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
    public class Tweet : Message
    {
        private Dictionary<string, int> _hashtags = new Dictionary<string, int>();
        private Dictionary<string, int> _mentions = new Dictionary<string, int>();

        private const string HASHTAG_REGEX = @"#[A-z0-9-_]+";
        private const string MENTION_REGEX = @"@[A-z0-9_]{1,15}";

        /// <summary>
        /// Tweet message
        /// </summary>
        /// <param name="messageID">Message's unique ID, must be in the form 'T123456789'</param>
        /// <param name="sender">Message's sender, must be in the form '@username'</param>
        /// <param name="messageText">Tweets main message body</param>
        /// <exception cref="System.ArgumentException"></exception>
        public Tweet(string messageID, string sender, string messageText) : base(messageID, sender, messageText, 128, @"^@[A-z0-9_]{1,15}")
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

                _processedMessage = Regex.Replace(_processedMessage, @wordRegex, delegate (Match m)
                {
                    return m.Value + " <" + words[1] + ">";
                }, RegexOptions.IgnoreCase);
            }

            foreach (Match m in Regex.Matches(_messageText, HASHTAG_REGEX))
            {
                if (_hashtags.ContainsKey(m.Value))
                {
                    _hashtags[m.Value]++;
                }
                else
                {
                    _hashtags.Add(m.Value, 1);
                }
            }

            foreach (Match m in Regex.Matches(_messageText, MENTION_REGEX))
            {
                if (_mentions.ContainsKey(m.Value))
                {
                    _mentions[m.Value]++;
                }
                else
                {
                    _mentions.Add(m.Value, 1);
                }
            }
        }

        public Dictionary<string, int> Mentions
        {
            get { return _mentions; }
        }

        public Dictionary<string, int> Hashtags
        {
            get { return _hashtags; }
        }

    }
}
