using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.Entities.DTO
{
    public class PlateInventoryViewDTO
    {
        public PlateType Type { get; set; }
        public Sprite Sprite { get; set; }
        public int Amount { get; set; }
    }
}