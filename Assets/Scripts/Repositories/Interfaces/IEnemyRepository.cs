using PlateTD.Enemies.Interfaces;
using PlateTD.Entities.Enums;

namespace PlateTD.EnemyRepository.Interfaces
{
    public interface IEnemyRepository
    {
        IEnemy GetEnemyPrefabByType(EnemyType enemyType);
    }
}