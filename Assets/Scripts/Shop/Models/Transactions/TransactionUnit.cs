using Core.Data;
using UnityEngine;

namespace Shop
{
    [System.Serializable]
    public class TransactionUnit
    {
        [field: SerializeField] public PropertyKey Product { get; private set; }
        [field: SerializeField] public string Amount { get; private set; }
    }
}