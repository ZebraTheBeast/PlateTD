using System.Collections.Generic;
using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "PlateTD/ShopConfig", order = 0)]
    public class ShopConfig : ScriptableObject
    {
        public int StartGoldAmount;
        public int RandomPlateCost;
        public List<PlateType> AvailablePlates;
    }
}