using System;
namespace PlateTD.LevelHealth
{
    public class LevelHealthService
    {
        private int _healthPoints;

        public bool IsAlive => _healthPoints > 0;

        public event Action OnHealthEnd;
        public event Action<int> OnHealthChanged;

        public void SetHealth(int healthPoints)
        {
            _healthPoints = healthPoints;
        }

        public void DealDamage(int damageAmount)
        {
            _healthPoints -= damageAmount;

            if (_healthPoints <= 0)
            {
                OnHealthEnd?.Invoke();
                _healthPoints = 0;
            }

            OnHealthChanged?.Invoke(_healthPoints);
        }
    }
}
