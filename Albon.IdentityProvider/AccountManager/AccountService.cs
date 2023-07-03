using ClientCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicLinkedObjectBase;

namespace Account
{
    public class AccountService : IAccountService
    {
        public IObjectBaseService Database { get; set; }

        public IClientCommunicationService ClientCommunication { get; set; }

        public AccountService(IObjectBaseService database, IClientCommunicationService clientCommunication) 
        { 
            Database = database;
            ClientCommunication = clientCommunication;
        }

        public void Create(string email, string publicKey)
        {
            Account account = new Account(email, publicKey);
            Database.Add(account);

            ClientCommunication.NotifyAccountCreation(email);
        }

        public void Delete(string publicKey)
        {
            Database.Delete(Database.Query<Account>().Single(a => a.PublicKey == publicKey));
        }

        public void ChangePublicKey(string email, string newPublicKey)
        {
            var account = Database.Query<Account>().Single(account => account.EmailAddress == email);
            account.PublicKey = newPublicKey;
            Database.Update(account);
        }

        public void ChangeEmailAddress(string email, string newEmail)
        {
            var account = Database.Query<Account>().Single(account => account.EmailAddress == email);
            account.EmailAddress = newEmail;
            Database.Update(account);
        }

        public IEnumerable<Account> Search()
        {
            return Database.Query<Account>();
        }

        public Account Search(string publicKey)
        {
            return Database.Query<Account>().Single(x => x.PublicKey == publicKey);
        }

        public bool CheckAccountExistence(string publicKey)
        {
            return Database.Query<Account>().FirstOrDefault(x => x.PublicKey == publicKey) != null;
        }
    }
}
