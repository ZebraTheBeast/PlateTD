using System.Collections.Generic;
using PlateTD.Entities;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "PlateTypePlateDataConfig", menuName = "PlateTD/PlateTypePlateData", order = 0)]
    public class PlateTypePlateDataConfig : ScriptableObject
    {
        public List<PlateTypePlateData> PlateTypePlateDatas;
    }
}