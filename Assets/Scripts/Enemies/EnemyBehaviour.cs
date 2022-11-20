using System;
using PlateTD.Enemies.Interfaces;
using PlateTD.Entities.DTO;
using PlateTD.Entities.Enums;
using PlateTD.Extensions;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Enemies
{
    public class EnemyBehaviour : MonoBehaviour, IEnemy
    {
        private const float StopSpeed = 100f;

        [SerializeField] private Animator _animator;

        [SerializeField] private EnemyDTO _enemyData;

        private EnemyWalkingService _enemyWalkingService;
        private DebuffController _debuffController;

        public event Action<IEnemy> OnEnemyDeath;

        public void SetPath(GameObject path)
        {
            _enemyWalkingService.SetPath(path);
        }

        public void ConsumeDamage(float damage, PlateType plateType)
        {
            _enemyData.HealthPoint -= damage;
        }

        public void ConsumeDebuff(DebuffSO debuff)
        {
            _debuffController.AddDebuff(debuff.Type, debuff.ToDebuffDTO());
        }

        public UnityEngine.Object GetObjectToInstantiate()
        {
            return this;
        }

        private void Die()
        {
            GameEvents.InvokeAddGold(_enemyData.GoldAmount);
            Destroy(gameObject);
        }

        private void Awake()
        {
            _enemyWalkingService = new EnemyWalkingService(this.transform, _animator);
            _debuffController = new DebuffController(StopSpeed, 1);
        }

        private void Update()
        {
            _debuffController.Tick(Time.deltaTime, out float damage, out float speedSlow);

            ConsumeDamage(damage, PlateType.None);

            var movementSpeedSlow =  (StopSpeed - speedSlow) / StopSpeed;

            _enemyWalkingService.GoByPath(_enemyData.MovementSpeed * Time.deltaTime, movementSpeedSlow);

            if (_enemyData.HealthPoint <= 0)
            {
                Die();
            }
        }

        private void OnDestroy()
        {
            OnEnemyDeath?.Invoke(this);
        }
    }
}