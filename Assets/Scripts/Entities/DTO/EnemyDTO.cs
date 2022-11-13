using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlateTD.Entities.DTO
{
    [Serializable]
    public class EnemyDTO
    {
        public float HealthPoint;// { get; set; }
        public float MovementSpeed;// { get; set; }
        public int GoldAmount;
        // public List<DebuffDTO> AppliedDebuffs { get; set; }
    }
}