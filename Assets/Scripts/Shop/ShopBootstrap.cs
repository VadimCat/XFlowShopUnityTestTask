using System.Collections;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class ShopBootstrap : Bootstrap
    {
        [SerializeField] private TransactionsConfig _transactionsConfig;
        [SerializeField] private CheatsConfig _cheatsConfig;

        public override void Initialize()
        {
            CoroutineRunner.Instance.StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            yield return SceneManager.LoadSceneAsync("Shop", LoadSceneMode.Single);
            var shop = Shop.GetOrCreateInstance(_transactionsConfig);
            var backendShop = new ShopBackendSimulation(shop);
            var transactionsView = FindObjectOfType<TransactionsView>();
            var propertiesView = FindObjectOfType<PropertiesView>();

            var transactionPreview = new TransactionPreview(backendShop,
                transactionsView.transform, propertiesView.transform);
            
            transactionsView.Construct(backendShop, transactionPreview);
            propertiesView.Construct(shop, _cheatsConfig);
        }
    }
}