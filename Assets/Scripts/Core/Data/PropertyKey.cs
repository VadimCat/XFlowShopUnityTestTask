using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "PropertyKey", menuName = "Configs/Property Key")]
    public class PropertyKey: ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
    }
}