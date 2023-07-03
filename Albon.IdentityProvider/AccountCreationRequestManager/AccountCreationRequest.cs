using AttributeSharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCreationRequestManager
{
    public class AccountCreationRequest
    {
        [DatabaseKey]
        public string Id { get; set; }

        public string EmailAddress { get; set; }

        public string PublicKey { get; set; }

        public int ActivationCode { get; set; }

        public AccountCreationRequest() { }

        public AccountCreationRequest(string email, string publicKey)
        {
            Id = Guid.NewGuid().ToString();
            EmailAddress = email;
            PublicKey = publicKey;
            ActivationCode = new Random().Next(100000, 999999);
        }
    }
}
