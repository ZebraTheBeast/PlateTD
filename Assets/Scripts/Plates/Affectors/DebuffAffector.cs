using PlateTD.Enemies.Interfaces;
using PlateTD.Entities;
using PlateTD.SO;

namespace PlateTD.Plates.Affectors
{
    public class DebuffAffector : IPlateAffector
    {
        private DebuffSO _debuff;

        public void AffectEnemy(IEnemy enemy)
        {
            enemy.ConsumeDebuff(_debuff);
        }

        public void SetData(DamageDebuffData data)
        {
            _debuff = data.Debuff;
        }
    }
}