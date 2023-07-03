using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCommunication
{
    public interface IClientCommunicationService
    {
        public void SendValidationCode(string email, string validationCode);

        public void NotifyAccountCreation(string email);

        public void AddEmailBlueprint(string emailSubject, string emailBody, CommunicationType emailType);

        public void DeleteEmailBlueprint(string id);

        public void DefineEmailBlueprintToUse(string id);

        public IEnumerable<EmailBlueprint> Search();
    }
}
