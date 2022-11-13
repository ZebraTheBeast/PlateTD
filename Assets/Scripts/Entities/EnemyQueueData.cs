using System;
using System.Collections.Generic;
using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.Entities
{
    [Serializable]
    public class EnemeyQueueData
    {
        public EnemyType Type;
        public GameObject Path;
        public float Delay;
    }
}