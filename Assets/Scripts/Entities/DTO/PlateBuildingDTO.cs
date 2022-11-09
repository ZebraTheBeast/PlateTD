using PlateTD.Plates;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Entities.DTO
{
    public class PlateBuildingDTO
    {
        // public string Name { get; set; }
        // public float Damage { get; set; }
        // public float ReloadSpeed { get; set; }
        // public DebuffSO Debuff { get; set; }
        // public PlateDTO NextLevelPlate { get; set; }
        // public int PlatesToLevelUp { get; set; }
        public PlateBehaviour Prefab { get; set; }
        public PlateDTO PlateData { get; set; }
        // public Sprite Sprite { get; set; }
        // public GameObject PlateRenderer { get; set; }
    }
}