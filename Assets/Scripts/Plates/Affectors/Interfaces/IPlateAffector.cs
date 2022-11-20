using PlateTD.Enemies.Interfaces;
using PlateTD.Entities;

public interface IPlateAffector
{
    public void SetData(DamageDebuffData data);
    public void AffectEnemy(IEnemy enemy);
}