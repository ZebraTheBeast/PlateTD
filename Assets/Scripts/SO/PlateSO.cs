using PlateTD.Entities.Enums;
using PlateTD.Plates;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "PlateSO", menuName = "PlateTD/PlateSO", order = 0)]
    public class PlateSO : ScriptableObject
    {
        public string Name;
        public PlateType PlateType;
        public float Damage;
        public float ReloadSpeed;
        public DebuffSO Debuff;
        public PlateSO NextLevelPlate;
        public int PlatesToLevelUp;
        public PlateBehaviour Prefab;
        public Sprite Sprite;
        public GameObject PlateRenderer;
    }
}