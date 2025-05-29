using System;

namespace BankApp
{
    // User sınıfı, kullanıcı adı ve şifreyi saklar (encapsulation)
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
