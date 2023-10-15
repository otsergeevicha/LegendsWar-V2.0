using Ammo.Ammunition;
using CameraLogic;
using Enemies;
using Enemies.BossLogic;
using HeroLogic;
using Infrastructure.Factory.Pools;
using Reflex;
using Services.Assets;
using Services.Factory;
using SpawnerModule;
using UI.Windows;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assetsProvider;

        public GameFactory(IAssetsProvider assetsProvider) =>
            _assetsProvider = assetsProvider;

        public Hero CreateHero() =>
            _assetsProvider.InstantiateEntity(Constants.HeroPath)
                .GetComponent<Hero>();

        public WindowRoot CreateWindowRoot() =>
            _assetsProvider.InstantiateEntity(Constants.WindowRootPath)
                .GetComponent<WindowRoot>();

        public CameraFollow CreateCamera() =>
            _assetsProvider.InstantiateEntity(Constants.CameraPath)
                .GetComponent<CameraFollow>();

        public Pool CreatePool() =>
            _assetsProvider.InstantiateEntity(Constants.PoolPath)
                .GetComponent<Pool>();

        public Grenade CreateGrenade() =>
            _assetsProvider.InstantiateEntity(Constants.GrenadePath)
                .GetComponent<Grenade>();

        public Enemy CreateEnemy(string typeEnemy) =>
            _assetsProvider.InstantiateEntity(typeEnemy)
                .GetComponent<Enemy>();

        public Boss CreateBoss(string typeBoss) =>
            _assetsProvider.InstantiateEntity(typeBoss)
                .GetComponent<Boss>();

        public EnemySpawner CreateEnemySpawner() =>
            _assetsProvider.InstantiateEntity(Constants.EnemySpawnerPath)
                .GetComponent<EnemySpawner>();
    }
}