using PlateTD.Enemies.Interfaces;
using PlateTD.Entities.Enums;

namespace PlateTD.Repositories.Interfaces
{
    public interface IEnemyRepository
    {
        IEnemy GetEnemyPrefabByType(EnemyType enemyType);
    }
}