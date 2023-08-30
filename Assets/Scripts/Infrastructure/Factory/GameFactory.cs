using Windows;
using Ammo.Ammunition;
using CameraLogic;
using EnemyLogic;
using HeroLogic;
using Infrastructure.Factory.Pools;
using Services.Assets;
using Services.Factory;

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

        public Arrow CreateArrow() =>
            _assetsProvider.InstantiateEntity(Constants.ArrowPath)
                .GetComponent<Arrow>();

        public Enemy CreateEnemy(string typeEnemy) =>
            _assetsProvider.InstantiateEntity(typeEnemy)
                .GetComponent<Enemy>();
    }
}