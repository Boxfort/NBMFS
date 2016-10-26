using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS
{
    public class SIR : Email
    {
        private Incident _incident;

        public SIR(string messageID, string body, string subject) : base(messageID, body, subject) { }

        public override void processMessage()
        {
            throw new NotImplementedException();
        }

        public Incident getIncident()
        {
            return _incident;
        }

        public void setIncident(Incident incident)
        {
            _incident = incident;
        }
    }
}
