using PlateTD.Enemies.Interfaces;
using PlateTD.Entities;
using PlateTD.Entities.Enums;

namespace PlateTD.Plates.Affectors
{
    public class DamageAffector : IPlateAffector
    {
        private float _damage;
        private PlateType _plateType;

        public void AffectEnemy(IEnemy enemy)
        {
            enemy.ConsumeDamage(_damage, _plateType);
        }

        public void SetData(DamageDebuffData data)
        {
            _damage = data.Damage;
            _plateType = data.PlateType;
        }
    }
}