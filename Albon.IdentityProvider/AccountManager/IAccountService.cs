using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public interface IAccountService
    {
        public void Create(string emailAddress, string publicKey);

        public void Delete(string publicKey);

        public void ChangePublicKey(string email, string newPublicKey);

        public void ChangeEmailAddress(string email, string newEmail);

        public Account Search(string id);

        public IEnumerable<Account> Search();

        public bool CheckAccountExistence(string publicKey);
    }
}
