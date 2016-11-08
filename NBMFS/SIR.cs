using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS
{
    public class SIR : Email
    {
        private Incident _incident;
        private const string SUBJECT_REGEX = @"^SIR [0-9]{2}\/[0-9]{2}\/[0-9]{2}";

        public SIR(string messageID, string sender, string messageText, string subject) : base(messageID, sender, messageText, subject)
        {
            Subject = subject;
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                if (!Regex.IsMatch(value, SUBJECT_REGEX))
                    throw new ArgumentException("Significant Incident Report subject must be in the format 'SIR dd/mm/yy'.");

                _sender = value;
            }
        }

        public Incident IncendentType
        {
            get { return _incident; }
            set { _incident = value; }
        }
    }
}
