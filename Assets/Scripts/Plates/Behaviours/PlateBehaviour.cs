using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Plates
{
    public class PlateBehaviour : MonoBehaviour
    {
        [SerializeField] protected PlateData _plateData;
        [SerializeField] protected GameObject _plateRenderer;
        [SerializeField] protected DamageZone _damageZone;

        protected IPlateAffector _plateAffector;

        private float _timer;
        private int _consumedPlates;

        public bool TryUpgradePlate()
        {
            if(_plateData.NextLevelPlate != null)
            {
                _consumedPlates++;

                if(_consumedPlates >= _plateData.PlatesToLevelUp)
                {
                    _consumedPlates = 0;
                    _plateData = _plateData.NextLevelPlate;
                    UpdatePlateRenderer();
                }

                return true;
            }

            return false;
        }

        public void UpdatePlateRenderer()
        {
            Destroy(_plateRenderer);
            _plateRenderer = Instantiate(_plateData.PlateRenderer, gameObject.transform);
        }

        protected virtual void Awake()
        {
            _timer = _plateData.ReloadSpeed;
        }

        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else if (_damageZone.IsEnemyExist)
            {
                foreach (var enemy in _damageZone.Enemies)
                {
                    _plateAffector.AffectEnemy(enemy);
                }
                _timer = _plateData.ReloadSpeed;
            }
        }


    }
}