using PlateTD.Plates;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Entities
{
    public class PlacedPlateData
    {
        public PlacedPlateData(PlateType plateType, PlateBehaviour plateBehaviour)
        {
            Type = plateType;
            PlateBehaviour = plateBehaviour;
        }

        public PlateType Type { get; set; }
        public PlateBehaviour PlateBehaviour { get; set; }
    }
}