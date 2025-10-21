using Core.Data;
using UnityEngine;

namespace Gold
{
    public class GoldBootstrap: Bootstrap
    {
        [SerializeField] private PropertyKey _key;
        
        public override void Initialize()
        {
            PlayerData.Instance.RegisterData(_key, new GoldProperty(_key, 200));
        }
    }
}