using System.Collections;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class TransactionPreview
    {
        private readonly Transform[] _viewsToHide;
        private readonly IShop _shop;

        public TransactionPreview(IShop shop, params Transform[] viewsToHide)
        {
            _viewsToHide = viewsToHide;
            _shop = shop;
        }

        public void Show(Transaction transaction)
        {
            CoroutineRunner.Instance.StartCoroutine(Load(transaction));
        }

        public void Hide()
        {
            foreach (var view in _viewsToHide)
            {
                view.gameObject.SetActive(true);
            }

            SceneManager.UnloadScene("TransactionPreview");
        }

        private IEnumerator Load(Transaction transaction)
        {
            foreach (var view in _viewsToHide)
            {
                view.gameObject.SetActive(false);
            }

            yield return SceneManager.LoadSceneAsync("TransactionPreview",
                LoadSceneMode.Additive);

            var transactionPreviewView = Object.FindObjectOfType<TransactionPreviewView>();
            transactionPreviewView.Construct(_shop, transaction, this);
        }
    }
}