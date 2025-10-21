using Core.Data;
using UnityEngine;

namespace Vip
{
    public class VipBootstrap: Bootstrap
    {
        [SerializeField] private PropertyKey _vipStatusKey;
        
        public override void Initialize()
        {
            PlayerData.Instance.RegisterData(_vipStatusKey, new VipProperty(0));
        }
    }
}