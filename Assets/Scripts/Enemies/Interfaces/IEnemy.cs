using System.Collections.Generic;
using PlateTD.Entities.DTO;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Enemies.Interfaces
{
    public interface IEnemy
    {
        public void SetPath(GameObject path);
        public void ConsumeDamage(float damage);
        public void ConsumeDebuff(DebuffSO debuff);

        public UnityEngine.Object GetObjectToInstantiate();
    }
}