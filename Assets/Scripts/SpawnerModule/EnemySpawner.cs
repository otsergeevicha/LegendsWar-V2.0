using Enemies.BossLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using UnityEngine;

namespace SpawnerModule
{
    public class EnemySpawner : MonoCache
    {
        private readonly Vector3 _spawnPosition = new (23,5,20);
        
        private Pool _pool;
        private Boss _boss;
        private int _currentBoss;

        public void Construct(Pool pool)
        {
            _pool = pool;
            _currentBoss = 0;
            SpawnBoss();
        }

        private void SpawnBoss()
        {
            _boss = _pool.TryGetBoss(_currentBoss);
            _boss.transform.position = _spawnPosition;
            _boss.OnActive();
            _boss.Died += UpdateBoss;
        }

        private void UpdateBoss()
        {
            _boss.InActive();
            _boss.Died -= UpdateBoss;
            _boss = null;
            _currentBoss++;
            SpawnBoss();
        }
    }
}