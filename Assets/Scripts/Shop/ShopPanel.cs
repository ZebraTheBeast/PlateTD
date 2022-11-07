using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace PlateTD.Shop
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldAmountText;
        [SerializeField] private Button _buyButton;

        private Action _buyButtonClickCallback;

        public void SetBuyButtonClickCallback(Action callback)
        {
            _buyButtonClickCallback = callback;
        }

        public void SetAmountGold(int amount)
        {
            _goldAmountText.SetText(amount.ToString());
        }

        private void BuyButtonClickHandler()
        {
            _buyButtonClickCallback?.Invoke();
        }

        private void Start()
        {
            _buyButton.onClick.AddListener(BuyButtonClickHandler);
        }

        private void OnDestroy()
        {
            _buyButton.onClick.RemoveListener(BuyButtonClickHandler);
        }
    }
}
