using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class TransactionView : MonoBehaviour
    {
        [field: SerializeField] public InfoButtonView InfoButtonView { get; private set; }
        [SerializeField] private TMP_Text _nameLabel;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TMP_Text _buyLabel;

        private IShop _shop;
        private Transaction _transaction;
        private HashSet<PropertyKey> _properties = new();
        private Task _buyTask;

        public void Construct(IShop shop, Transaction transaction)
        {
            _shop = shop;
            _nameLabel.text = transaction.Name;
            _transaction = transaction;

            _buyButton.onClick.AddListener(OnBuyClicked);

            SubscribePropertiesUpdate(transaction);
            UpdateView();
        }

        private void SubscribePropertiesUpdate(Transaction transaction)
        {
            var properties = new HashSet<PropertyKey>();
            foreach (var unit in transaction.From)
            {
                properties.Add(unit.Product);
            }

            foreach (var key in properties)
            {
                PlayerData.Instance.GetProperty(key).ValueChanged += OnPropertyValueChanged;
            }
        }

        private void OnPropertyValueChanged(string obj)
        {
            if(_buyTask != null)
                return;
            
            UpdateView();
        }

        private void OnBuyClicked()
        {
            _shop.Buy(_transaction, default);
            BuyFlow();
        }

        private async Task BuyFlow()
        {
            _buyTask = _shop.Buy(_transaction, default);
            _buyButton.interactable = false;
            _buyLabel.text = "Processing...";
            await _buyTask;
            _buyTask = null;
            UpdateView();
        }

        private void UpdateView()
        {
            _buyLabel.text = "Buy";
            _buyButton.interactable = _shop.CanBuy(_transaction);
        }

        private void OnDestroy()
        {
            _buyButton.onClick.RemoveListener(OnBuyClicked);
            
            foreach (var key in _properties)
            {
                PlayerData.Instance.GetProperty(key).ValueChanged -= OnPropertyValueChanged;
            }
        }
    }
}