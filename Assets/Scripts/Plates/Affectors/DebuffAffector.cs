using PlateTD.Debuffs;
using PlateTD.Enemies.Interfaces;

public class DebuffAffector : IPlateAffector
{
    private DebuffData _debuff;

    public void AffectEnemy(IEnemy enemy)
    {
        enemy.ConsumeDebuff(_debuff);
    }

    public void SetData(object data)
    {
        _debuff = data as DebuffData;
    }
}