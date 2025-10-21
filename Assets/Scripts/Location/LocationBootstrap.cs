using Core.Data;
using UnityEngine;

namespace Location
{
    public class LocationBootstrap: Bootstrap
    {
        [SerializeField] private PropertyKey _propertyKey;
        
        public override void Initialize()
        {
            PlayerData.Instance.RegisterData(_propertyKey, new LocationProperty("Home"));
        }
    }
}