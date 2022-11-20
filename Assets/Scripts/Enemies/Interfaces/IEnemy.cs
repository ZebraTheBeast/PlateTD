using System;
using PlateTD.Entities.Enums;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Enemies.Interfaces
{
    public interface IEnemy
    {
        public event Action<IEnemy> OnEnemyDeath;

        public void SetPath(GameObject path);
        public void ConsumeDamage(float damage, PlateType plateType);
        public void ConsumeDebuff(DebuffSO debuff);

        public UnityEngine.Object GetObjectToInstantiate();
    }
}