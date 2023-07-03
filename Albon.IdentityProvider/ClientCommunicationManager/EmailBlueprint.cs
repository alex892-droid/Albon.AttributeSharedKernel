using AttributeSharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCommunication
{
    public class EmailBlueprint
    {
        [DatabaseKey]
        public string Id { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public CommunicationType EmailType { get; set; }

        public bool Use { get; set; }

        public EmailBlueprint(string messageSubject, string messageBody, CommunicationType emailType) 
        {
            this.Id = Guid.NewGuid().ToString();
            this.Subject = messageSubject;
            this.Body = messageBody;
            this.EmailType = emailType;
            this.Use = false;
        }
    }
}
