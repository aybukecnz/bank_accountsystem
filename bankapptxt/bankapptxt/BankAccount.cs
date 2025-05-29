namespace BankApp
{
    // BankAccount sınıfı, User sınıfından kalıtım alır (inheritance)
    public class BankAccount : User
    {
        public decimal Balance { get; private set; }

        public BankAccount(string username, string password, decimal balance = 0)
            : base(username, password)
        {
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > Balance)
                return false;

            Balance -= amount;
            return true;
        }
    }
}
