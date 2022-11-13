using System.Collections.Generic;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "PlateTD/WaveConfig")]
    public class WaveConfig : ScriptableObject
    {
        public List<WaveData> Waves;
    }
}