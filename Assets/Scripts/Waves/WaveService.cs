using System.Collections;
using System.Collections.Generic;
using PlateTD.Enemies.Interfaces;
using PlateTD.Extensions;
using PlateTD.Repositories.Interfaces;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Waves
{
    public class WaveService : MonoBehaviour
    {
        private IEnemyRepository _enemyRepository;

        private Queue<WaveData> _waves;
        private WaveData _currentWave;

        private int _spawnedEnemies = 0;

        private List<IEnemy> _aliveEnemies;

        public void Init(WaveConfig waveConfig)
        {
            _waves = new Queue<WaveData>(waveConfig.Waves);
        }

        public bool TrySetNextWave()
        {
            return _waves.TryDequeue(out _currentWave);
        }

        public void StartWave()
        {
            _spawnedEnemies = 0;
            _aliveEnemies = new List<IEnemy>();

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
            enemy.OnEnemyDeath += OnEnemyDeathHandler;
            _aliveEnemies.Add(enemy);
            _spawnedEnemies++;
        }

        private void OnEnemyDeathHandler(IEnemy enemy)
        {
            enemy.OnEnemyDeath -= OnEnemyDeathHandler;
            _aliveEnemies.Remove(enemy);

            if (_aliveEnemies.Count == 0 &&
                _currentWave.Enemies.Count == _spawnedEnemies)
            {
                GameEvents.InvokeEndWave(_waves.Count == 0);
            }
        }

        private void Start()
        {
            _enemyRepository = ServiceLocator.Resolve<IEnemyRepository>();
        }
    }
}