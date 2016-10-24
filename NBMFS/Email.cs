using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    class Email : Message
    {
        private string _subject;

        private const int SUBJECT_LENGTH = 20;

        //Email regex obtained from http://emailregex.com/
        public Email(string messageID, string body, string subject) : base(messageID, body, 1028, @"^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-z0-9](?:[A-z0-9-]*[A-z0-9])?\.)+[A-z0-9](?:[A-z0-9-]*[A-z0-9])?")
        {
            setSubject(_subject);
        }

        public override void processMessage()
        {
            throw new NotImplementedException();
        }

        public void setSubject(string subject)
        {
            if (subject.Length > SUBJECT_LENGTH)
                throw new ArgumentException();

            _subject = subject;
        }
    }
}
