using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "DebuffSO", menuName = "PlateTD/DebuffSO", order = 0)]
    public class DebuffSO : ScriptableObject
    {
        public DebuffType Type;
        public float Damage;
        public float Time;
    }
}