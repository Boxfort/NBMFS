using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS
{
    public class Email : Message
    {
        protected string _subject;
        private List<string> _URLs = new List<string>();

        protected const int SUBJECT_LENGTH = 20;
        private const string URL_REGEX = @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)";

        //Email regex obtained from http://emailregex.com/
        public Email(string messageID, string sender, string messageText, string subject) : base(messageID, sender, messageText, 1028, @"^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-z0-9](?:[A-z0-9-]*[A-z0-9])?\.)+[A-z0-9](?:[A-z0-9-]*[A-z0-9])?")
        {
            Subject = subject;
            processMessage();
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                if (value.Length > SUBJECT_LENGTH)
                    throw new ArgumentException("Subject must not contain more than "+SUBJECT_LENGTH+" characters.");

                _subject = value;
            }
        }

        protected override void processMessage()
        {
            foreach (Match m in Regex.Matches(_messageText, URL_REGEX))
            {
                _messageText = _messageText.Replace(m.Value, "<URL Quarantined>");
                _URLs.Add(m.Value);
            }

            Console.WriteLine(_messageText); 
        }
    }
}
