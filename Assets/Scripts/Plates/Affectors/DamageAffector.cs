using PlateTD.Enemies.Interfaces;

public class DamageAffector : IPlateAffector
{
    private float _damage;

    public void AffectEnemy(IEnemy enemy)
    {
        enemy.ConsumeDamage(_damage);
    }

    public void SetData(object data)
    {
        if(data is float)
        {
            _damage = (float)data;
        }
    }
}