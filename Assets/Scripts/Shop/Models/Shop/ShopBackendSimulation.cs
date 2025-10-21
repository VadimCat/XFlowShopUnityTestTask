using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    public class ShopBackendSimulation: IShop
    {
        private readonly IShop _shop;
        public Transaction[] Transactions => _shop.Transactions;

        public ShopBackendSimulation(IShop shop)
        {
            _shop = shop;
        }
        
        public bool CanBuy(Transaction transaction)
        {
            return _shop.CanBuy(transaction);
        }

        public async Task Buy(Transaction transaction, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            
            await _shop.Buy(transaction, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}