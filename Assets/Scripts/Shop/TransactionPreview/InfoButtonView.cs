using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class InfoButtonView: MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private TransactionPreview _transactionPreview;
        private Transaction _transaction;

        public void Construct(TransactionPreview transactionPreview,Transaction transaction)
        {
            _transactionPreview = transactionPreview;
            _transaction = transaction;
            
            _button.onClick.AddListener(ButtonClicked);
        }

        private void ButtonClicked()
        {
            _transactionPreview.Show(_transaction);
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ButtonClicked);
        }
    }
}