using PlateTD.Enemies.Interfaces;
using PlateTD.SO;

public class DebuffAffector : IPlateAffector
{
    private DebuffSO _debuff;

    public void AffectEnemy(IEnemy enemy)
    {
        enemy.ConsumeDebuff(_debuff);
    }

    public void SetData(object data)
    {
        _debuff = data as DebuffSO;
    }
}