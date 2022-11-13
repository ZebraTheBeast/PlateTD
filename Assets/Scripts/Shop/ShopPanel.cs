using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PlateTD.Extensions;

namespace PlateTD.Shop
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldAmountText;
        [SerializeField] private Button _buyButton;

        private ShopService _shopService;

        private void SetAmountGold(int amount)
        {
            _goldAmountText.SetText(amount.ToString());
        }

        private void BuyButtonClickHandler()
        {
            _shopService.BuyRandomPanel();
        }

        private void Start()
        {
            _shopService = ServiceLocator.Resolve<ShopService>();
            _shopService.OnGoldAmountChanged += SetAmountGold;

            SetAmountGold(_shopService.GoldAmount);

            _buyButton.onClick.AddListener(BuyButtonClickHandler);
        }

        private void OnDestroy()
        {
            _buyButton.onClick.RemoveListener(BuyButtonClickHandler);

            _shopService.OnGoldAmountChanged -= SetAmountGold;
        }
    }
}
