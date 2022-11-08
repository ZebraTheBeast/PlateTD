using System.Collections.Generic;
using PlateTD.Enemies.Interfaces;
using UnityEngine;

namespace PlateTD.Plates
{
    public class DamageZone : MonoBehaviour
    {
        private List<IEnemy> _enemies;

        public bool IsEnemyExist => _enemies.Count > 0;
        public List<IEnemy> Enemies => _enemies;

        private void Awake()
        {
            _enemies = new List<IEnemy>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
            {
                _enemies.Add(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
            {
                _enemies.Remove(enemy);
            }
        }
    }
}