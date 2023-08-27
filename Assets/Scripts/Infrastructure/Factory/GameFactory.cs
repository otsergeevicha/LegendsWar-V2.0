using Infrastructure.Factory.Pools;
using Reflex;
using Services.Assets;
using Services.Factory;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assetsProvider;

        public GameFactory(IAssetsProvider assetsProvider) =>
            _assetsProvider = assetsProvider;

        public Pool CreatePool() =>
            _assetsProvider.InstantiateEntity(Constants.PoolPath).GetComponent<Pool>();
    }
}