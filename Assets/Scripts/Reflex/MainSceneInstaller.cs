using CameraLogic;
using HeroLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Reflex.Core;
using Services.Factory;
using Services.Inputs;
using Services.SaveLoad;
using Services.Wallet;
using SpawnerModule;
using UI.Windows;

namespace Reflex
{
    public class MainSceneInstaller : MonoCache, IInstaller
    {
        public void InstallBindings(ContainerDescriptor descriptor) =>
            descriptor.OnContainerBuilt += LoadLevel;

        private void LoadLevel(Container container)
        {
            ISave save = container.Single<ISave>();
            IInputService input = container.Single<IInputService>();
            IWallet wallet = container.Single<IWallet>();
            IGameFactory gameFactory = container.Single<IGameFactory>();

            Pool pool = gameFactory.CreatePool();
            CameraFollow cameraFollow = gameFactory.CreateCamera();
            WindowRoot windowRoot = gameFactory.CreateWindowRoot();
            Hero hero = gameFactory.CreateHero();
            EnemySpawner enemySpawner = gameFactory.CreateEnemySpawner();

            pool.Construct(gameFactory, hero);
            hero.Construct(input, pool, cameraFollow, save);
            cameraFollow.Construct(input, hero.GetCameraRoot());
            windowRoot.Construct(save,input,wallet,gameFactory);
            enemySpawner.Construct(pool);
        }
    }
}