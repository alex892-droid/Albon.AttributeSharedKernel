using Account;
using BasicLinkedObjectBase;
using ClientCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCreationRequestManager
{
    public class AccountCreationRequestService : IAccountCreationRequestService
    {
        public IObjectBaseService ObjectBaseService { get; set; }

        public IClientCommunicationService ClientCommunication { get; set; }

        public IAccountService AccountService { get; set; }

        public AccountCreationRequestService(IObjectBaseService objectBaseService, IClientCommunicationService clientCommunication, IAccountService accountService) 
        {
            ObjectBaseService = objectBaseService;
            ClientCommunication = clientCommunication;
            AccountService = accountService;
        }

        public void Create(string email, string publicKey)
        {
            AccountCreationRequest request = new AccountCreationRequest(email, publicKey);
            ClientCommunication.SendValidationCode(email, request.ActivationCode.ToString());
            ObjectBaseService.Add(request);
        }

        public bool CompleteAccountCreation(string publicKey, int activationCode)
        {
            var request = ObjectBaseService.Query<AccountCreationRequest>().Single(request => request.PublicKey == publicKey);

            if(activationCode == request.ActivationCode)
            {
                AccountService.Create(request.EmailAddress, request.PublicKey);
                ObjectBaseService.Delete(request);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
