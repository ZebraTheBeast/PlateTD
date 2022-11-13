using PlateTD.Enemies;
using PlateTD.Enemies.Interfaces;
using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "PlateTD/EnemySO")]
    public class EnemySO : ScriptableObject
    {
        public EnemyType Type;
        public EnemyBehaviour GOPrefab;

        public IEnemy Prefab => GOPrefab;
    }
}