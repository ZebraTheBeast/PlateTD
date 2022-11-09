using System.Collections.Generic;
using PlateTD.Entities;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "PlateDataConfig", menuName = "PlateTD/PlateDataConfig", order = 0)]
    public class PlateDataConfig : ScriptableObject
    {
        public List<PlateSO> PlateSOList;
    }
}