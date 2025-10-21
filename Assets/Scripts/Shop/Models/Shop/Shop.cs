using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    public class Shop : IShop
    {
        private static Shop Instance;
        public Transaction[] Transactions => _config.Transactions;
        
        private readonly TransactionsConfig _config;

        private Shop(TransactionsConfig config)
        {
            _config = config;
        }

        public static Shop GetOrCreateInstance(TransactionsConfig transactionsConfig)
        {
            return Instance ??= new Shop(transactionsConfig);
        }

        public bool CanBuy(Transaction transaction)
        {
            bool canBuy = true;
            foreach (var from in transaction.From)
            {
                var property = PlayerData.Instance.GetProperty(from.Product);
                if (!(canBuy &= property.CanSpend(from.Amount)))
                    return false;
            }

            return canBuy;
        }

        public async Task Buy(Transaction transaction, CancellationToken cancellationToken)
        {
            if (!CanBuy(transaction))
                return;
            
            foreach (var from in transaction.From)
            {
                var property = PlayerData.Instance.GetProperty(from.Product);
                property.Spend(from.Amount);
            }

            foreach (var to in transaction.To)
            {
                var property = PlayerData.Instance.GetProperty(to.Product);
                property.Add(to.Amount);
            }
        }
    }
}