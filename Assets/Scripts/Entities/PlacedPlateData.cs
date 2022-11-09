using PlateTD.Entities.Enums;
using PlateTD.Plates;

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