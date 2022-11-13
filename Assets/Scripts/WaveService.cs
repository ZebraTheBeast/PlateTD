using System.Collections;
using System.Collections.Generic;
using PlateTD.Enemies.Interfaces;
using PlateTD.EnemyRepository.Interfaces;
using PlateTD.SO;
using UnityEngine;

public class WaveService : MonoBehaviour
{
    private IEnemyRepository _enemyRepository;

    private Queue<WaveData> _waves;

    private WaveData _currentWave;

    public void Init(WaveConfig waveConfig, IEnemyRepository enemyRepository)
    {
        _waves = new Queue<WaveData>(waveConfig.Waves);
        _enemyRepository = enemyRepository;
    }

    public bool TrySetNextWave()
    {
        _currentWave = _waves.Dequeue();

        return _currentWave == null;
    }

    public void StartWave()
    {
        foreach (var enemy in _currentWave.Enemies)
        {
            var enemyPrefab = _enemyRepository.GetEnemyPrefabByType(enemy.Type);
            StartCoroutine(SpawnEnemy(enemyPrefab, enemy.Path, enemy.Delay));
        }
    }

    private IEnumerator SpawnEnemy(IEnemy prefab, GameObject path, float delay)
    {
        yield return new WaitForSeconds(delay);
        var enemy = (IEnemy)Instantiate(prefab.GetObjectToInstantiate(), path.transform.GetChild(0).position, Quaternion.identity);
        enemy.SetPath(path);
    }
}