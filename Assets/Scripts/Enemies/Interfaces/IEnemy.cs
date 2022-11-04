using PlateTD.Debuffs;

namespace PlateTD.Enemies.Interfaces
{
    public interface IEnemy
    {
        public void ConsumeDamage(float damage);
        public void ConsumeDebuff(DebuffData debuff);
    }
}