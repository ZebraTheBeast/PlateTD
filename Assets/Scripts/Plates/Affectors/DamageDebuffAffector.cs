using PlateTD.Enemies.Interfaces;
using PlateTD.Entities;

namespace PlateTD.Plates.Affectors
{
    public class DamageDebuffAffector : IPlateAffector
    {
        private DamageDebuffData _damageDebuffData;

        public void AffectEnemy(IEnemy enemy)
        {
            enemy.ConsumeDamage(_damageDebuffData.Damage, _damageDebuffData.PlateType);
            enemy.ConsumeDebuff(_damageDebuffData.Debuff);
        }

        public void SetData(DamageDebuffData data)
        {
            _damageDebuffData = data;
        }
    }
}