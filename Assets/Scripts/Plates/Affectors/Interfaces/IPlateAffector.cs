using PlateTD.Enemies.Interfaces;

public interface IPlateAffector
{
    public void SetData(object data);
    public void AffectEnemy(IEnemy enemy);
}