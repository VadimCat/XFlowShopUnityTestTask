using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    public interface IShop
    {
        Transaction[] Transactions { get; }
        bool CanBuy(Transaction transaction);
        Task Buy(Transaction transaction, CancellationToken cancellationToken);
    }
}