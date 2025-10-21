using Core.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class PropertyView: MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        
        private Property _property;
        private Shop _shop;
        private Transaction _cheatTransaction;
        private PropertyKey _propertyKey;

        public void Construct(Shop shop, PropertyKey propertyKey, Property property, Transaction cheatTransaction)
        {
            _shop = shop;
            _property = property;
            _cheatTransaction = cheatTransaction;
            _propertyKey = propertyKey;
            
            _property.ValueChanged += OnValueChanged;
            _button.onClick.AddListener(UseCheatTransaction);
            
            OnValueChanged(_property.TextValue);
        }

        private void OnValueChanged(string value)
        {
            _text.text = $"{_propertyKey.Name}: {value}";
        }

        private void UseCheatTransaction()
        {
            _shop.Buy(_cheatTransaction, default);
        }
        
        private void OnDestroy()
        {
            _property.ValueChanged -= OnValueChanged;
            _button.onClick.RemoveListener(UseCheatTransaction);
        }
    }
}