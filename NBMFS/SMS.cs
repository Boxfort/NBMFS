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
    class SMS : Message
    {
        public SMS(string messageID, string sender, string messageText) : base(messageID, sender, messageText, 140, @"^\+[0-9]{11,13}")
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

                _processedMessage = Regex.Replace(_messageText, wordRegex, delegate(Match m)
                {
                    return m.Value + " <" + words[1] + ">";
                }, RegexOptions.IgnoreCase);
            }
        }
    }
}
