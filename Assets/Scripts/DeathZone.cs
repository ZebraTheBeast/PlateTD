using System.Collections;
using System.Collections.Generic;
using PlateTD.Enemies.Interfaces;
using PlateTD.Extensions;
using PlateTD.LevelHealth;
using UnityEngine;

namespace PlateTD.DeathZone
{
    public class DeathZone : MonoBehaviour
    {
        private LevelHealthService _levelHealthService;

        private void Start()
        {
            _levelHealthService = ServiceLocator.Resolve<LevelHealthService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
            {
                _levelHealthService.DealDamage(1);
                Destroy(other.gameObject);
            }
        }
    }
}
