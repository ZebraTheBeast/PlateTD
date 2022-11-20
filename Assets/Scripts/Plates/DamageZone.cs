using System.Collections.Generic;
using System.Linq;
using PlateTD.Enemies.Interfaces;
using UnityEngine;

namespace PlateTD.Plates
{
    public class DamageZone : MonoBehaviour
    {
        private List<IEnemy> _enemies;

        public bool IsEnemyExist => _enemies.Count > 0;

        public List<IEnemy> Enemies => _enemies;

        private void RemoveEnemyFromList(IEnemy enemy)
        {
            enemy.OnEnemyDeath -= RemoveEnemyFromList;
            _enemies.Remove(enemy);
        }

        private void AddEnemyToTheList(IEnemy enemy)
        {
            _enemies.Add(enemy);
            enemy.OnEnemyDeath += RemoveEnemyFromList;
        }

        private void Awake()
        {
            _enemies = new List<IEnemy>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
            {
                AddEnemyToTheList(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
            {
                RemoveEnemyFromList(enemy);
            }
        }
    }
}