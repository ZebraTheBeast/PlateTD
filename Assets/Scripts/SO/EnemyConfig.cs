using System.Collections.Generic;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "PlateTD/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public List<EnemySO> EnemySOList;
    }
}