using System.Collections.Generic;
using PlateTD.Plates;
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