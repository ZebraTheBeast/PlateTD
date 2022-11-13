using System;
using System.Collections.Generic;
using System.Linq;
using PlateTD.Enemies.Interfaces;
using PlateTD.EnemyRepository.Interfaces;
using PlateTD.Entities.DTO;
using PlateTD.Entities.Enums;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.EnemyRepository
{
    public class EnemyRepository : IEnemyRepository
    {
        private List<EnemySO> _enemies;

        public EnemyRepository(List<EnemySO> enemies)
        {
            _enemies = enemies;
        }

        public IEnemy GetEnemyPrefabByType(EnemyType enemyType)
        {
            var enemySO = GetEnemyByType(enemyType);

            return enemySO.Prefab;
        }

        private EnemySO GetEnemyByType(EnemyType type)
        {
            var enemy = _enemies.FirstOrDefault(enemy => enemy.Type == type);

            if (enemy == null)
            {
                throw new Exception($"[{this.GetType().Name}][GetEnemyByType] Can not find enemy with type {type}");
            }

            return enemy;
        }
    }
}