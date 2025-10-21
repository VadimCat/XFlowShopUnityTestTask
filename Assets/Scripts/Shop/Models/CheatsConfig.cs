using System.Linq;
using Core.Data;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "CheatsConfig", menuName = "Configs/Shop/Cheats Config")]
    public class CheatsConfig : ScriptableObject
    {
        [SerializeField] private Transaction[] Transactions;

        public Transaction GetCheatByPropertyKey(PropertyKey key)
        {
            foreach (var transaction in Transactions)
            {
                if (transaction.To.First().Product == key)
                {
                    return transaction;
                }
            }

            Debug.LogWarning(
                $"Cheat with key {key} not found. Check CheatsConfig. Null will be returned.");
            return null;
        }
    }
}