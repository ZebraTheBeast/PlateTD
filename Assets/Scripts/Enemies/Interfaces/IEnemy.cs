using PlateTD.SO;

namespace PlateTD.Enemies.Interfaces
{
    public interface IEnemy
    {
        public void ConsumeDamage(float damage);
        public void ConsumeDebuff(DebuffSO debuff);
    }
}