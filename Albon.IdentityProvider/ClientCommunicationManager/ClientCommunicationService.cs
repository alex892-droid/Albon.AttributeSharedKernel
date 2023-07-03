using BasicLinkedObjectBase;
using EmailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClientCommunication
{
    public class ClientCommunicationService : IClientCommunicationService
    {
        public IEmailSenderService EmailSenderService { get; set; }

        public IObjectBaseService ObjectBaseService { get; set; }

        public ClientCommunicationService(IEmailSenderService emailSenderService, IObjectBaseService objectBaseService) 
        {
            EmailSenderService = emailSenderService;
            ObjectBaseService = objectBaseService;
        }

        public void NotifyAccountCreation(string emailAddress)
        {
            EmailBlueprint emailCreation;
            try
            {
                emailCreation = ObjectBaseService.Query<EmailBlueprint>().Single(email => email.Use == true && email.EmailType == CommunicationType.AccountCreationNotification);
            }
            catch(Exception ex) 
            {
                throw new ApplicationException("No usable email blueprint found.", ex);
            }
            
            EmailSenderService.SendEmail(emailAddress, emailCreation.Subject, emailCreation.Body);
        }

        public void SendValidationCode(string emailAddress, string validationCode)
        {
            EmailBlueprint emailValidationCode;
            try
            {
                emailValidationCode = ObjectBaseService.Query<EmailBlueprint>().Single(email => email.Use == true && email.EmailType == CommunicationType.ValidationCode);
                emailValidationCode.Body = emailValidationCode.Body.Replace("{ValidationCode}", validationCode);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No usable email blueprint found.", ex);
            }

            EmailSenderService.SendEmail(emailAddress, emailValidationCode.Subject, emailValidationCode.Body);
        }

        public void AddEmailBlueprint(string emailSubject, string emailBody, CommunicationType emailType)
        {
            EmailBlueprint emailBlueprint = new EmailBlueprint(emailSubject, emailBody, emailType);
            ObjectBaseService.Add(emailBlueprint);
        }

        public void DeleteEmailBlueprint(string id)
        {
            ObjectBaseService.Delete<EmailBlueprint>(id);
        }

        public void DefineEmailBlueprintToUse(string id)
        {
            var emailBlueprint = ObjectBaseService.Query<EmailBlueprint>().Single(email => email.Id == id);
            emailBlueprint.Use = true;
            ObjectBaseService.Update(emailBlueprint);
        }

        public IEnumerable<EmailBlueprint> Search()
        {
            return ObjectBaseService.Query<EmailBlueprint>();
        }
    }
}
