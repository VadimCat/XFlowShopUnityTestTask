using UnityEngine;

namespace Shop
{
    public class PropertiesView : MonoBehaviour
    {
        [SerializeField] private Transform _propertiesContainer;
        [SerializeField] private PropertyView _propertyViewPrefab;

        public void Construct(Shop shop, CheatsConfig cheatsConfig)
        {
            foreach (var propertyKey in PlayerData.Instance.AvailableProperties)
            {
                var property = PlayerData.Instance.GetProperty(propertyKey);

                var propertyView = Instantiate(_propertyViewPrefab, _propertiesContainer);
                propertyView.Construct(shop, propertyKey, property,
                    cheatsConfig.GetCheatByPropertyKey(propertyKey));
            }
        }
    }
}