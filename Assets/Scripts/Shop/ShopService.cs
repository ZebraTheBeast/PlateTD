using System;
using System.Collections.Generic;
using PlateTD.Plates;
using PlateTD.SO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlateTD.Shop
{
    public class ShopService : MonoBehaviour
    {
        [SerializeField] private ShopPanel _shopPanel;

        private int _goldAmount;
        private int _randomPanelCost;
        private List<PlateType> _availablePlateTypes;

        public event Action<PlateType> OnPlateBuy;

        public void Init(ShopConfig shopConfig)
        {
            _goldAmount = shopConfig.StartGoldAmount;
            _shopPanel.SetAmountGold(_goldAmount);
            _randomPanelCost = shopConfig.RandomPlateCost;
            _availablePlateTypes = shopConfig.AvailablePlates;
        }

        private void BuyPanelClickHandler()
        {
            if (_goldAmount >= _randomPanelCost)
            {
                _goldAmount -= _randomPanelCost;
                _shopPanel.SetAmountGold(_goldAmount);

                int randomPanelNumber = Random.Range(0, _availablePlateTypes.Count);
                OnPlateBuy?.Invoke(_availablePlateTypes[randomPanelNumber]);
            }
        }

        private void Start()
        {
            _shopPanel.SetBuyButtonClickCallback(BuyPanelClickHandler);
        }

    }
}
