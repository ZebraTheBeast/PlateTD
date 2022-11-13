using System.Collections.Generic;
using PlateTD.Enemies.Interfaces;
using PlateTD.Entities.DTO;
using PlateTD.Extensions;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Enemies
{
    public class EnemyBehaviour : MonoBehaviour, IEnemy
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private EnemyDTO _enemyData;

        private EnemyWalkingService _enemyWalkingService;

        public void SetPath(GameObject path)
        {
            _enemyWalkingService.SetPath(path);
        }

        public void ConsumeDamage(float damage)
        {
            Debug.Log($"get {damage} dmg");
            _enemyData.HealthPoint -= damage;
        }

        public void ConsumeDebuff(DebuffSO debuff)
        {
            Debug.Log($"get {debuff.Type} debuff");
        }

        private void Die()
        {
            GameEvents.InvokeAddGold(_enemyData.GoldAmount);
            Destroy(gameObject);
        }

        private void Awake()
        {
            _enemyWalkingService = new EnemyWalkingService(this.transform, _animator);
        }

        private void Update()
        {
            _enemyWalkingService.GoByPath(_enemyData.MovementSpeed * Time.deltaTime);

            if (_enemyData.HealthPoint <= 0)
            {
                Die();
            }
        }

        public Object GetObjectToInstantiate()
        {
            return this;
        }
    }
}