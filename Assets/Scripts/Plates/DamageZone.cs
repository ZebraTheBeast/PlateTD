using System.Collections.Generic;
using System.Linq;
using PlateTD.Enemies.Interfaces;
using UnityEngine;

namespace PlateTD.Plates
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] private Vector3 _center;
        [SerializeField] private Vector3 _size;

        [SerializeField] private LayerMask _layerMask;

        private List<IEnemy> _enemies;

        public bool IsEnemyExist()
        {
            UpdateEnemies();
            return _enemies.Count > 0;
        }
        public List<IEnemy> Enemies => _enemies;

        private void Awake()
        {
            _enemies = new List<IEnemy>();
        }

        private void UpdateEnemies()
        {
            _enemies = new List<IEnemy>();
            var hits = Physics.BoxCastAll(_center + transform.position, _size / 2, Vector3.up, Quaternion.identity, 0, _layerMask);
            foreach (var hit in hits)
            {
                if (hit.collider.TryGetComponent<IEnemy>(out IEnemy enemy))
                {
                    _enemies.Add(enemy);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(_center + transform.position, _size);
        }

        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
        //     {
        //         _enemies.Add(enemy);
        //     }
        // }

        // private void OnTriggerExit(Collider other)
        // {
        //     if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
        //     {
        //         _enemies.Remove(enemy);
        //     }
        // }
    }
}