using PlateTD.Enemies.Interfaces;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "PlateTD/EnemySO")]
    public class EnemySO : ScriptableObject
    {
        public float HP;
        public float MovementSpeed;
        public IEnemy Prefab;
    }
}