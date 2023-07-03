using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCreationRequestManager
{
    public interface IAccountCreationRequestService
    {
        public void Create(string email, string publicKey);
        public bool CompleteAccountCreation(string publicKey, int activationCode);
    }
}
