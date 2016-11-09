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
        private Dictionary<string, int> hashtags = new Dictionary<string, int>();
        private Dictionary<string, int> mentions = new Dictionary<string, int>();

        private const string HASHTAG_REGEX = @"^#[A-z0-9-_]{1-*}";

        public Tweet(string messageID, string sender, string messageText) : base(messageID, sender, messageText, 128, @"^@[A-z0-9_]{1,15}")
        {
            ProcessMessage();
        }

        protected override void ProcessMessage()
        {
            StreamReader reader = new StreamReader(File.OpenRead(TEXTWORDS_URL));

            while (!reader.EndOfStream)
            {
                string[] words = reader.ReadLine().Split(',');
                string wordRegex = @"\b" + words[0] + @"\b";

                _messageText = Regex.Replace(_messageText, wordRegex, delegate (Match m)
                {
                    return m.Value + " <" + words[1] + ">";
                }, RegexOptions.IgnoreCase);
            }

            foreach (Match m in Regex.Matches(_messageText, HASHTAG_REGEX))
            {
                if (hashtags.ContainsKey(m.Value))
                {
                    hashtags[m.Value]++;
                }
                else
                {
                    hashtags.Add(m.Value, 1);
                }
            }

            foreach (Match m in Regex.Matches(_messageText, SENDER_REGEX))
            {
                if (mentions.ContainsKey(m.Value))
                {
                    mentions[m.Value]++;
                }
                else
                {
                    mentions.Add(m.Value, 1);
                }
            }
        }
    }
}
