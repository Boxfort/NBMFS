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
    public class SIR : Email
    {
        private Incident _incident;
        private string _sortCode;
        private const string SUBJECT_REGEX = @"^SIR [0-9]{2}\/[0-9]{2}\/[0-9]{2}";
        private const string SORTCODE_REGEX = @"^[0-9]{2}-[0-9]{2}-[0-9]{2}";

        /// <summary>
        /// Significant incident report
        /// </summary>
        /// <param name="messageID">Messages id, must be in the form 'E123456789'</param>
        /// <param name="sender">Messages sender, must be in the form 'example@example.com'</param>
        /// <param name="messageText">Message body, must be in the form 'Sort Code: 11-11-11 \n Nature Of Incident: IncidentName'</param>
        /// <param name="subject">Subject of the SIR, must be in the form 'SIR dd/mm/yy'</param>
        /// <exception cref="System.ArgumentException"></exception>
        public SIR(string messageID, string sender, string messageText, string subject) : base(messageID, sender, messageText, subject)
        {
            Subject = subject;
            ProcessMessage();
        }

        /// <summary>
        /// Ensures that the messagetext is in the correct format, stores the sortcode and nature of incident
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        protected override void ProcessMessage()
        {
            _processedMessage = _messageText.Trim();

            string[] lines = _processedMessage.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //Check that both lines are long enough, and that they conform to the correct format
            if (lines[0].Trim().Length < 8 || lines[0].Trim().Substring(0, 11).ToLower() != "sort code: ") 
                throw new ArgumentException("First line of SIR must be in the form 'Sort Code: 00-00-00'");

            if (lines[1].Trim().Length < 20 || lines[1].Trim().Substring(0, 20).ToLower() != "nature of incident: ")
                throw new ArgumentException("Second line of SIR must be the form 'Nature of Incident: IncidentName'");

            string sortCode = lines[0].Trim().Substring(11);
            string incidentString = lines[1].Trim().Substring(20);
            Incident incident;

            SortCode = sortCode;

            if (!Enum.TryParse<Incident>(incidentString, true, out incident))
                throw new ArgumentException("Invalid incident type.");

            Incident = incident;
        }

        #region getters and setters

        /// <exception cref="System.ArgumentException"></exception>
        [DataMember]
        public string SortCode
        {
            get { return _sortCode; }
            set
            {
                if (!Regex.IsMatch(value, SORTCODE_REGEX))
                    throw new ArgumentException("Sort code must be in the form '00-00-00'.");

                _sortCode = value;
            }
        }

        [DataMember]
        public Incident Incident
        {
            get { return _incident; }
            set { _incident = value; }
        }

        /// <exception cref="System.ArgumentException"></exception>
        public string Subject
        {
            get { return _subject; }
            set
            {
                if (!Regex.IsMatch(value, SUBJECT_REGEX))
                    throw new ArgumentException("Significant Incident Report subject must be in the format 'SIR dd/mm/yy'.");

                _subject = value;
            }
        }

        #endregion
    }
}
