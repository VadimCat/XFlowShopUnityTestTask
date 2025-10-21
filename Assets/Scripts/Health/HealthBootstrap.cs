using Core.Data;
using UnityEngine;

namespace Health
{
    public class HealthBootstrap: Bootstrap
    {
        [SerializeField] private PropertyKey _key;
        
        public override void Initialize()
        {
            PlayerData.Instance.RegisterData(_key, new HealthProperty(100));
        }
    }
}