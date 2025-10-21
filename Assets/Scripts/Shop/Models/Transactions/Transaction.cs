using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "TransAction", menuName = "Configs/Shop/Transaction")]
    public class Transaction: ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public TransactionUnit[] From { get; private set; }
        [field: SerializeField] public TransactionUnit[] To { get; private set; }
    }
}