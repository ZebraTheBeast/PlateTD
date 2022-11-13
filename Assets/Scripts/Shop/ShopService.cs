using System;
using System.Collections.Generic;
using PlateTD.Entities.Enums;
using PlateTD.SO;
using Random = UnityEngine.Random;

namespace PlateTD.Shop
{
    public class ShopService
    {
        private int _goldAmount;
        private int _randomPanelCost;
        private List<PlateType> _availablePlateTypes;

        public event Action<PlateType> OnPlateBuy;
        public event Action<int> OnGoldAmountChanged;

        public int GoldAmount => _goldAmount;

        public ShopService(ShopConfig shopConfig)
        {
            _goldAmount = shopConfig.StartGoldAmount;
            _randomPanelCost = shopConfig.RandomPlateCost;
            _availablePlateTypes = shopConfig.AvailablePlates;
        }

        public void AddGold(int goldAmount)
        {
            _goldAmount += goldAmount;
            OnGoldAmountChanged?.Invoke(_goldAmount);
        }

        public void BuyRandomPanel()
        {
            if (_goldAmount >= _randomPanelCost)
            {
                _goldAmount -= _randomPanelCost;
                OnGoldAmountChanged?.Invoke(_goldAmount);

                int randomPanelNumber = Random.Range(0, _availablePlateTypes.Count);
                OnPlateBuy?.Invoke(_availablePlateTypes[randomPanelNumber]);
            }
        }
    }
}
