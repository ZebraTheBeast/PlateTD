using UnityEngine;
using System.Collections.Generic;
using PlateTD.Entities;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "PlateTD/LevelsConfig", order = 0)]
    public class LevelsConfig : ScriptableObject
    {
        public List<LevelData> Levels;
    }
}