using System;
using PlateTD.Entities.Enums;

namespace PlateTD.Entities.DTO
{
    [Serializable]
    public class PlateInventoryDTO
    {
        public PlateType Type;
        public int Amount;
    }
}