using Enemies.BossLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using UnityEngine;

namespace SpawnerModule
{
    public class EnemySpawner : MonoCache
    {
        [SerializeField] private Transform _spawnPointBoss;

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