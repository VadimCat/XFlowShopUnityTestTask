using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class TransactionPreviewView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        [SerializeField] private TransactionView _transactionView;
        private TransactionPreview _transactionPreview;

        public void Construct(IShop shop, Transaction transaction,
            TransactionPreview transactionPreview)
        {
            _transactionView.Construct(shop, transaction);
            _transactionPreview = transactionPreview;
            
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            _transactionPreview.Hide();
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(OnBackButtonClicked);
        }
    }
}