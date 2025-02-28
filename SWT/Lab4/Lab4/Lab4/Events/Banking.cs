using static Lab4.Program;

namespace Lab4.Events
{
    public class Account
    {
        public delegate void BalanceChangedEventHandler(decimal newBalance);
        public event BalanceChangedEventHandler BalanceChanged;
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (balance != value)
                {
                    balance = value;
                    OnBalanceChanged(balance);
                }
            }
        }
        protected virtual void OnBalanceChanged(decimal newBalance)
        {
            BalanceChanged?.Invoke(newBalance);
        }
    }

}
