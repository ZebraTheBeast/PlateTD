using PlateTD.Entities.DTO;
using PlateTD.Extensions;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Plates
{
    public class PlateBehaviour : MonoBehaviour
    {
        [SerializeField] protected PlateDTO _plateData;
        [SerializeField] protected GameObject _plateRenderer;
        [SerializeField] protected DamageZone _damageZone;

        protected IPlateAffector _plateAffector;

        private float _timer;
        private int _consumedPlates;

        public bool IsUpgradable()
        {
            return _plateData.NextLevelPlate != null;
        }

        public bool TryUpgradePlate()
        {
            if (_plateData.NextLevelPlate != null)
            {
                _consumedPlates++;

                if (_consumedPlates >= _plateData.PlatesToLevelUp)
                {
                    _consumedPlates = 0;
                    _plateData = _plateData.NextLevelPlate;
                    UpdatePlate();
                }

                return true;
            }

            return false;
        }

        public void SetPlateData(PlateDTO data)
        {
            _plateData = data;
        }

        public void UpdatePlate()
        {
            Destroy(_plateRenderer);
            _plateRenderer = Instantiate(_plateData.PlateRenderer, gameObject.transform);
            _plateAffector.SetData(_plateData.ToDamageDebuffData());
        }

        protected virtual void Awake()
        {
            _timer = 0;
        }

        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else if (_damageZone.IsEnemyExist())
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