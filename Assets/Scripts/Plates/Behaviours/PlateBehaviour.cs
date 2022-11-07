using System.Collections.Generic;
using PlateTD.Enemies.Interfaces;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Plates
{
    public class PlateBehaviour : MonoBehaviour
    {
        [SerializeField] protected PlateData _plateData;
        protected IPlateAffector _plateAffector;
        private List<IEnemy> _enemies;

        private float _timer;

        protected virtual void Awake()
        {
            _enemies = new List<IEnemy>();
            _timer = _plateData.ReloadSpeed;
        }

        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else if (_enemies.Count > 0)
            {
                foreach (var enemy in _enemies)
                {
                    _plateAffector.AffectEnemy(enemy);
                }
                _timer = _plateData.ReloadSpeed;
            }
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