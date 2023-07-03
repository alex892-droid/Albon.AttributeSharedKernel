using AttributeSharedKernel;

namespace Account
{
    public class Account
    {
        [DatabaseKey]
        public string Id { get; set; }

        public string EmailAddress { get; set; }

        public string PublicKey { get; set; }

        public Account() { }

        public Account(string email, string publicKey) 
        { 
            Id = Guid.NewGuid().ToString();
            EmailAddress = email;
            PublicKey = publicKey;
        }
    }
}
