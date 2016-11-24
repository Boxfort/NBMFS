using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS
{
    [DataContract]
    public class Email : Message
    {
        protected string _subject;
        private List<string> _URLs = new List<string>();

        protected const int SUBJECT_LENGTH = 20;
        private const string URL_REGEX = @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)";

        //Email regex obtained from http://emailregex.com/
        /// <summary>
        /// Message of type email
        /// </summary>
        /// <param name="messageID">Message's unique ID, should be in the form 'E123456789'</param>
        /// <param name="sender">Message's sender, should be in the form 'example@example.com'</param>
        /// <param name="messageText">Message's main body of text</param>
        /// <param name="subject">subject of the email</param>
        /// <exception cref="System.ArgumentException"></exception>
        public Email(string messageID, string sender, string messageText, string subject) : base(messageID, sender, messageText, 1028, @"^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-z0-9](?:[A-z0-9-]*[A-z0-9])?\.)+[A-z0-9](?:[A-z0-9-]*[A-z0-9])?")
        {
            Subject = subject;
            ProcessMessage();
        }

        /// <exception cref="System.ArgumentException"></exception>
        [DataMember]
        public string Subject
        {
            get { return _subject; }
            set
            {
                if (value.Length > SUBJECT_LENGTH)
                    throw new ArgumentException("Subject must not contain more than " + SUBJECT_LENGTH + " characters.");

                _subject = value;
            }
        }

        /// <summary>
        /// replaces all URLs in messageText with URL QUARANTINED and stores the new messagetext in processedmessage
        /// </summary>
        protected override void ProcessMessage()
        {
            _processedMessage = _messageText;

            foreach (Match m in Regex.Matches(_messageText, URL_REGEX))
            {
                _processedMessage = _processedMessage.Replace(m.Value, "<URL Quarantined>");
                _URLs.Add(m.Value);
            }
        }

        /// <exception cref="System.ArgumentException"></exception>
        [DataMember]
        public List<string> URLs
        {
            get { return _URLs; }
            set { _URLs = value; }
        }
    }
}
