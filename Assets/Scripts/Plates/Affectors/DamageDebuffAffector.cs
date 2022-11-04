using PlateTD.Enemies.Interfaces;

public class DamageDebuffAffector : IPlateAffector
{
    private DamageDebuffData _damageDebuffData;

    public void AffectEnemy(IEnemy enemy)
    {
        enemy.ConsumeDamage(_damageDebuffData.Damage);
        enemy.ConsumeDebuff(_damageDebuffData.Debuff);
    }

    public void SetData(object data)
    {
        _damageDebuffData = data as DamageDebuffData;
    }
}