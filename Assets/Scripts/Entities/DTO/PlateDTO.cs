using PlateTD.Plates;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Entities.DTO
{
    public class PlateDTO
    {
        public float Damage { get; set; }
        public float ReloadSpeed { get; set; }
        public DebuffSO Debuff { get; set; }
        public PlateDTO NextLevelPlate { get; set; }
        public int PlatesToLevelUp { get; set; }
        public GameObject PlateRenderer { get; set; }
    }
}