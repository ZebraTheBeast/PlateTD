using PlateTD.Plates;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Entities
{
    public class PlacedPlateData
    {
        public PlacedPlateData(PlateType plateType, GameObject gameObject)
        {
            Type = plateType;
            GameObject = gameObject;
        }

        public PlateType Type { get; set; }
        public GameObject GameObject { get; set; }
    }
}