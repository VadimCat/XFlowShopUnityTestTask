using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Configs/Shop/Shop Config")]
    public class TransactionsConfig: ScriptableObject
    {
        [field: SerializeField] public Transaction[] Transactions { get; private set; }
    }
}