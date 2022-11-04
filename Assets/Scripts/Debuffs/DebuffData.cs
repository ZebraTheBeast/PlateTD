using UnityEngine;

namespace PlateTD.Debuffs
{
    [CreateAssetMenu(fileName = "DebuffData", menuName = "PlateTD/DebuffData", order = 0)]
    public class DebuffData : ScriptableObject
    {
        public DebuffType Type;
        public float Damage;
        public float Time;
    }
}