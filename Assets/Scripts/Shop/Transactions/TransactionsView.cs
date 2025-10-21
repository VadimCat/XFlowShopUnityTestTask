using UnityEngine;

namespace Shop
{
    public class TransactionsView: MonoBehaviour
    {
        [SerializeField] private Transform _transactionsRoot;
        [SerializeField] private TransactionView _transactionPrefab;

        private IShop _shop;

        public void Construct(IShop shop, TransactionPreview transactionPreview)
        {
            _shop = shop;

            foreach (var transaction in _shop.Transactions)
            {
                TransactionView transactionView = Instantiate(_transactionPrefab, _transactionsRoot);
                transactionView.Construct(_shop, transaction);
                transactionView.InfoButtonView.Construct(transactionPreview, transaction);
            }
        }
    }
}